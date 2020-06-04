using BudgetAp.BudgetClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
using System.Windows.Forms;

namespace BudgetAp
{
    public static class DatabaseInsertsAndMods
    {
        //TODO: method for inserting a new transaction.
        public static void InsertTransaction(Table<Transactions> transactionsTable, DateTime transactionDate, int accountID, string transType, int categoryID, int vendorID, decimal amount, string description)
        {
            Transactions newTransaction = new Transactions();
            newTransaction.TransactionDate = transactionDate;
            newTransaction.AccountID = accountID;
            newTransaction.TransactionType = transType;
            newTransaction.CategoryID = categoryID;
            newTransaction.VendorID = vendorID;
            newTransaction.Amount = amount;
            newTransaction.Description = description;
            transactionsTable.InsertOnSubmit(newTransaction);
        }

        //TODO: method for deleting a transaction.
        //public static void DeleteTransaction()
        //{

        //}

        //TODO: As I will be using this for user adds, I need to check for current existence of said vendor. 
        /// <summary>
        /// Adds a vendor to the vendor table object and instructs the table object to insert the data to the DB table on DB object submit.
        /// </summary>
        /// <param name="vendorTable">Database Table Object: The Vendor database object.</param>
        /// <param name="name">String: the name of the new vendor.</param>
        /// <param name="isDefault">Bool: indicator of default statis.</param>
        public static void AddVendor(Table<Vendor> vendorTable, string name, bool isDefault)
        {
            Vendor newVendor = new Vendor();
            newVendor.Name = name;
            newVendor.IsDefault = isDefault;
            vendorTable.InsertOnSubmit(newVendor);
        }

        //TODO: method for modifying a vendor.
        //public static void ModifyVendor()
        //{

        //}


        //TODO: As I will be using this for user adds, I need to check for current existence of said category. 
        /// <summary>
        /// Adds a category to the category table object and instructs the table object to insert the data to the DB table on DB object submit.
        /// </summary>
        /// <param name="categoryTable">Database Table Object: The Category database object.</param>
        /// <param name="name">String: the name of the new category.</param>
        /// <param name="isDefault">Bool: indicator of default statis.</param>
        public static void AddCategory(Table<Category> categoryTable, string name, bool isDefault)
        {
            Category newCategory = new Category();
            newCategory.Name = name;
            newCategory.IsDefault = isDefault;
            categoryTable.InsertOnSubmit(newCategory);
        }


        //TODO: method for adding an account.
        public static void AddAccount(Table<Account> accounts, string name, bool isAsset, bool isActive)
        {
            Account newAccount = new Account();
            newAccount.Name = name;
            newAccount.IsAsset = isAsset;
            newAccount.IsActive = isActive;
            accounts.InsertOnSubmit(newAccount);
        }

        //TODO: method for modifying an account.
        //public static void ModifyAccount()
        //{

        //}
    }
}
