using BudgetAp.BudgetClasses;
using System;
using System.Windows.Forms;
using static BudgetAp.Utils;

namespace BudgetAp
{
    public partial class AccountManager : Form
    {
        private BudgetDB _budget;
        
        //Constructor
        public AccountManager(BudgetDB budget)
        {
            InitializeComponent();
            _budget = budget;
            LoadAccountsDGV();
        }

        /// <summary>
        /// Fills the account DataGridView.
        /// </summary>
        private void LoadAccountsDGV()
        {
            //Only load if account count is > 0 (i.e., if this isn't the initial launch of account manager for a new budget).
            if (_budget.GetAccountCount() > 0)
            {
                _budget.FillAccountDGV(dgvAccounts);
                dgvAccounts.Columns[4].DefaultCellStyle.Format = "c";
                dgvAccounts.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvAccounts.Refresh();
            }
        }
        
        /// <summary>
        /// Validates user input, confirms success creation of new account, and calls the UpdateForm method.
        /// </summary>
        private void btnAddAccount_Click(object sender, EventArgs e)
        {                        
            if (!(txtbxNewAccountName.Text == "") 
                && !(txtbxNewAccountBalance.Text == "") 
                && (rdbtnNewAsset.Checked || rdbtnNewLiability.Checked) 
                && (rdbtnNewAccountActive.Checked || rdbtnNewAccountInactive.Checked))
            {
                if (_budget.IsSuccessfulNewAccount(txtbxNewAccountName.Text, decimal.Parse(txtbxNewAccountBalance.Text), rdbtnNewAsset.Checked, rdbtnNewAccountActive.Checked))
                {
                    UpdateForm();
                    _budget.PushToDBandBackup();
                }   
            }
            else
            {
                MessageBox.Show("Missing required inputs. Please make sure all New Account inputs have been properly filled.");
            }            
        }

        /// <summary>
        /// Validates user input, confirms successful account modifcation, and calls the UpdateForm method.
        /// </summary>
        private void btnUpdateAccount_Click(object sender, EventArgs e)
        {
            if (!(txtbxUpdatedAccountName.Text == "") 
                && !(txtbxUpdatedAccountBalance.Text == "") 
                && (rdbtnUpdatedAccountAsset.Checked || rdbtnUpdatedAccountLiability.Checked) 
                && (rdbtnUpdatedAccountActive.Checked || rdbtnUpdatedAccountInactive.Checked))
            {
                if (_budget.IsSuccessfulAccountModification(txtbxSelectedAccountName.Text, txtbxUpdatedAccountName.Text, decimal.Parse(txtbxUpdatedAccountBalance.Text)
                    , rdbtnUpdatedAccountAsset.Checked, rdbtnUpdatedAccountActive.Checked))
                {
                    UpdateForm();
                    _budget.PushToDBandBackup();
                }
            }
            else
            {
                MessageBox.Show("Missing required inputs. Please make sure all Updated Account inputs have been properly filled.");
            }            
        }

        /// <summary>
        /// Calls the FillAccountDGV method, calls the Refresh extension on the form, and calls the ClearInputFields method.
        /// </summary>
        private void UpdateForm()
        {
            _budget.FillAccountDGV(dgvAccounts);
            dgvAccounts.Refresh();
            ClearInputFields();
        }

        /// <summary>
        /// Clears all form input fields.
        /// </summary>
        private void ClearInputFields()
        {
            txtbxNewAccountName.Text = "";
            txtbxNewAccountBalance.Text = "";
            rdbtnNewAsset.Checked = false;
            rdbtnNewLiability.Checked = false;
            rdbtnNewAccountActive.Checked = false;
            rdbtnNewAccountInactive.Checked = false;
            txtbxUpdatedAccountName.Text = "";
            txtbxUpdatedAccountBalance.Text = "";
            rdbtnUpdatedAccountAsset.Checked = false;
            rdbtnUpdatedAccountLiability.Checked = false;
            rdbtnUpdatedAccountActive.Checked = false;
            rdbtnUpdatedAccountInactive.Checked = false;
        }

        /// <summary>
        /// Fills the selected account controls based on the row selected in the DGV.
        /// </summary>
        private void dgvAccounts_SelectionChanged(object sender, EventArgs e)
        {   
            //Pull data from the selected row.
            var cells = dgvAccounts.CurrentRow.Cells;

            //Assign the pulled data to the "Selected Account" forms.
            txtbxSelectedAccountName.Text = cells[1].Value.ToString();
            txtbxSelectedAccountBalance.Text = cells[4].Value.ToString();

            if (Convert.ToBoolean(cells[2].Value) == true)
            {
                rdbtnSelectedAccountAsset.Checked = true;
                rdbtnSelectedAccountLiability.Checked = false;
            }
            else
            {
                rdbtnSelectedAccountAsset.Checked = false;
                rdbtnSelectedAccountLiability.Checked = true;
            }

            if (Convert.ToBoolean(cells[3].Value) == true)
            {
                rdbtnSelectedAccountActive.Checked = true;
                rdbtnSelectedAccountInactive.Checked = false;
            }
            else
            {
                rdbtnSelectedAccountActive.Checked = false;
                rdbtnSelectedAccountInactive.Checked = true;
            }
        }

        /// <summary>
        /// Calls the ValidateCurrencyInputs method when a key is pressed while the NewAccountBalance control has focus.
        /// </summary>
        private void txtbxNewAccountBalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateCurrencyInputs(e);           
        }

        /// <summary>
        /// Calsl the ValidateCurrencyInputs method when a key is pressed while the UpdatedAccountBalance control has focus.
        /// </summary>
        private void txtbxUpdatedAccountBalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateCurrencyInputs(e);
        }

        /// <summary>
        /// Closes the form.
        /// </summary>
        private void btnFinished_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
