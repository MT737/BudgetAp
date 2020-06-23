using BudgetAp.BudgetClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static BudgetAp.DatabaseInsertsAndMods;

namespace BudgetAp
{
    public partial class DisplayCategoriesManager : Form
    {
        private BudgetDB _budget;
        private List<string> _displayedCategories;
        private List<string> _notDisplayedCategories;

        public DisplayCategoriesManager(BudgetDB budget)
        {
            InitializeComponent();
            _budget = budget;

            //Fill display lists.
            _displayedCategories = _budget.GetCategoryListByDisplay(true);
            _notDisplayedCategories = _budget.GetCategoryListByDisplay(false);

            //Load the display list boxes
            RefreshDisplayListBoxes();
        }

        /// <summary>
        /// Refreshes the displayed/not-displayed category lists.
        /// </summary>
        private void RefreshDisplayListBoxes()
        {
            //TODO: Refactor this. There must be a better way to handle these collections.

            //Clear listboxes
            lstbxDisplayedCategories.Items.Clear();
            lstbxNotDisplayedCategories.Items.Clear();

            //Refill displayed list box.
            foreach (string cat in _displayedCategories)
            {
                lstbxDisplayedCategories.Items.Add(cat);
            }

            //Refill not displayed list box.
            foreach (string cat in _notDisplayedCategories)
            {
                lstbxNotDisplayedCategories.Items.Add(cat);
            }
        }

        /// <summary>
        /// Moves all items from the not displayed list box (and list) to the displayed list box (and list).
        /// </summary>
        private void btnMoveAllToDisplayedList_Click(object sender, EventArgs e)
        {
            foreach (string category in _notDisplayedCategories)
            {
                _displayedCategories.Add(category);
                _notDisplayedCategories.Remove(category);
            }
            RefreshDisplayListBoxes();
        }

        //TODO: insert XML documentation.
        private void btnMoveSelectedToDisplayedList_Click(object sender, EventArgs e)
        {
            if (!(lstbxNotDisplayedCategories.SelectedIndex == -1))
            {
                _displayedCategories.Add(lstbxNotDisplayedCategories.SelectedItem.ToString());
                _notDisplayedCategories.Remove(lstbxNotDisplayedCategories.SelectedItem.ToString());
                RefreshDisplayListBoxes();  
            }
            else
            {
                MessageBox.Show("No 'Not Displayed' category selected.");
            }
           
        }

        private void btnMoveSelectedToNotDisplayedList_Click(object sender, EventArgs e)
        {
            if (!(lstbxDisplayedCategories.SelectedIndex == -1))
            {
                _notDisplayedCategories.Add(lstbxDisplayedCategories.SelectedItem.ToString());
                _displayedCategories.Remove(lstbxDisplayedCategories.SelectedItem.ToString());
                RefreshDisplayListBoxes(); 
            }
            else
            {
                MessageBox.Show("No 'Displayed' category selected.");
            }
        }

        private void btnMoveAllToNotDisplayedList_Click(object sender, EventArgs e)
        {
            foreach (string category in _displayedCategories)
            {
                _notDisplayedCategories.Add(category);
                _displayedCategories.Remove(category);
            }
            RefreshDisplayListBoxes();
        }

        private void btnFinished_Click(object sender, EventArgs e)
        {
            foreach (string cat in _displayedCategories)
            {
                ModifyCategoryDisplayStatus(_budget.GetCategoryTable(), cat, true);
            }
            foreach (string cat in _notDisplayedCategories)
            {
                ModifyCategoryDisplayStatus(_budget.GetCategoryTable(), cat, false);
            }

            _budget.PushToDBandBackup();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
