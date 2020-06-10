using System;
using System.Data.Linq.Mapping;

namespace BudgetAp.BudgetClasses
{
    [Table(Name = "Transactions")]
    public class Transactions
    {
        private int _TransactionID;
        [Column(IsPrimaryKey = true, Storage = "_TransactionID", DbType = "int NOT NULL IDENTITY", IsDbGenerated = true)]
        public int TransactionID { get {return _TransactionID; } }

        private DateTime _TransactionDate;
        [Column(Storage = "_TransactionDate", DbType = "date NOT NULL")]
        public DateTime TransactionDate { get {return _TransactionDate; } set {this._TransactionDate = value; } }

        private int _AccountID;
        [Column(Storage = "_AccountID", DbType = "int NOT NULL")]
        public int AccountID { get {return _AccountID; } set {this._AccountID = value; } }

        private string _TransactionType;
        [Column(Storage = "_TransactionType", DbType = "nvarchar(15) NOT NULL")]
        public string TransactionType { get {return _TransactionType; } set {this._TransactionType = value; } }

        private int _CategoryID;
        [Column(Storage = "_CategoryID", DbType = "int NOT NULL")]
        public int CategoryID { get { return _CategoryID; }  set { this._CategoryID = value; } }

        private int _VendorID;
        [Column(Storage = "_VendorID", DbType = "int NOT NULL")]
        public int VendorID { get { return _VendorID; } set { this._VendorID = value; } }

        private decimal _Amount;
        [Column(Storage = "_Amount", DbType = "decimal(18,0) NOT NULL")]
        public decimal Amount { get { return _Amount; } set { this._Amount = value; } }

        private string _Description;
        [Column(Storage = "_Description", DbType = "nvarchar(500) NULL")]
        public string Description { get { return _Description; } set { this._Description = value; } }
    }
}
