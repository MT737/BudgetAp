using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BudgetAp.BudgetClasses;
using static BudgetAp.DatabaseInsertsAndMods;

namespace BudgetAp
{
    public partial class EditSelection : Form
    {
        private string _catOrVend;
        private BudgetDB _budget;

        public EditSelection(BudgetDB budget, string catOrVend)
        {
            InitializeComponent();
            _catOrVend = catOrVend;
            _budget = budget;

            //TODO: update the text in the form to represent Vendor or Category.
            PrepFieldsAndFillDGV();          
        }

        private void btnFinished_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddEntry_Click(object sender, EventArgs e)
        {
            if (txtbxNewEntry.Text != "" && !_budget.NameExists(_catOrVend, txtbxNewEntry.Text))
            {
                if (_catOrVend == "Category")
                {
                    AddCategory(_budget.GetCategoryTable(), txtbxNewEntry.Text, false);
                    _budget.PushToDBandBackup();

                    PrepFieldsAndFillDGV();
                }
                else
                {
                    AddVendor(_budget.GetVendorTable(), txtbxNewEntry.Text, false);
                    _budget.PushToDBandBackup();

                    PrepFieldsAndFillDGV();
                }
            }
            else
            {
                MessageBox.Show("Please enter a new name before submitting.");
            }        
        }

        private void PrepFieldsAndFillDGV()
        {        
            txtbxNewEntry.Text = "";
            _budget.FillEditSelectionDGV(dgvSelectionList, _catOrVend);
            dgvSelectionList.Columns[0].Visible = false;
        }

        private void btnUpdateEntry_Click(object sender, EventArgs e)
        {

            //TODO: Error with edit selection. It's possible to create a new vendor with the name of a default member. Modification then errors out!
            if ((bool)dgvSelectionList.CurrentRow.Cells[2].Value != true && txtbxUpdatedEntry.Text != "" && txtbxSelectedEntry.Text != txtbxUpdatedEntry.Text)
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
                PrepFieldsAndFillDGV();
            }            
            else
            {
                MessageBox.Show("Please enter a valid name.");
            }
        }

        private void dgvSelectionList_SelectionChanged(object sender, EventArgs e)
        {
            txtbxSelectedEntry.Text = dgvSelectionList.CurrentRow.Cells[1].Value.ToString();
        }
    }
}
