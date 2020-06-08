using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BudgetAp.BudgetClasses;
using static BudgetAp.Utils;
using static BudgetAp.DatabaseInsertsAndMods;
using System.Data.Linq;
using BudgetAp.BudgetClasses.HelperBudgetClasses;

namespace BudgetAp
{
    public partial class TransactionManager : Form
    {   
        //TODO: clean up how transaction date is displayed in the dgv

        private BudgetDB _budget;
        private int _transID;
        private bool _isModification;

        public TransactionManager(bool isModification, int transID, BudgetDB budget)
        {
            InitializeComponent();
            _budget = budget;
            _transID = transID;
            _isModification = isModification;

            //Prep the fields.
            PrepTransactionManagerFields(isModification);
        }

        private void PrepTransactionManagerFields(bool isModification)
        {
            _budget.LoadTransactionsComboBoxes(cmbxTransType, cmbxAccount, cmbxTransferAccounts, cmbxCategory, cmbxVendor);
            ClearSelections();

            if (isModification)
            {
                //Hide transfer items. Currently not allowing modification of transfer accounts.
                chckbxTransfer.Hide();
                lblAccountTransfer.Hide();
                lblTransferAccount.Hide();
                cmbxTransferAccounts.Hide();

                //Hide the AddTransaction button and show the update transaction button.
                btnAddTransaction.Hide();
                btnUpdateTransaction.Show();

                //Set selections to transaction details.
                _budget.LoadTransaction(_transID, cmbxTransType, cmbxAccount, cmbxCategory, cmbxVendor, txtbxAmount, dateTimePicker1, txtbxDescription);
            }
            else
            {
                //Show the add transaction button and hide the update transaction button.
                btnAddTransaction.Show();
                btnUpdateTransaction.Hide();
            }
        }

        private void ClearSelections()
        {
            //Set combobox index to -1
            List<ComboBox> comboBoxes = new List<ComboBox> {cmbxTransType, cmbxAccount, cmbxTransferAccounts, cmbxCategory, cmbxVendor };
            foreach (ComboBox box in comboBoxes)
            {
                box.SelectedIndex = -1;
            }

            //Set text to ""
            txtbxAmount.Text = "";
            txtbxDescription.Text = "";

            //Set date
            dateTimePicker1.Value = DateTime.Now;
        }

