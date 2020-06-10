using BudgetAp.BudgetClasses;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;


namespace BudgetAp
{
    public static class Utils
    {
        /// <summary>
        /// Limits inputs to -0123456789. and backspace.
        /// </summary>
        /// <param name="e"></param>
        public static void ValidateCurrencyInputs(KeyPressEventArgs e)
        {
            //TODO: needs stronger validation. What if someone input multiple periods?
            string allowedCharacters = "-0123456789.";
            if (e.KeyChar != (char)Keys.Back)  //Allow backspace
            {
                if (allowedCharacters.IndexOf(e.KeyChar) == -1)
                {
                    //Invalid character. Warn the user and don't allow the inclusion of the key.
                    e.Handled = true;
                    MessageBox.Show("Please only enter digits, a single period, and hyphen '-' if needed to represent a negative.");
                }
            }
        }

        /// <summary>
        /// Saves current DB and clears all database data.
        /// </summary>
        /// <param name="currentBudget">BudgetDB: budget db object for the currently open budget. Used to save the currently oben budget before creating the new one.</param>
        /// <param name="saveLocation">String: specified save location for the new .bak file. Use of a syncing drive (such as Google Drive) is recommended.</param>
        public static void PrepNewBudget(BudgetDB currentBudget, string saveLocation)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BudgetConnect"].ConnectionString);
            using (conn)
            {
                //Open connection
                conn.Open();

                //If a different budget is currently open, save it before creating the new budget.
                SaveCurrentBudget(currentBudget);

                //truncate the data in the current DB.
                TruncateTables(conn);

                //Create a new .bak.            
                SaveDB(saveLocation, conn);
            }
        }

        /// <summary>
        /// Loads (restores) the database using the data from a previously built .bak file.
        /// </summary>
        /// <param name="backupFile">String: the specified .bak filename and pathway.</param>
        public static void LoadBudgetFile(string backupFile, BudgetDB currentBudget)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BudgetConnect"].ConnectionString);
            using (conn)
            {
                //Open connection
                conn.Open();

                //If a different budget is currntly open, save it before loading the specified budget.
                SaveCurrentBudget(currentBudget);

                //Truncate the data in the current DB
                TruncateTables(conn);

                //Restore the DB using the backup file.
                RestoreDB(backupFile, conn);
            }
        }

        /// <summary>
        /// Retrieves a list of tables in the database based on the connection string.
        /// </summary>
        /// <param name="conn">SqlConnection: connection to the DB.</param>
        /// <returns></returns>
        private static void TruncateTables(SqlConnection conn)
        {
            //Get list of tables
            DataTable schema = conn.GetSchema("Tables");
            List<string> tableNames = new List<string>();
            foreach (DataRow row in schema.Rows)
            {
                tableNames.Add(row[2].ToString());
            }

            //Truncate each table
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            string sql = "";
            foreach (string table in tableNames)
            {
                sql = $"TRUNCATE table [{table}]";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Tests for existence of currently open budget. If a budget is found to be open, creates a backup of the budget at the stored save location. Should be called after any DB interaction.
        /// </summary>
        /// <param name="currentBudget">Budget: the current budget object.</param>
        /// 
        public static void SaveCurrentBudget(BudgetDB currentBudget)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BudgetConnect"].ConnectionString);
            if (currentBudget != null && currentBudget.GetBackupLocation() != "")
            {
                var file = new FileInfo(currentBudget.GetBackupLocation());

                if (File.Exists(currentBudget.GetBackupLocation()))
                {
                    while (IsFileLocked(file))
                    {
                        //wait for file to be available. Necessary if .bak file is stored in an auto sync drive such as GoogleDrive.

                        //TODO: provide some indication to the user as to why the program is pausing.
                    }

                    using (conn)
                    {
                        conn.Open();
                        try
                        {
                            SaveDB(currentBudget.GetBackupLocation(), conn);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error backing up currently open budget!");
                            MessageBox.Show(ex.ToString(), "Budget", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            //TODO: refine this exit.
                            Application.Exit();
                        }
                    }                     
                }
                else
                {
                    MessageBox.Show($"Error! .bak file not found at the stored backup location. {currentBudget.GetBackupLocation()}");
                }
            }
        }

        /// <summary>
        /// Provides indication of the .bak file's use-status by attempting to access the file and returning true of an IOException is caught.
        /// </summary>
        /// <param name="filePathway">FileInfo: file info object that represents the associated .bak file.</param>
        /// <returns>Boolean: True if file is currently being accessed by another program (typically the syncing program if the file is saved in an auto-sync folder such as Google Drive).</returns>
        private static bool IsFileLocked(FileInfo filePathway)
        {
            try
            {
                using(FileStream stream = filePathway.Open(FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    stream.Close();
                }
            }
            catch (IOException)
            {
                //The file is unavailable because it is being accessed elsewhere.                
                return true;
            }
            
            return false;
        }

        /// <summary>
        /// Creates a .bak file at the specified location.
        /// </summary>
        /// <param name="saveLocation"></param>
        /// <param name="conn"></param>
        private static void SaveDB(string saveLocation, SqlConnection conn)
        {   
            string fileName = Path.GetFileNameWithoutExtension(saveLocation);            
            string sql = "";
            string dbLocation = Application.StartupPath;
            SqlCommand cmd = new SqlCommand(sql, conn);

            sql = $"BACKUP DATABASE [{dbLocation}\\Budget.mdf] TO DISK = '{saveLocation}' WITH INIT, " +
                $" NOUNLOAD, NAME = N'{fileName} backup',  NOSKIP ,  STATS = 10,  NOFORMAT";

            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Restores the DB using the specified .bak file.
        /// </summary>
        /// <param name="backupFile">String: Filepathway for the .bak file.</param>
        /// <param name="conn">SqlConnection: connection to the DB.</param>
        private static void RestoreDB(string backupFile, SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "Use Master";
            cmd.ExecuteNonQuery();
            cmd.CommandText = $"ALTER DATABASE [{System.Windows.Forms.Application.StartupPath}\\Budget.mdf] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;";
            cmd.ExecuteNonQuery();
            cmd.CommandText = $"RESTORE DATABASE [{System.Windows.Forms.Application.StartupPath}\\Budget.mdf] FROM DISK = '{backupFile}';";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Use Master";
            cmd.ExecuteNonQuery();
            cmd.CommandText = $"ALTER DATABASE [{System.Windows.Forms.Application.StartupPath}\\Budget.mdf] SET MULTI_USER;";
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Pulls a list of names from the specified default list.
        /// </summary>
        /// <param name="table">String: name of the .txt value that contains default values.</param>
        /// <returns>Returns a list of strings containing default name values.</returns>
        public static List<string> GetListOfNames(string table)
        {
            List<string> names = new List<string>();
            foreach (string line in File.ReadLines($"DefaultValues\\{table}.txt"))
            {
                string newName = line;
                names.Add(newName);
            }
            return names;
        }
    }
}
