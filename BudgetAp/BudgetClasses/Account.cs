using System.Data.Linq.Mapping;

namespace BudgetAp.BudgetClasses
{
    [Table(Name = "Account")]
    public class Account
    {
        private int _AccountID;
        [Column(IsPrimaryKey = true, Storage = "_AccountID", DbType = "int NOT NULL IDENTITY", IsDbGenerated = true)]
        public int AccountID { get { return _AccountID; } }

        private string _Name;
        [Column(Storage = "_Name", DbType = "nvarchar(100) NOT NULL")]
        public string Name { get {return _Name; } set {this._Name = value; } }

        private bool _IsAsset;
        [Column(Storage = "_IsAsset", DbType = "bit NOT NULL")]
        public bool IsAsset { get { return _IsAsset; } set { this._IsAsset = value; } }

        private bool _IsActive;
        [Column(Storage = "_IsActive", DbType = "bit NOT NULL")]
        public bool IsActive { get { return _IsActive ; } set {this._IsActive = value; } }
    }
}
