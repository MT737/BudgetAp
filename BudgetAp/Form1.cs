using BudgetAp.BudgetClasses;
using System;
using System.IO;
using System.Windows.Forms;
using static BudgetAp.DatabaseInsertsAndMods;
using static BudgetAp.Utils;



namespace BudgetAp
{
    public partial class Form1 : Form
    {
        //Budget object to hold necessary budget data in memory.
        private BudgetDB budget;
        
        //Connection string to the Budget DB.
        private readonly string _connString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\BudgetApp\\Budget.mdf;Integrated Security=True;";

        //Constructor
        public Form1()
        {
            InitializeComponent();            
        }

        //Load form
        private void Form1_Load(object sender, EventArgs e)
        {
            //TODO: Review possible issues with log file.
            //TODO: Account balance is being stored as decimal(18,0). Is this accurate enough?
        }

        /// <summary>
        /// Initiates new budget database process.
        /// </summary>
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Request storage location pathway from user.
            MessageBox.Show("Name your new backup file and select a storage location. This can be used for syncing across devices if saved in a syncing folder such as Google Drive.");
            
            //Validate user filename 
            if (saveFileDialog1.ShowDialog() == DialogResult.OK && Path.GetExtension(saveFileDialog1.FileName) == ".bak")
            {
                //Check if a budget is currently open.
                if (budget != null)
                {
                    //If a different budget is currently open, save it.
                    SaveCurrentBudget(budget);
                    
                    //Delete the current DB
                    DeleteDB(_connString);

                    //Clear the budget object
                    budget = null;
                }
          
                //Creat a new budget DB and set the budget object = to a new BudgetDB object.
                NewBudget(_connString);
                budget = new BudgetDB(saveFileDialog1.FileName, _connString);
                
                //Have user enter at least 1 account.
                while (!InitialAccountCreation())
                {
                    //Keep looping here until the user creates an account.
                    //There is no escape. Resistance is futile.
                }

                //Fill the dgvs
                FillDGVS();

                //Save to the .bak file.
                Utils.SaveCurrentBudget(budget);
            }
            else //Inform the user to enter appropriate file extension.
            {
                MessageBox.Show("Please use the requested file extension (bak).");
            }
        }

        /// <summary>
        /// Initiates the load existing budget database process.
        /// </summary>
        private void loadBudgetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Request backup file pathway from the user.
            MessageBox.Show("Select the backup budget file you would like to open.");

