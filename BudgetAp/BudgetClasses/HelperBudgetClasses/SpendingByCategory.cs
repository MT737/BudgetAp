namespace BudgetAp.BudgetClasses.HelperBudgetClasses
{
    class SpendingByCategory
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public decimal PriorMonth { get; set; }
        public decimal CurrentMonth { get; set; }
        public decimal ThreeMonthAverage {get; set; }
    }
}