        private void btnAddTransaction_Click(object sender, EventArgs e)
        {
            if (ComboBoxesCompleted())
            {
                if (AmountCompleted())
                {
                    if (IsTransfer())
                    {
                        if (TransferAccountSelected() && AccountsAreNotTheSame())
                        {
                            //First 1/2 of transfer
                            InsertTransaction(_budget.GetTransactionsTable(), dateTimePicker1.Value, _budget.GetAccountID(cmbxAccount.SelectedItem.ToString()), cmbxTransType.SelectedItem.ToString(),
                            _budget.GetCategoryID(cmbxCategory.SelectedItem.ToString()), _budget.GetVendorID(cmbxVendor.SelectedItem.ToString()), decimal.Parse(txtbxAmount.Text), $"Transfer Transaction: {txtbxDescription.Text}");

                            //Second 1/2 of transfer
                            InsertTransaction(_budget.GetTransactionsTable(), dateTimePicker1.Value, _budget.GetAccountID(cmbxTransferAccounts.SelectedItem.ToString()), OppositeTransType(),
                            _budget.GetCategoryID(cmbxCategory.SelectedItem.ToString()), _budget.GetVendorID(cmbxVendor.SelectedItem.ToString()), decimal.Parse(txtbxAmount.Text), $"Transfer Transaction: {txtbxDescription.Text}");

                            _budget.PushToDBandBackup();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Must selected a transfer account when creating a transfer transaction. Account and Transfer Account cannot be the same.");
                        }
                    }
                    else                    
                    {
                        InsertTransaction(_budget.GetTransactionsTable(), dateTimePicker1.Value, _budget.GetAccountID(cmbxAccount.SelectedItem.ToString()), cmbxTransType.SelectedItem.ToString(),
                            _budget.GetCategoryID(cmbxCategory.SelectedItem.ToString()), _budget.GetVendorID(cmbxVendor.SelectedItem.ToString()), decimal.Parse(txtbxAmount.Text), txtbxDescription.Text);

                        _budget.PushToDBandBackup();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a transaction ammount not entered.");
                }
            }
            else 
            {
                MessageBox.Show("Not all input fields completed. Please select transaction type, category, and vendor.");
            }
        }

        /// <summary>
        /// Close the transaction manager.
        /// </summary>
        private void btnCancelTransaction_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool AccountsAreNotTheSame()
        {
            return cmbxAccount.SelectedIndex != cmbxTransferAccounts.SelectedIndex;
        }

        private bool IsTransfer()
        {
            return chckbxTransfer.Checked;
        }

        private bool ComboBoxesCompleted()
        {
            return cmbxTransType.SelectedIndex != -1 && cmbxAccount.SelectedIndex != -1 && cmbxCategory.SelectedIndex != -1 && cmbxVendor.SelectedIndex != -1;
        }

        private bool TransferAccountSelected()
        {
            return cmbxTransferAccounts.SelectedIndex != -1;
        }

        private bool AmountCompleted()
        {
            return txtbxAmount.Text != "";
        }

        //TODO: Description box validator? LinqToSQL parameterizes (sp?) all inputs, so there should be no need to worry about sql injection attacks from users fooling around with the description field
        //but, this could be a best practice.

        private void btnCategoryManager_Click(object sender, EventArgs e)
        {
            EditSelection oForm = new EditSelection(_budget, "Category");
            oForm.ShowDialog();  //Using showdialog so that the calling form pauses while the AccountManager is open.
            oForm = null;

            PrepTransactionManagerFields(_isModification);
        }

        private void btnVendorManager_Click(object sender, EventArgs e)
        {
            EditSelection oForm = new EditSelection(_budget, "Vendor");
            oForm.ShowDialog();  //Using showdialog so that the calling form pauses while the AccountManager is open.
            oForm = null;

            PrepTransactionManagerFields(_isModification);
        }

        private void btnAccountManager_Click(object sender, EventArgs e)
        {            
            AccountManager oForm = new AccountManager(_budget);
            oForm.ShowDialog();  //Using showdialog so that the main form pauses while the AccountManager is open.
            oForm = null;

            PrepTransactionManagerFields(_isModification);
        }

        /// <summary>
        /// Calls the Validate Currency Inputs method.
        /// </summary>
        private void txtbxAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateCurrencyInputs(e);
        }

        private void chckbxTransfer_CheckedChanged(object sender, EventArgs e)
        {
            if (chckbxTransfer.Checked)
            {
                //Disable category and vendor comboboxes and set the selected indexes to those appropriate for a transfer.
                cmbxCategory.Enabled = false;
                cmbxVendor.Enabled = false;
                cmbxCategory.SelectedIndex = cmbxCategory.FindStringExact("Account Balance Transfer");
                cmbxVendor.SelectedIndex = cmbxVendor.FindStringExact("N/A");
            }
            else
            {
                //Enable category and vendor comboboxes and set the selected indexes to -1.
                cmbxCategory.Enabled = true;
                cmbxVendor.Enabled = true;
                cmbxCategory.SelectedIndex = -1;
                cmbxVendor.SelectedIndex = -1;
            }
        }

        private string OppositeTransType()
        {            
            if (cmbxTransType.SelectedItem.ToString() == "Payment To")
            {
                return "Payment From";
            }
            else
            {
                return "Payment To";
            }
        }

        private void btnUpdateTransaction_Click(object sender, EventArgs e)              
        {
           ModifyTransaction(_budget.GetTransactionsTable(), _transID, dateTimePicker1.Value, _budget.GetAccountID(cmbxAccount.SelectedItem.ToString()), cmbxTransType.SelectedItem.ToString(),
                            _budget.GetCategoryID(cmbxCategory.SelectedItem.ToString()), _budget.GetVendorID(cmbxVendor.SelectedItem.ToString()), decimal.Parse(txtbxAmount.Text), txtbxDescription.Text);

            _budget.PushToDBandBackup();
            //TODO: Check for actual change. Currently taking the user at their word that a value has changed.  
        }
    }
}