            //TODO: Need to increase validation. User could select a .bak file that's not actually for this program.
            //Validate user selection
            if (openFileDialog1.ShowDialog() == DialogResult.OK && Path.GetExtension(openFileDialog1.FileName) == ".bak")
            {
                //Check if a budget object is currently loaded. 
                if (budget != null)
                {
                    //If a budget object currently exists, save it.
                    SaveCurrentBudget(budget);
                    
                    //Delete the current DB.
                    DeleteDB(_connString);

                    //Clear the budget object.
                    budget = null;
                }
 
                //Load the budget file selected by the user.
                LoadBudget(openFileDialog1.FileName);
                budget = new BudgetDB(openFileDialog1.FileName, _connString);
                
                //If no accounts exist, start a loop requiring the user to enter an account.
                if (budget.GetAccountCount() == 0)
                {
                    while (!InitialAccountCreation())
                    {
                        //Keep looping here until the user creates an account.
                    }
                }

                //Fill the dgvs
                FillDGVS();

                //Save to the .bak file.
                Utils.SaveCurrentBudget(budget);
            }
            else //Inform the user to open a correct file.
            {
                MessageBox.Show("Please select an appropriate file to open.");
            }       
        }

        /// <summary>
        /// Fills and formates the data grid views in the form.
        /// </summary>
        private void FillDGVS()
        {
            //Account Overview
            budget.FillAccountDGV(dgvAccountOverview);
            dgvAccountOverview.Columns[0].Visible = false;              //Don't show AccountID
            dgvAccountOverview.Columns[3].Visible = false;              //Don't show AccountStatus
            HideInactive(dgvAccountOverview);                           //Don't show inactive accounts
            dgvAccountOverview.Columns[4].DefaultCellStyle.Format = "c";
            dgvAccountOverview.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //Transactions
            budget.FillTransactionsDGV(dgvTransactions);
            dgvTransactions.Columns[0].Visible = false;                 //Don't show TransactionsID
            dgvTransactions.Columns[1].DefaultCellStyle.Format = "MM/dd/yyyy";
            dgvTransactions.Columns[6].DefaultCellStyle.Format = "c";
            dgvTransactions.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvTransactions.Rows[0].Cells[1].Selected = true; //Hiding the first column results in the table not autoloading with a cell(row) selected. Can result in a crash if user selects edit transaction before selecting a row.
            
            //Spending by Category            
            budget.FillSpendingByCategory(dgvSpendingByCategory);
            dgvSpendingByCategory.Columns[0].Visible = false;
            dgvSpendingByCategory.Columns[2].DefaultCellStyle.Format = "c";
            dgvSpendingByCategory.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvSpendingByCategory.Columns[3].DefaultCellStyle.Format = "c";
            dgvSpendingByCategory.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvSpendingByCategory.Columns[4].DefaultCellStyle.Format = "c";
            dgvSpendingByCategory.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;           
        }
                
        /// <summary>
        /// Prevents inactive accounts from appearing in the the Accounts Overview data grid view.
        /// </summary>
        /// <param name="dgvAccountOverview">DataGridView: Account Overview.</param>
        private void HideInactive(DataGridView dgvAccountOverview)
        {
            foreach (DataGridViewRow dr in dgvAccountOverview.Rows)
            {
                if (Convert.ToBoolean(dr.Cells[3].Value) != true)
                {
                    dr.Visible = false;
                }
            }
        }

        /// <summary>
        /// Opens the AccountManager form and prompts the user to enter an account.
        /// </summary>
        /// <returns>Boolean: returns true of at least 1 account exists. Returns false if no account exists.</returns>
        private bool InitialAccountCreation()
        {
            MessageBox.Show("Please enter the accounts you would like to associate with this budget. Note: you must include at least 1 account.");
            bool created = false;
            AccountManager oForm = new AccountManager(budget);
            oForm.StartPosition = FormStartPosition.CenterParent;
            oForm.ShowDialog();  //Using showdialog so that the main form pauses while the AccountManager is open.
            oForm = null;

            if (budget.GetAccountCount() > 0)
            {
                created = true;
            }
            return created;
        }

        /// <summary>
        /// Calls the PushToDBandBackup method and closes the application.
        /// </summary>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (budget != null)
            {
                budget.PushToDBandBackup(); 
            }
            Application.Exit();
        }

        /// <summary>
        /// Opens the Category Manager.
        /// </summary>
        private void btnCategoryManager_Click(object sender, EventArgs e)
        {
            if (budget != null)
            {
                EditSelection oForm = new EditSelection(budget, "Category");
                oForm.StartPosition = FormStartPosition.CenterParent;
                oForm.ShowDialog();  //Using showdialog so that the main form pauses while the AccountManager is open.
                oForm = null;

                FillDGVS(); 
            }
            else
            {
                PleaseCreateOrLoadBudget();
            }
        }

        /// <summary>
        /// Opens the Account Manager.
        /// </summary>
        private void btnAccountManager_Click(object sender, EventArgs e)
        {
            if (budget != null)
            {
                AccountManager oForm = new AccountManager(budget);
                oForm.StartPosition = FormStartPosition.CenterParent;
                oForm.ShowDialog();  //Using showdialog so that the main form pauses while the AccountManager is open.
                oForm = null;

                FillDGVS(); 
            }
            else
            {
                PleaseCreateOrLoadBudget();
            }
        }

        /// <summary>
        /// Prompts the New Transaction process.
        /// </summary>
        private void btnNewTransaction_Click(object sender, EventArgs e)
        {
            if (budget != null)
            {
                TransactionManager oForm = new TransactionManager(false, 0, budget);
                oForm.StartPosition = FormStartPosition.CenterParent;
                oForm.ShowDialog(); //Using showdialog so that the m ain form pauses whil the TransactionManager is open.
                oForm = null;

                FillDGVS(); 
            }
            else
            {
                PleaseCreateOrLoadBudget();
            }
        }

        /// <summary>
        /// Prompts the delete transaction process on the transaction currently selected in the transactions data grid view.
        /// </summary>
        private void btnDeleteTransaction_Click(object sender, EventArgs e)
        {
            //TODO: Prevent deletion of new account balance?
            if (budget != null)
            {
                DialogResult dialogResult = MessageBox.Show("This action cannot be undone. Are you sure you want to delete the selected transaction?", "Delete Transaction", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    DeleteTransaction(budget.GetTransactionsTable(), (int)dgvTransactions.CurrentRow.Cells[0].Value);
                    budget.PushToDBandBackup();
                    FillDGVS();
                } 
            }
            else
            {
                PleaseCreateOrLoadBudget();
            }
        }

        /// <summary>
        /// Prompts the edit transaction process on the transaction currently selected in the Transactions data grid view.
        /// </summary>
        private void btnEditTransaction_Click(object sender, EventArgs e)
        {
            if (budget != null)
            {
                TransactionManager oForm = new TransactionManager(true, (int)dgvTransactions.CurrentRow.Cells[0].Value, budget);
                oForm.StartPosition = FormStartPosition.CenterParent;
                oForm.ShowDialog(); //Using showdialog so that the main form pauses whil the TransactionManager is open.
                oForm = null;

                FillDGVS(); 
            }
            else
            {
                PleaseCreateOrLoadBudget();
            }
        }

        /// <summary>
        /// Calls the SaveCurrentBudget method on the currently open budget.
        /// </summary>
        private void saveBudgetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (budget != null)
            {
                //Save to the .bak file.
                Utils.SaveCurrentBudget(budget); 
            }
            else
            {
                PleaseCreateOrLoadBudget();
            }
        }

        /// <summary>
        /// Opens the Account Manager.
        /// </summary>
        private void accountManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (budget != null)
            {
                AccountManager oForm = new AccountManager(budget);
                oForm.StartPosition = FormStartPosition.CenterParent;
                oForm.ShowDialog();  //Using showdialog so that the main form pauses while the AccountManager is open.
                oForm = null;

                FillDGVS(); 
            }
            else
            {
                PleaseCreateOrLoadBudget();
            }
        }

        /// <summary>
        /// Opens the Category Manager.
        /// </summary>
        private void categoryManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (budget != null)
            {
                EditSelection oForm = new EditSelection(budget, "Category");
                oForm.StartPosition = FormStartPosition.CenterParent;
                oForm.ShowDialog();  //Using showdialog so that the main form pauses while the AccountManager is open.
                oForm = null;

                FillDGVS(); 
            }
            else
            {
                PleaseCreateOrLoadBudget();
            }
        }

        /// <summary>
        /// Opens the Vendor Manager.
        /// </summary>
        private void vendorManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (budget != null)
            {
                EditSelection oForm = new EditSelection(budget, "Vendor");
                oForm.StartPosition = FormStartPosition.CenterParent;
                oForm.ShowDialog();  //Using showdialog so that the main form pauses while the AccountManager is open.
                oForm = null;

                FillDGVS(); 
            }
            else
            {
                PleaseCreateOrLoadBudget();
            }    
        }

        /// <summary>
        /// Prompts a messagebox instructing the user to create a new or open an existing budget.
        /// </summary>
        private void PleaseCreateOrLoadBudget()
        {
            MessageBox.Show("Please create a new or load an existing budget.");
        }

        /// <summary>
        /// Opens the DisplayedCategoriesManager        
        /// </summary>
        private void btnModifyDisplayedCats_Click(object sender, EventArgs e)
        {
            if (budget != null)
            {
                DisplayCategoriesManager oForm = new DisplayCategoriesManager(budget);
                oForm.StartPosition = FormStartPosition.CenterParent;
                oForm.ShowDialog();  //Using showdialog so that the main form pauses while the AccountManager is open.
                oForm = null;

                FillDGVS();
            }
            else
            {
                PleaseCreateOrLoadBudget();
            }
        }

        //TODO: Implement Export of transactions table.
        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (budget != null)
            {
                MessageBox.Show("Please select a location and file name to store your export file.");                
                if (saveFileDialog2.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ExportToTextFile(dgvTransactions, saveFileDialog2.FileName);
                        MessageBox.Show("Transactions table successfully exported.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error exporting transactions table. {ex}", "BudgetApp", MessageBoxButtons.OK);
                    }
                }
            }
            else
            {
                PleaseCreateOrLoadBudget();
            }
        }
    }
}
