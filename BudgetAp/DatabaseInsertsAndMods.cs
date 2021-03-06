﻿using BudgetAp.BudgetClasses;
using System;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Windows.Forms;

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
            newTransaction.Amount = (decimal)amount;
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

            //.Single() will result in an exception if more than one result is found. Shouldn't happen due to being based on VendorID, which is the identity field of the table.
            modifyVendorQuery.Single().Name = updatedVendorName;
        }

        /// <summary>
        /// Adds a category to the category table object and implements InsertOnSubmit.
        /// </summary>
        /// <param name="categoryTable">Database Table Object: The Category database object.</param>
        /// <param name="name">String: the name of the new category.</param>
        /// <param name="isDefault">Bool: indicator of default statis.</param>
        public static void AddCategory(Table<Category> categoryTable, string name, bool isDefault, bool isDisplayed)
        {
            Category newCategory = new Category();
            newCategory.Name = name;
            newCategory.IsDefault = isDefault;
            newCategory.IsDisplayed = isDisplayed;
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

            modifyCategoryQuery.Single().Name = updatedCategoryName;
        }

        public static void DeleteEntry(BudgetDB budget, string catOrVend, int toDeleteID)
        {
            if (catOrVend == "Category")
            {
                Table<Category> catTable = budget.GetCategoryTable();
                IQueryable<Category> modifyCategoryQuery =
                    from cats in catTable
                    where cats.CategoryID == toDeleteID
                    select cats;

                catTable.DeleteOnSubmit(modifyCategoryQuery.Single());
            }
            else if (catOrVend == "Vendor")
            {
                Table<Vendor> vendorTable = budget.GetVendorTable();
                IQueryable<Vendor> modifyVendorQuery =
                    from vendors in vendorTable
                    where vendors.VendorID == toDeleteID
                    select vendors;

                vendorTable.DeleteOnSubmit(modifyVendorQuery.Single());
            }
            else
            {
                MessageBox.Show("Error! Invalid Transaction Type.", "BudgetApp", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Modifies the isdisplayed field of a specified category found in the calling budget's Category table.
        /// </summary>
        /// <param name="categoryTable">Table Category: the category table of the budget object calling the method.</param>
        /// <param name="catName">String: name of the category to be modified.</param>
        /// <param name="displayed">Bool: new bool status of the category's display field.</param>
        public static void ModifyCategoryDisplayStatus(Table<Category> categoryTable, string catName, bool displayed)
        {
            IQueryable<Category> modifyCategoryDisplayQuery =
               from cats in categoryTable
               where cats.Name == catName
               select cats;

            modifyCategoryDisplayQuery.Single().IsDisplayed = displayed;
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

            accountQuery.Single().Name = updatedAccountName;
            accountQuery.Single().IsAsset = UpdatedAccountIsAsset;
            accountQuery.Single().IsActive = UpdatedAccountIsActive;
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

            transactionsModificationQuery.Single().TransactionDate = date;
            transactionsModificationQuery.Single().TransactionType = transType;
            transactionsModificationQuery.Single().AccountID = accountID;
            transactionsModificationQuery.Single().CategoryID = categoryID;
            transactionsModificationQuery.Single().VendorID = vendorID;
            transactionsModificationQuery.Single().Amount = amount;
            transactionsModificationQuery.Single().Description = description;
        }

        /// <summary>
        /// Modifies the transaction table by converting entryIDs that are to be deleted to the EntryIDs to be absorbed.
        /// </summary>
        /// <param name="transactions">Table Transactions: the transactions table of the budget object.</param>
        /// <param name="entryToDelete">Int: the ID (Category or Vendor) that is to be deleted.</param>
        /// <param name="entryToAbsorb">Int: the ID (Category or Vendor) that will absorb the transactions of the deleted ID.</param>
        /// <param name="entryType"></param>
        public static void ModifyTransaction(Table<Transactions> transactions, int entryToDelete, int entryToAbsorb, string entryType)
        {
            if (entryType == "Category")
            {
                IQueryable<Transactions> transactionsModifcationQuery =
                from trans in transactions
                where trans.CategoryID == entryToDelete
                select trans;

                foreach (Transactions trans in transactionsModifcationQuery)
                {
                    trans.CategoryID = entryToAbsorb;
                }
            }
            else if (entryType == "Vendor")
            {
                IQueryable<Transactions> transactionModifcationQuery =
                    from trans in transactions
                    where trans.VendorID == entryToDelete
                    select trans;

                foreach (Transactions trans in transactionModifcationQuery)
                {
                    trans.VendorID = entryToAbsorb;
                }
            }
            else
            {
                MessageBox.Show("Error! Nonexistent EntryType.", "BudgetApp", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            transactions.DeleteOnSubmit(deleteTransactionQuery.Single());            
        }
    }
}
