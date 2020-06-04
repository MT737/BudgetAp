using BudgetAp.BudgetClasses;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
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

        //New Budget Selection
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

        //Load Budget Selection
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

        private void FillDGVS()
        {
            //Account Overview
            budget.FillAccountDGV(dgvAccountOverview);
            dgvAccountOverview.Columns[0].Visible = false;              //Don't show AccountID
            dgvAccountOverview.Columns[3].Visible = false;              //Don't show AccountStatus
            HideInactive(dgvAccountOverview);                           //Don't show inactive accounts
            
            //Transactions
            budget.FillTransactionsDGV(dgvTransactions);
            dgvTransactions.Columns[0].Visible = false;                 //Don't show TransactionsID
            
            //Spending by Category            
            budget.FillSpendingByCategory(dgvSpendingByCategory);
            dgvSpendingByCategory.Columns[0].Visible = false;
        }

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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnCategoryManager_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnAccountManager_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnNewTransaction_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnDeleteTransaction_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnEditTransaction_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void saveBudgetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Save to the .bak file.
            Utils.SaveCurrentBudget(budget);
        }
    }
}
