using System.Data.Linq.Mapping;

namespace BudgetAp.BudgetClasses
{
    [Table(Name = "Category")]
    public class Category
    {
        private int _CategoryID;
        [Column(IsPrimaryKey = true, Storage = "_CategoryID", DbType = "int NOT NULL IDENTITY", IsDbGenerated = true)]
        public int CategoryID { get { return _CategoryID; } }

        private string _Name;
        [Column(Storage = "_Name", DbType = "nvarchar(100) NOT NULL")]
        public string Name { get { return _Name; } set {this._Name = value; } }

        private bool _IsDefault;
        [Column(Storage = "_IsDefault", DbType = "bit NOT NULL")]
        public bool IsDefault { get { return _IsDefault; } set {this._IsDefault = value; } }

        private bool _IsDisplayed;
        [Column(Storage = "_IsDisplayed", DbType = "bit NOT NULL")]
        public bool IsDisplayed { get { return _IsDisplayed; } set { this._IsDisplayed = value; } }
    }
}
