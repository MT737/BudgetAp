using BudgetAp.BudgetClasses;
using System;
using System.Data;
using System.Data.Linq;
using System.Linq;

namespace BudgetAp
{
    public static class DatabaseInsertsAndMods
    {
        /// <summary>
        /// Inserts a new transaction into the transactions table object and implements InsertOnSubmit.
        /// </summary>
        /// <param name="transactionsTable">Transactions Table: the transactions table for the calling budget object.</param>
        /// <param name="transactionDate">DateTime: date of the transaction.</param>
        /// <param name="accountID">Int: Account ID for the account used in the transaction.</param>
        /// <param name="transType">String: Type of transaction ("Payment To" or "Payment From" the account).</param>
        /// <param name="categoryID">Int: ID value for the category under which the transaction falls.</param>
        /// <param name="vendorID">Int: ID value for the vendor associated to the transaction.</param>
        /// <param name="amount">Decimal: amount of the transaction.</param>
        /// <param name="description">String: description of the transaction.</param>
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
        /// Adds a vendor to the vendor table object and implements InsertOnSubmit.
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

        /// <summary>
        /// Modifies the name field of a specified vendor found in the calling budget's Vendor table.
        /// </summary>
        /// <param name="vendorTable">Table Vendor: the vendor table of the budget object calling the method.</param>
        /// <param name="vendorID">Int: Vendor ID of the vendor to be modified.</param>
        /// <param name="updatedVendorName">String: vendor name value to replace the current vendor name.</param>
        public static void ModifyVendor(Table<Vendor> vendorTable, int vendorID, string updatedVendorName)
        {
            IQueryable<Vendor> modifyVendorQuery =
               from vends in vendorTable
               where vends.VendorID == vendorID
               select vends;

            //TODO: add check for more than 1 result.

            foreach (Vendor vend in modifyVendorQuery)
            {
                vend.Name = updatedVendorName;                
            }
        }

        /// <summary>
        /// Adds a category to the category table object and implements InsertOnSubmit.
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

        /// <summary>
        /// Modifies the name field of a specified category found in the calling budget's Category table.
        /// </summary>
        /// <param name="categoryTable">Table Category: the category table of the budget object calling the method.</param>
        /// <param name="categoryID">Int: Category ID of the category to be modified.</param>
        /// <param name="updatedCategoryName">String: category name value to replace the current category name.</param>
        public static void ModifyCategory(Table<Category> categoryTable, int categoryID, string updatedCategoryName)
        {
            IQueryable<Category> modifyCategoryQuery =
               from cats in categoryTable
               where cats.CategoryID == categoryID
               select cats;

            //TODO: Add check for more than 1 result.

            foreach (Category cats in modifyCategoryQuery)
            {
                cats.Name = updatedCategoryName;
            }
        }

        /// <summary>
        /// Adds an account to the account table object and implements InsertOnSubmit.
        /// </summary>
        /// <param name="accounts">Table Account: the account table of the budget object calling the method.</param>
        /// <param name="name">String: Account name for the new account.</param>
        /// <param name="isAsset">Bool: indicator of account classification. True = asset, False = liability</param>
        /// <param name="isActive">Bool: indicator of account status. True = active, false = inactive.</param>
        public static void AddAccount(Table<Account> accounts, string name, bool isAsset, bool isActive)
        {
            Account newAccount = new Account();
            newAccount.Name = name;
            newAccount.IsAsset = isAsset;
            newAccount.IsActive = isActive;
            accounts.InsertOnSubmit(newAccount);
        }

        /// <summary>
        /// Modifies the fields of a specified account found in the calling budget's Account table.
        /// </summary>
        /// <param name="accounts">Table Account: the account table of the budget object calling the method.</param>
        /// <param name="selectedAccountID">Int: Account ID of the account to be modified.</param>
        /// <param name="updatedAccountName">String: account name to replace the current account name.</param>
        /// <param name="UpdatedAccountIsAsset">Bool: boolean state to replace the current IsAsset boolean state.</param>
        /// <param name="UpdatedAccountIsActive">Bool: boolean state to replace the current IsActive boolean state.</param>
        public static void ModifyAccount(Table<Account> accounts, int selectedAccountID, string updatedAccountName, bool UpdatedAccountIsAsset, bool UpdatedAccountIsActive)
        {        
            IQueryable<Account> accountQuery =
                from acct in accounts
                where acct.AccountID == selectedAccountID
                select acct;

            //TODO: add a check for more than 1 result. Shouldn't be possible at this point, but it's best to check.

            foreach (Account acct in accountQuery)
            {
                acct.Name = updatedAccountName;
                acct.IsAsset = UpdatedAccountIsAsset;
                acct.IsActive = UpdatedAccountIsActive;
            }            
        }

        /// <summary>
        /// Modifies the fields of the specificed transaction found in the calling budget object's Transactions table.
        /// </summary>
        /// <param name="transactions">Table transactions: the calling budget object's Transactions table.</param>
        /// <param name="selectedTransactionID">Int: transaction ID for the transaction to be modified.</param>
        /// <param name="date">DateTime: updated date value.</param>
        /// <param name="accountID">Int: updated AccountID.</param>
        /// <param name="transType">String: updated TransType.</param>
        /// <param name="categoryID">Int: Updated CategoryID.</param>
        /// <param name="vendorID">Int: Updated VendorID.</param>
        /// <param name="amount">Decimal: Updated transaction amount.</param>
        /// <param name="description">String: Updated transaction description.</param>
        public static void ModifyTransaction(Table<Transactions> transactions, int selectedTransactionID, DateTime date, int accountID, string transType, int categoryID
            , int vendorID, decimal amount, string description)
        {
            IQueryable<Transactions> transactionsModificationQuery =
                from trans in transactions
                where trans.TransactionID == selectedTransactionID
                select trans;

            //TODO: add check for more than 1 result.

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

        /// <summary>
        /// Deletes the specified transaction found in the calling budget object's Transactions table. Implements DeleteOnSubmit.
        /// </summary>
        /// <param name="transactions">Table Transactions: The calling budget object's Transactions table.</param>
        /// <param name="selectedTransactionID">Int: TransactionID for the transaction to be deleted.</param>
        public static void DeleteTransaction(Table<Transactions> transactions, int selectedTransactionID)
        {
            var deleteTransactionQuery =
                from trans in transactions
                where trans.TransactionID == selectedTransactionID
                select trans;

            //TODO: Add check for more than 1 result.

            foreach (var trans in deleteTransactionQuery)
            {
                transactions.DeleteOnSubmit(trans);
            }
        }
    }
}
