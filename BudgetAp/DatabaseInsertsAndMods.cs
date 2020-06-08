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

        public static void ModifyVendor(Table<Vendor> vendorTable, int vendorID, string updatedVendorName)
        {
            IQueryable<Vendor> modifyVendorQuery =
               from vends in vendorTable
               where vends.VendorID == vendorID
               select vends;

            foreach (Vendor vend in modifyVendorQuery)
            {
                vend.Name = updatedVendorName;                
            }
        }

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

        public static void ModifyCategory(Table<Category> categoryTable, int categoryID, string updatedCategoryName)
        {
            IQueryable<Category> modifyCategoryQuery =
               from cats in categoryTable
               where cats.CategoryID == categoryID
               select cats;

            foreach (Category cats in modifyCategoryQuery)
            {
                cats.Name = updatedCategoryName;
            }
        }


        //TODO: write xml description.
        public static void AddAccount(Table<Account> accounts, string name, bool isAsset, bool isActive)
        {
            Account newAccount = new Account();
            newAccount.Name = name;
            newAccount.IsAsset = isAsset;
            newAccount.IsActive = isActive;
            accounts.InsertOnSubmit(newAccount);
        }

        //TODO: write xml description.
        public static void ModifyAccount(Table<Account> accounts, int selectedAccountID, string updatedAccountName, bool UpdatedAccountIsAsset, bool UpdatedAccountIsActive)
        {        
            IQueryable<Account> accountQuery =
                from acct in accounts
                where acct.AccountID == selectedAccountID
                select acct;

            foreach (Account acct in accountQuery)
            {
                acct.Name = updatedAccountName;
                acct.IsAsset = UpdatedAccountIsAsset;
                acct.IsActive = UpdatedAccountIsActive;
            }            
        }

        public static void ModifyTransaction(Table<Transactions> transactions, int selectedTransactionID, DateTime date, int accountID, string transType, int categoryID
            , int vendorID, decimal amount, string description)
        {
            IQueryable<Transactions> transactionsModificationQuery =
                from trans in transactions
                where trans.TransactionID == selectedTransactionID
                select trans;

            foreach (Transactions trans in transactionsModificationQuery)
            {
                trans.TransactionDate = date;
                trans.AccountID = accountID;
                trans.TransactionType = transType;
                trans.CategoryID = categoryID;
                trans.VendorID = vendorID;
                trans.Amount = amount;
                trans.Description = description;
            }
        }

        public static void DeleteTransaction(Table<Transactions> transactions, int selectedTransactionID)
        {
            var deleteTransactionQuery =
                from trans in transactions
                where trans.TransactionID == selectedTransactionID
                select trans;

            foreach (var trans in deleteTransactionQuery)
            {
                transactions.DeleteOnSubmit(trans);
            }
        }
    }
}
