# BudgetAp
A simple budget application for keeping track of debits and credits by account and category.

### Device Requirements:
LocalDB 
- Program utilizes LINQ to SQL to communicate between a budget database object and a SQL database. Microsoft's LocalDB is used for database management and is included as a requirement in the installer.

Access to a syncing drive (such as Google Drive) for syncing across devices and cloud storage. 
- The program runs SQL backup and restore processes on the local database instance. The .bak files used by the backup and restore process can be accessed from a syncing drive, allowing users to access the same budget data across devices.
  
### General Overview:
Main screen
- The main screen contains a table with historical transaction information ordered by date, a spending by category table, and an active account overview table.
- Functionality is not available until a budget file is loaded or a new budget file is created. A budget must contain at least 1 account; the program will prompt you to create an account.
- The file menu includes options for creating a new budget, loading an existing budget, saving a budget, exporting a budget to a text file, and exiting the program.
- The managers menu includes access to the Account, Category, and Vendor managers. The Category and Vendor managers can also be accessed using their corresponding buttons near their corresponding tables.
- Transactions can be added, altered, and deleted using the buttons above the transactions table.
- The displayed categories in the spending by category table can be changed using the Modified Displayed Categories button above the spending by category table.
  
### Transaction Manager:
- The transaction manager form is opened after selecting either new transaction or update transaction.
- If updating a transaction, the form is pre-filled based on the selected transaction.
- If new transaction is selected, the form is not prefilled.
- Account transaction type only has two options:
  - Payment To 
  - Payment From
- "Payment to" represents a transaction in which a payment is made to an account. For an asset account, this represents additional funds and the total of the account grows. For a liability, this represents paying a portion (or total) of a credit account's balance and the total of the account shrinks.
- "Payment from" represents a transaction in which a payment is made from the selected account. For an asset account, this represents a drawing down of funds and the account total shrinks. For a liability account, this represents a payment made by a credit source and the account balance grows.
- The "Transfer between accounts?" button allows for easy transfer between accounts. For example, if Payment From transaction type is selected, an asset account is selected, and a liability account is selected as the partner account, this represents paying down a credit card (or other liability loan) balance using asset funds.

### Account Manager:
The account manager includes two options.
- Add Account adds the account to the database.
- Update Account modifies the currently selected account.
Asset vs Liability
- An asset account is an account type that represents money you possess. Examples include savings accounts and checking accounts.
- A liability account is an account type that represents money for which you are liable. Examples include credit card accounts and other various loans.
Active vs Inactive
- This simply determines if the account is shown in the Active Account Overview table in the primary form.
  
  
