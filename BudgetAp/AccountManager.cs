using BudgetAp.BudgetClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BudgetAp.Utils;

namespace BudgetAp
{
    public partial class AccountManager : Form
    {
        private BudgetDB _budget;
        public AccountManager(BudgetDB budget)
        {
            InitializeComponent();
            _budget = budget;
            LoadAccountsDGV();
        }

        private void LoadAccountsDGV()
        {
            //Only load if account count is > 0 (i.e., if this isn't the initial launch of account manager for a new budget).
            if (_budget.GetAccountCount() > 0)
            {
                _budget.FillAccountDGV(dgvAccounts);
                dgvAccounts.Refresh();
            }
        }
        
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
                }   
            }
            else
            {
                MessageBox.Show("Missing required inputs. Please make sure all New Account inputs have been properly filled.");
            }            
        }

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
                }
            }
            else
            {
                MessageBox.Show("Missing required inputs. Please make sure all Updated Account inputs have been properly filled.");
            }            
        }

        private void UpdateForm()
        {
            _budget.FillAccountDGV(dgvAccounts);
            dgvAccounts.Refresh();
            ClearInputFields();
        }

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

        private void txtbxNewAccountBalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateCurrencyInputs(e);           
        }

        private void txtbxUpdatedAccountBalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateCurrencyInputs(e);
        }

        private void btnFinished_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
