using BudgetAp.BudgetClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;


namespace BudgetAp
{
    public static class Utils
    {
        /// <summary>
        /// Checks for and creates if needed the DB pathway (i.e., a BudgetApp folder in the user's Documents folder). Deletes any currently existing Budget DB in the pathway destination.
        /// </summary>
        public static void StartStopRoutine()
        {
            //Create DB pathway and file pathway strings.
            string DBPathway = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\BudgetApp";            
            string DBFilePathway = $"{DBPathway}\\Budget.mdf";
            string connectionString = $"Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = {DBFilePathway}; Integrated Security = True;";

            //Make sure the directory exists.
            Directory.CreateDirectory(DBPathway);

            //Check for existing DB. On open, shouldn't exist if program closed properly. On close, remove the DB.
            if (File.Exists(DBFilePathway))
            {
                SqlConnection conn = new SqlConnection(connectionString);
                DeleteDB(connectionString);
            }
        }

        /// <summary>
        /// Delete the Budget database.
        /// </summary>
        internal static void DeleteDB(string connectionString)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            using (conn)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("", conn);                    
                    conn.Open();

                    //Set to master.
                    cmd.CommandText = "Use Master";
                    cmd.ExecuteNonQuery();

                    //Set to single user to remove any lagging connections.
                    cmd.CommandText = $"ALTER DATABASE [Budget] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;";
                    cmd.ExecuteNonQuery();

                    //Delete the db.
                    string sqlDelete = "DROP DATABASE Budget";
                    cmd.CommandText = sqlDelete;
                    cmd.ExecuteNonQuery();
                    
