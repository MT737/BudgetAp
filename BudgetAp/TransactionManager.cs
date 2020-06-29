using BudgetAp.BudgetClasses;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Markup;
using static BudgetAp.DatabaseInsertsAndMods;
using static BudgetAp.Utils;

namespace BudgetAp
{
    public partial class TransactionManager : Form
    {   
        //TODO: clean up how transaction date is displayed in the dgv

        private BudgetDB _budget;
        private int _transID;

        //Constructor
        public TransactionManager(bool isModification, int transID, BudgetDB budget)
        {
            InitializeComponent();
            _budget = budget;
            _transID = transID;

            //Prep the fields.
            PrepTransactionManagerFields(isModification);
        }

        /// <summary>
        /// Loads form comboboxes and clears all selections. Shows/Hides the AddTransaction and UpdateTransaction buttons based on isModification.
        /// </summary>
        /// <param name="isModification"></param>
        private void PrepTransactionManagerFields(bool isModification)
        {
            _budget.LoadAllTransactionsComboBoxes(cmbxTransType, cmbxAccount, cmbxTransferAccounts, cmbxCategory, cmbxVendor);
            ClearSelections();

            //Check if this is an add transaction or modify transaction instance of the form.
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

                //Hide the transfer lable and combobox by default. (selection handled in event handler below will make visible/hide)
                lblAccountTransfer.Visible = false;
                cmbxTransferAccounts.Visible = false;
            }
        }

