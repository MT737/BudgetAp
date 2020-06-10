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
      
        public Form1()
        {
            InitializeComponent();
        }

        //Load form.
        private void Form1_Load(object sender, EventArgs e)
        {
            //TODO: Program will require SQL functionality. If user does not already have SQL server or local SQL, display warning. (eventually, package the installer?).
            //TODO: Review possible issues with log file.
            //TODO: Also, account balance is being stored as decimal(18,0). Is this accurate enough?

        }

        /// <summary>
        /// Initiates new budget database process.
        /// </summary>
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool successfulFileCreation = false;

            MessageBox.Show("Name your new backup file and select a storage location. This can be used for syncing across devices if saved in a syncing folder such as Google Drive.");
            if (saveFileDialog1.ShowDialog() == DialogResult.OK && Path.GetExtension(saveFileDialog1.FileName) == ".bak")
            {
                try
                    {                        
                        PrepNewBudget(budget, saveFileDialog1.FileName);                        
                        budget = new BudgetDB(saveFileDialog1.FileName);
                        successfulFileCreation = true;
                    }
                    catch (Exception ex)
                    {
                        //TODO: Provide a generic exception message.
                        MessageBox.Show(ex.ToString(), "New Budget", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            else
            {
                MessageBox.Show("Please use the requested file extension (bak).");
            }

            if (successfulFileCreation)
            {
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
        }

        /// <summary>
        /// Initiates the load existing budget database process.
        /// </summary>
        private void loadBudgetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool succesfulFileLoad = false;

            MessageBox.Show("Select the backup budget file you would like to open.");
            if (openFileDialog1.ShowDialog() == DialogResult.OK && Path.GetExtension(openFileDialog1.FileName) == ".bak")
            {
                try
                {
                    LoadBudgetFile(openFileDialog1.FileName, budget);                    
                    succesfulFileLoad = true;
                    budget = new BudgetDB(openFileDialog1.FileName);                    
                    MessageBox.Show("Database file loaded", "Load Budget", MessageBoxButtons.OK, MessageBoxIcon.Information);                    
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString(), "Load Budget", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } 
            }
            else
            {
                MessageBox.Show("Please select an appropriate file to open.");
            }

            //Including an account count check, as it's possible for someone to close the program post DB file save but without completing the account generation process.
            if (succesfulFileLoad)
            {
                if (budget.GetAccountCount() == 0)
                {
                    while(!InitialAccountCreation())
                    {
                        //Keep looping here until the user creates an account.
                    }
                }

                //Fill the dgvs
                FillDGVS();                

                //Save to the .bak file.
                Utils.SaveCurrentBudget(budget);
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
            dgvTransactions.Columns[6].DefaultCellStyle.Format = "c";
            dgvTransactions.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            
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
            budget.PushToDBandBackup();
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

        //TODO: Implement export feature.
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (budget != null)
            {
                throw new NotImplementedException(); 
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
    }
}
