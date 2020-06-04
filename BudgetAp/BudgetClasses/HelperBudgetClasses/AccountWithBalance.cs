using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetAp.BudgetClasses.HelperBudgetClasses
{
    public class AccountWithBalance
    {
        public int AccountID {get; set;}
        public string Name { get; set; }
        public bool IsAsset { get; set; }
        public bool IsActive { get; set; }
        public decimal Balance { get; set; }
    }
}
