﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetAp.BudgetClasses.HelperBudgetClasses
{
    class TransactionsWithNames
    {
        public int TransactionID { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Account { get; set; }
        public string TransactionType { get; set; }
        public string Category { get; set; }
        public string Vendor { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
    }
}
