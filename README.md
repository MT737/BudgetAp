# BudgetAp
A simple budget application for keeping track of debits and credits by account and category.

### Device Requirements:
- Basic SQL functionality 
  - Program utilizes LINQ to SQL to communicate between a budget database object and a SQL database. 

- Access to a syncing drive (such as Google Drive) for syncing across devices and cloud storage. 
  - The program runs SQL backup and restore processes on the local database instance. The .bak files used by the backup and restore process can be accessed from a syncing drive, allowing users to access the same budget data across devices.