                    MessageBox.Show("DataBase is Successfully Deleted", "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show($"Error deleting database. {ex}", "BudgetApp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //TODO: create an out for this failure.
                    Application.Exit();
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                } 
            }
        }

        /// <summary>
        /// Creates a Budget DB on the LocalDB server and saves the .mdf file in the users's Documents/BudgetApp folder. Table structure is added to the DB.
        /// </summary>
        public static void NewBudget(string connString)
        {
            //Create a DB connection string for creating a new DB. Connection string for a new DB doesn't include reference to an existing mdf.
            string newDBconn = $"Data Source=(LocalDB)\\MSSQLLocalDB; Integrated Security=true; database=master";

            //Create new budget DB.
            CreateDB(newDBconn);

            //Create DB tables
            CreateDBTables(connString);        
        }

        /// <summary>
        /// Creates a new DB on the local DB server and saves the .mdf file in the user's Documents\BudgetApp folder.
        /// </summary>
        /// <param name="newDBConn"></param>
        private static void CreateDB(string newDBConn)
        {
            string sql = "CREATE DATABASE Budget ON PRIMARY " +
                        "(NAME = Budget, " +
                        $"FILENAME = '{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\BudgetApp\\Budget.mdf', " +
                        "SIZE = 2MB, MAXSIZE = 10MB, FILEGROWTH = 10%) " +
                        "LOG ON (NAME = Budget_Log, " +
                        $"FILENAME = '{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\BudgetApp\\Budget.ldf', " +
                        "SIZE = 1MB, " +
                        "MAXSIZE = 5MB, " +
                        "FILEGROWTH = 10%)";

            SqlConnection conn = new SqlConnection(newDBConn);
            SqlCommand cmd = new SqlCommand(sql, conn);
            using (conn)
            {
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("DataBase is Created Successfully", "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error creating new database. {ex}", "BudgetApp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //TODO: create an out for this failure.
                    Application.Exit();
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
        }

        /// <summary>
        /// Creates the table structure for the DB.
        /// </summary>
        /// <param name="connString"></param>
        private static void CreateDBTables(string connString)
        {
            SqlConnection conn = new SqlConnection(connString);
            using (conn)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("", conn);
                    conn.Open();

                    //Create Account table
                    string sql = "CREATE TABLE [Account] (\n" +
                           "[AccountID] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL\n" +
                           ",[Name] [nvarchar](100) NOT NULL\n" +
                           ",[IsAsset] [bit] NOT NULL\n" +
                           ",[IsActive] [bit] NOT NULL)";
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();

                    //Create Category table
                    sql = "CREATE TABLE [Category] (\n" +
                        "[CategoryID] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL\n" +
                        ",[Name] [nvarchar](100) NOT NULL\n" +
                        ",[IsDefault] [bit] NOT NULL)";
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();

                    //Create Vendor table
                    sql = "CREATE TABLE [Vendor] (\n" +
                        "[VendorID] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL\n" +
                        ",[Name] [nvarchar](100) NOT NULL\n" +
                        ",[IsDefault] [bit] NOT NULL)";
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();

                    //Create Transactions table
                    sql = "CREATE TABLE [Transactions] (\n" +
                        "[TransactionID] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL\n" +
                        ",[TransactionDate] [date] NOT NULL\n" +
                        ",[AccountID] [int] NOT NULL\n" +
                        ",[TransactionType] [nvarchar](15) NOT NULL\n" +
                        ",[CategoryID] [int] NOT NULL\n" +
                        ",[VendorID] [int] NOT NULL\n" +
                        ",[Amount] [decimal](18,0) NOT NULL\n" +
                        ",[Description] [nvarchar](500) NULL)";
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error building database tables. {ex}", "BudgetApp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //TODO: create an out for this failure.
                    Application.Exit();
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
        }

        /// <summary>
        /// Loads (restores) the database using the user selected .bak file.
        /// </summary>
        /// <param name="backupFile"></param>
        /// <param name="currentBudget"></param>
        /// <param name="conn"></param>
        public static void LoadBudget(string backupFile)
        {
            //Build the connection string. 
            string restorConnString = $"Data Source=(LocalDB)\\MSSQLLocalDB; Integrated Security=true; database=master";
            
            //Restore the DB using the backup file.
            RestoreDB(backupFile, restorConnString);          
        }
          
        /// <summary>
        /// Restores the DB using the specified .bak file.
        /// </summary>
        /// <param name="backupFile">String: Filepathway for the .bak file.</param>
        /// <param name="conn">SqlConnection: connection to the DB.</param>
        private static void RestoreDB(string backupFile, string restorConnString)
        {
            SqlConnection conn = new SqlConnection(restorConnString);
            SqlCommand cmd = new SqlCommand("", conn);
            using (conn)
            {
                try
                {
                    conn.Open();
                    //Set to master.
                    cmd.CommandText = "Use Master";
                    cmd.ExecuteNonQuery();

                    //Restore the DB.
                    cmd.CommandText = $"RESTORE DATABASE [Budget] FROM DISK = '{backupFile}';";
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading .bak file. {ex}", "BudgetApp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
        }

        /// <summary>
        /// Tests for existence of currently open budget. If a budget is found to be open, creates a backup of the budget at the stored save location. Should be called after any DB interaction.
        /// </summary>
        /// <param name="currentBudget">Budget: the current budget object.</param>
        /// 
        public static void SaveCurrentBudget(BudgetDB currentBudget)
        {            
            var file = new FileInfo(currentBudget.GetBackupLocation());
            
            //Check for existence of the .bak file.
            if (File.Exists(currentBudget.GetBackupLocation()))
            {
                //If exists, check if the file is currently accessed by another program (common if recently saved in a syncing drive such as GoogleDrive).
                while (IsFileLocked(file))
                {
                    //wait for file to be available.

                    //TODO: provide some indication to the user as to why the program is pausing.
                }
                try
                {
                    //Save the database to a .bak file.
                    SaveBak(currentBudget.GetConnectionString(), currentBudget.GetBackupLocation());
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error backing up currently open budget. Application will close. {ex}", "BudgetApp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    //TODO: refine this exit.
                    Application.Exit();
                }                                    
            }
            else //If DB has yet to be backedup, then the file will not already exist and cannot be in use. Go straight to saving.
            {
                try
                {
                    //Save the database to a .bak file.
                    SaveBak(currentBudget.GetConnectionString(), currentBudget.GetBackupLocation());
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error backing up currently open budget. Application will close. {ex}", "BudgetApp", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //TODO: refine this exit.
                    Application.Exit();
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
                //Test access to the file.
                using(FileStream stream = filePathway.Open(FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    stream.Close();
                }
            }
            catch (IOException)
            {
                //Exception means the file is unavailable because it is being accessed elsewhere. Return true.               
                return true;
            }            
            //File is not currently being used by another process. Return false.
            return false;
        }

        /// <summary>
        /// Creates a .bak file at the specified location in AppSettings.
        /// </summary>
        /// <param name="saveLocation"></param>
        /// <param name="conn"></param>
        public static void SaveBak(string connString, string backupLocation)
        {
            SqlConnection conn = new SqlConnection(connString);            
            string fileName = Path.GetFileNameWithoutExtension(backupLocation);
            string sql = $"BACKUP DATABASE [Budget] TO DISK = '{backupLocation}' WITH INIT, " +
                    $" NOUNLOAD, NAME = N'{fileName} backup',  NOSKIP ,  STATS = 10,  NOFORMAT";
            using (conn)
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error creating .bak file. {ex}", "BudgetApp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //TODO: create an out for this failure.
                    Application.Exit();
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
        }

        /// <summary>
        /// Limits inputs to -0123456789. and backspace.
        /// </summary>
        /// <param name="e"></param>
        public static void ValidateCurrencyInputs(KeyPressEventArgs e)
        {
            //TODO: needs stronger validation. What if someone input multiple periods?
            //Create a string of valid characters.
            string allowedCharacters = "-0123456789.";

            if (e.KeyChar != (char)Keys.Back)  //Allow backspace
            {
                //Look for pressed key in the string of allowed characters. If not found, -1 is returned.
                if (allowedCharacters.IndexOf(e.KeyChar) == -1)
                {
                    //Invalid character. Warn the user.
                    e.Handled = true;
                    MessageBox.Show("Please only enter digits, a single period, and hyphen '-' if needed to represent a negative.");
                }
            }
        }

        /// <summary>
        /// Pulls a list of names from the specified default list.
        /// </summary>
        /// <param name="table">String: name of the .txt value that contains default values.</param>
        /// <returns>Returns a list of strings containing default name values.</returns>
        public static List<string> GetListOfNames(string table)
        {
            //Create a list of strings to hold the entries from the default entity text fils.
            List<string> names = new List<string>();

            //Add each line from the default entity text files as a string object to the names list.
            foreach (string line in File.ReadLines($"DefaultValues\\{table}.txt"))
            {
                string newName = line;
                names.Add(newName);
            }
            return names;
        }
    }
}
