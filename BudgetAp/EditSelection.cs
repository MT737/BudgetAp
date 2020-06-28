using BudgetAp.BudgetClasses;
using System;
using System.Windows.Forms;
using static BudgetAp.DatabaseInsertsAndMods;

namespace BudgetAp
{
    public partial class EditSelection : Form
    {
        private string _catOrVend;
        private BudgetDB _budget;

        /// <summary>
        /// EditSelection class constructor.
        /// </summary>
        /// <param name="budget">BudgetDB object: the budget DB for the budget currently accessed by the program.</param>
        /// <param name="catOrVend">String: text declaring the type.</param>
        public EditSelection(BudgetDB budget, string catOrVend)
        {
            InitializeComponent();
            _catOrVend = catOrVend;
            _budget = budget;

            //TODO: update the text in the form to represent Vendor or Category.
            PrepFieldsAndFillDGV(_catOrVend);          
        }

        /// <summary>
        /// Closes the EditSelection form.
        /// </summary>
        private void btnFinished_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Prompts the process to validate and add the entry.
        /// </summary>
        private void btnAddEntry_Click(object sender, EventArgs e)
        {
            if (txtbxNewEntry.Text != "" && !_budget.EntryNameExists(_catOrVend, txtbxNewEntry.Text))
            {
                if (_catOrVend == "Category")
                {
                    AddCategory(_budget.GetCategoryTable(), txtbxNewEntry.Text, false, true);
                    _budget.PushToDBandBackup();

                    PrepFieldsAndFillDGV(_catOrVend);
                }
                else
                {
                    AddVendor(_budget.GetVendorTable(), txtbxNewEntry.Text, false);
                    _budget.PushToDBandBackup();

                    PrepFieldsAndFillDGV(_catOrVend);
                }
            }
            else
            {
                MessageBox.Show("Please enter a new name before submitting.");
            }        
        }

        /// <summary>
        /// Prompts the process to clear form fields and fill the dgvSelectionList data grid view.
        /// </summary>
        private void PrepFieldsAndFillDGV(string catOrVend)
        {        
            txtbxNewEntry.Text = "";
           
            _budget.FillEditSelectionDGV(dgvSelectionList, _catOrVend);
             
            dgvSelectionList.Columns[0].Visible = false;
            if (catOrVend == "Category")
            {
                chckbxNewDisplaySpendByMonth.Visible = true;
                _budget.ReLoadComboBox(cmbxAbsorbingEntry, "Category");
            }
            else
            {
                chckbxNewDisplaySpendByMonth.Visible = false;
                _budget.ReLoadComboBox(cmbxAbsorbingEntry, "Vendor");
            }
        }

        /// <summary>
        /// Prompts the process to validate and update an entry.
        /// </summary>
        private void btnUpdateEntry_Click(object sender, EventArgs e)
        {
            if (txtbxUpdatedEntry.Text != "" && txtbxSelectedEntry.Text != txtbxUpdatedEntry.Text)
            {
                if (!_budget.NameExistsAsDefault(_catOrVend, txtbxSelectedEntry.Text) && !_budget.NameExistsAsDefault(_catOrVend, txtbxUpdatedEntry.Text))
                {
                    if (_catOrVend == "Category")
                    {
                        ModifyCategory(_budget.GetCategoryTable(), _budget.GetCategoryID(txtbxSelectedEntry.Text), txtbxUpdatedEntry.Text);
                    }
                    else
                    {
                        ModifyVendor(_budget.GetVendorTable(), _budget.GetVendorID(txtbxSelectedEntry.Text), txtbxUpdatedEntry.Text);
                    }
                    _budget.PushToDBandBackup();
                    PrepFieldsAndFillDGV(_catOrVend); 
                }
                else
                {
                    MessageBox.Show("Cannot modify default entries.");
                }
            }            
            else
            {
                MessageBox.Show("Please enter a valid name.");
            }
        }

        /// <summary>
        /// Prompts the process to set all transactions with the deleted entry ID to the absorbing entry ID and remove the deleted entry from the relevant entry table (Category/Vendor).
        /// </summary>
        private void btnDeleteEntry_Click(object sender, EventArgs e)
        {
            //Get IDs
            int toDeleteID = 0;
            int toAbsorbID = 0;
            if (_catOrVend == "Category")
            {
                toDeleteID = _budget.GetCategoryID(txtbxSelectedEntryToDelete.Text.ToString());
                toAbsorbID = _budget.GetCategoryID(cmbxAbsorbingEntry.Text.ToString());
            }
            else
            {
                toDeleteID = _budget.GetVendorID(txtbxSelectedEntryToDelete.Text.ToString());
                toAbsorbID = _budget.GetVendorID(cmbxAbsorbingEntry.Text.ToString());
            }

            //Validate the inputs
            //Check that the entity to be deleted is not identical to the absorbing entity and check that the entity to be deleted is not a default entity.
            if (toDeleteID != toAbsorbID && !_budget.IsDefault(_catOrVend, txtbxSelectedEntry.Text.ToString()))
            {
                //Modify the transactions table
                ModifyTransaction(_budget.GetTransactionsTable(), toDeleteID, toAbsorbID, _catOrVend);

                //Modify the entry table                
                DeleteEntry(_budget, _catOrVend, toDeleteID);

                //Submit changes
                _budget.PushToDBandBackup();

                //Refill DGV and CmbBx
                PrepFieldsAndFillDGV(_catOrVend);
            }
            else
            {
                MessageBox.Show("Selected entry to delete and selected entry to absorb cannot be the same and the selected entry cannot be a default entry.");
            }
        }

        /// <summary>
        /// Fills the text value of the txtbxSelectedEntry based on the selected row of the dgvSelectionList.
        /// </summary>
        private void dgvSelectionList_SelectionChanged(object sender, EventArgs e)
        {
            txtbxSelectedEntry.Text = dgvSelectionList.CurrentRow.Cells[1].Value.ToString();
            txtbxSelectedEntryToDelete.Text = dgvSelectionList.CurrentRow.Cells[1].Value.ToString();
        }
    }
}