        /// <summary>
        /// Set's comboboxes selected indexes to -1, textboxes to empty strings, and datetimepicker to now.
        /// </summary>
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
            dateTimePicker1.Value = DateTime.Now.Date;
        }

        /// <summary>
        /// Validates inputs and inserts transaction. Accounts for transfer account as well.
        /// </summary>
        private void btnAddTransaction_Click(object sender, EventArgs e)
        {
            //TODO: Clean up this If tree.
            //Check that the user has interacted with the comboboxes.
            if (ComboBoxesCompleted())
            {
                //Check that the user has entered an amount value.
                if (AmountCompleted())
                {
                    //Check if this is transfer transaction.
                    if (IsTransfer())
                    {
                        //Check that the transfer account has been selected and is not the same as the main account.
                        if (TransferAccountSelected() && AccountsAreNotTheSame())
                        {
                            //Transfer transactions consist of two transactions.

                            //First 1/2 of transfer
                            InsertTransaction(_budget.GetTransactionsTable(), dateTimePicker1.Value.Date, _budget.GetAccountID(cmbxAccount.SelectedItem.ToString()), cmbxTransType.SelectedItem.ToString(),
                            _budget.GetCategoryID(cmbxCategory.SelectedItem.ToString()), _budget.GetVendorID(cmbxVendor.SelectedItem.ToString()), decimal.Parse(txtbxAmount.Text), $"Transfer Transaction: {txtbxDescription.Text}");

                            //Second 1/2 of transfer
                            InsertTransaction(_budget.GetTransactionsTable(), dateTimePicker1.Value.Date, _budget.GetAccountID(cmbxTransferAccounts.SelectedItem.ToString()), OppositeTransType(),
                            _budget.GetCategoryID(cmbxCategory.SelectedItem.ToString()), _budget.GetVendorID(cmbxVendor.SelectedItem.ToString()), decimal.Parse(txtbxAmount.Text), $"Transfer Transaction: {txtbxDescription.Text}");

                            //Push the transaction to the DB and then backup.
                            _budget.PushToDBandBackup();
                            this.Close();
                        }
                        else
                        {
                            //Alert the user to select a transfer account.
                            MessageBox.Show("Must selected a transfer account when creating a transfer transaction. Account and Transfer Account cannot be the same.");
                        }
                    }
                    else                    
                    {
                        //Insert transaction
                        InsertTransaction(_budget.GetTransactionsTable(), dateTimePicker1.Value.Date, _budget.GetAccountID(cmbxAccount.SelectedItem.ToString()), cmbxTransType.SelectedItem.ToString(),
                            _budget.GetCategoryID(cmbxCategory.SelectedItem.ToString()), _budget.GetVendorID(cmbxVendor.SelectedItem.ToString()), decimal.Parse(txtbxAmount.Text), txtbxDescription.Text);

                        //Push the transaction to the DB and then backup.
                        _budget.PushToDBandBackup();
                        this.Close();
                    }
                }
                else
                {
                    //Alert the user to enter a transaction amount.
                    MessageBox.Show("Please enter a transaction ammount not entered.");
                }
            }
            else 
            {
                //Alert the user to finish completing the form.
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

        /// <summary>
        /// Evaluates if the selected account and selected transfer account are the same.
        /// </summary>
        /// <returns>Bool: true if the selected account and selected trasnfer account are not the same.</returns>
        private bool AccountsAreNotTheSame()
        {
            //Compare the selected indexes of the transfer account and primary account comboboxes.
            return cmbxAccount.SelectedIndex != cmbxTransferAccounts.SelectedIndex;
        }

        /// <summary>
        /// Evaluates if the transfer checkbox is checked.
        /// </summary>
        /// <returns>Bool: True if the transfers checkbox is checked.</returns>
        private bool IsTransfer()
        {

            return chckbxTransfer.Checked;
        }

        /// <summary>
        /// Evaluates if the user has utilized the transaction menu's comboboxes to select entities.
        /// </summary>
        /// <returns>Bool: returns true if all comboboxes have been utilized.</returns>
        private bool ComboBoxesCompleted()
        {            
            return cmbxTransType.SelectedIndex != -1 && cmbxAccount.SelectedIndex != -1 && cmbxCategory.SelectedIndex != -1 && cmbxVendor.SelectedIndex != -1;
        }

        /// <summary>
        /// Evaluates if the transfer account combobox has been utilized by the user.
        /// </summary>
        /// <returns>Bool: returns true if the transfer account combobox has been utilized.</returns>
        private bool TransferAccountSelected()
        {
            return cmbxTransferAccounts.SelectedIndex != -1;
        }

        /// <summary>
        /// Evaluates if the user has input a value in the Amount textbox.
        /// </summary>
        /// <returns></returns>
        private bool AmountCompleted()
        {
            return txtbxAmount.Text != "";
        }

        /// <summary>
        /// Opens an EditSelection form and passes the the budget object and a string indicating that the type is Category.
        /// </summary>
        private void btnCategoryManager_Click(object sender, EventArgs e)
        {
            EditSelection oForm = new EditSelection(_budget, "Category");
            oForm.StartPosition = FormStartPosition.CenterParent;
            oForm.ShowDialog();  //Using showdialog so that the calling form pauses while the AccountManager is open.
            oForm = null;

            //replace this with a method that loads a single combobox
            _budget.ReLoadComboBox(cmbxCategory, "Category");
        }

        /// <summary>
        /// Opens an EditSelection form and passes the the budget object and a string indicating that the type is Vendor.
        /// </summary>
        private void btnVendorManager_Click(object sender, EventArgs e)
        {
            EditSelection oForm = new EditSelection(_budget, "Vendor");
            oForm.StartPosition = FormStartPosition.CenterParent;
            oForm.ShowDialog();  //Using showdialog so that the calling form pauses while the AccountManager is open.
            oForm = null;

            _budget.ReLoadComboBox(cmbxVendor, "Vendor");
        }

        /// <summary>
        /// Opends the account manager form and passes the budget object.
        /// </summary>
        private void btnAccountManager_Click(object sender, EventArgs e)
        {            
            AccountManager oForm = new AccountManager(_budget);
            oForm.StartPosition = FormStartPosition.CenterParent;
            oForm.ShowDialog();  //Using showdialog so that the main form pauses while the AccountManager is open.
            oForm = null;

            _budget.ReLoadComboBox(cmbxAccount, "Account");
            _budget.ReLoadComboBox(cmbxTransferAccounts, "Account");
        }

        /// <summary>
        /// Calls the Validate Currency Inputs method on keypresses inside the amount textbox control.
        /// </summary>
        private void txtbxAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateCurrencyInputs(e);
        }

        /// <summary>
        /// Called when the transfers checkbox is checked. Disables or enables category and vendor controls based on the checkboxes status.
        /// </summary>
        private void chckbxTransfer_CheckedChanged(object sender, EventArgs e)
        {
            if (chckbxTransfer.Checked)
            {
                //Disable category and vendor comboboxes and set the selected indexes to those appropriate for a transfer.
                cmbxCategory.Enabled = false;
                cmbxVendor.Enabled = false;
                cmbxCategory.SelectedIndex = cmbxCategory.FindStringExact("Account Balance Transfer");
                cmbxVendor.SelectedIndex = cmbxVendor.FindStringExact("N/A");
                cmbxTransferAccounts.Visible = true;
                lblAccountTransfer.Visible = true;
            }
            else
            {
                //Enable category and vendor comboboxes and set the selected indexes to -1.
                cmbxCategory.Enabled = true;
                cmbxVendor.Enabled = true;
                cmbxCategory.SelectedIndex = -1;
                cmbxVendor.SelectedIndex = -1;
                cmbxTransferAccounts.Visible = false;
                lblAccountTransfer.Visible = false;
            }
        }

        /// <summary>
        /// Returns the opposite transaction type based on the Transaction Type comboboxes current setting.
        /// </summary>
        /// <returns>String: returns "Payment From" if the Transaction type combobox is "Payment To". Otherwise returns "Payment From".</returns>
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

        /// <summary>
        /// Modifies the values in the transactions table of the budget object, pushes the changes to the DataBase, and backs up the .bak file.
        /// </summary>
        private void btnUpdateTransaction_Click(object sender, EventArgs e)              
        {
            //TODO: Check for actual change. Currently taking the user at their word that a value has changed.  
            ModifyTransaction(_budget.GetTransactionsTable(), _transID, dateTimePicker1.Value, _budget.GetAccountID(cmbxAccount.SelectedItem.ToString()), cmbxTransType.SelectedItem.ToString(),
                            _budget.GetCategoryID(cmbxCategory.SelectedItem.ToString()), _budget.GetVendorID(cmbxVendor.SelectedItem.ToString()), decimal.Parse(txtbxAmount.Text), txtbxDescription.Text);
                        
            //Push the transaction to the DB and then backup.
            _budget.PushToDBandBackup();
            this.Close();
        }
    }
}
