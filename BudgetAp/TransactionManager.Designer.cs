namespace BudgetAp
{
    partial class TransactionManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblAccountTransactionType = new System.Windows.Forms.Label();
            this.lblAccount = new System.Windows.Forms.Label();
            this.lblAccountTransfer = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblVendor = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtbxAmount = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtbxDescription = new System.Windows.Forms.TextBox();
            this.chckbxTransfer = new System.Windows.Forms.CheckBox();
            this.cmbxTransType = new System.Windows.Forms.ComboBox();
            this.cmbxAccount = new System.Windows.Forms.ComboBox();
            this.cmbxCategory = new System.Windows.Forms.ComboBox();
            this.cmbxVendor = new System.Windows.Forms.ComboBox();
            this.cmbxTransferAccounts = new System.Windows.Forms.ComboBox();
            this.btnAccountManager = new System.Windows.Forms.Button();
            this.btnCategoryManager = new System.Windows.Forms.Button();
            this.btnVendorManager = new System.Windows.Forms.Button();
            this.btnAddTransaction = new System.Windows.Forms.Button();
            this.btnCancelTransaction = new System.Windows.Forms.Button();
            this.lblTransferAccount = new System.Windows.Forms.Label();
            this.btnUpdateTransaction = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblAccountTransactionType
            // 
            this.lblAccountTransactionType.AutoSize = true;
            this.lblAccountTransactionType.Location = new System.Drawing.Point(9, 13);
            this.lblAccountTransactionType.Name = "lblAccountTransactionType";
            this.lblAccountTransactionType.Size = new System.Drawing.Size(133, 13);
            this.lblAccountTransactionType.TabIndex = 0;
            this.lblAccountTransactionType.Text = "Account Transaction Type";
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.Location = new System.Drawing.Point(226, 14);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(47, 13);
            this.lblAccount.TabIndex = 1;
            this.lblAccount.Text = "Account";
            // 
            // lblAccountTransfer
            // 
            this.lblAccountTransfer.AutoSize = true;
            this.lblAccountTransfer.Location = new System.Drawing.Point(226, 70);
            this.lblAccountTransfer.Name = "lblAccountTransfer";
            this.lblAccountTransfer.Size = new System.Drawing.Size(47, 13);
            this.lblAccountTransfer.TabIndex = 2;
            this.lblAccountTransfer.Text = "Account";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(226, 126);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(30, 13);
            this.lblDate.TabIndex = 3;
            this.lblDate.Text = "Date";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(9, 126);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(43, 13);
            this.lblAmount.TabIndex = 4;
            this.lblAmount.Text = "Amount";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(9, 192);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(49, 13);
            this.lblCategory.TabIndex = 5;
            this.lblCategory.Text = "Category";
            // 
            // lblVendor
            // 
            this.lblVendor.AutoSize = true;
            this.lblVendor.Location = new System.Drawing.Point(9, 249);
            this.lblVendor.Name = "lblVendor";
            this.lblVendor.Size = new System.Drawing.Size(41, 13);
            this.lblVendor.TabIndex = 6;
            this.lblVendor.Text = "Vendor";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(226, 182);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(119, 13);
            this.lblDescription.TabIndex = 7;
            this.lblDescription.Text = "Transaction Description";
            // 
            // txtbxAmount
            // 
            this.txtbxAmount.Location = new System.Drawing.Point(13, 142);
            this.txtbxAmount.Name = "txtbxAmount";
            this.txtbxAmount.Size = new System.Drawing.Size(174, 20);
            this.txtbxAmount.TabIndex = 5;
            this.txtbxAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbxAmount_KeyPress);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(229, 142);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(185, 20);
            this.dateTimePicker1.TabIndex = 6;
            // 
            // txtbxDescription
            // 
            this.txtbxDescription.Location = new System.Drawing.Point(229, 198);
            this.txtbxDescription.Multiline = true;
            this.txtbxDescription.Name = "txtbxDescription";
            this.txtbxDescription.Size = new System.Drawing.Size(185, 88);
            this.txtbxDescription.TabIndex = 10;
            // 
            // chckbxTransfer
            // 
            this.chckbxTransfer.AutoSize = true;
            this.chckbxTransfer.Location = new System.Drawing.Point(12, 70);
            this.chckbxTransfer.Name = "chckbxTransfer";
            this.chckbxTransfer.Size = new System.Drawing.Size(162, 17);
            this.chckbxTransfer.TabIndex = 3;
            this.chckbxTransfer.Text = "Transfer between accounts?";
            this.chckbxTransfer.UseVisualStyleBackColor = true;
            this.chckbxTransfer.CheckedChanged += new System.EventHandler(this.chckbxTransfer_CheckedChanged);
            // 
            // cmbxTransType
            // 
            this.cmbxTransType.FormattingEnabled = true;
            this.cmbxTransType.Location = new System.Drawing.Point(13, 30);
            this.cmbxTransType.Name = "cmbxTransType";
            this.cmbxTransType.Size = new System.Drawing.Size(174, 21);
            this.cmbxTransType.TabIndex = 1;
            // 
            // cmbxAccount
            // 
            this.cmbxAccount.FormattingEnabled = true;
            this.cmbxAccount.Location = new System.Drawing.Point(229, 30);
            this.cmbxAccount.Name = "cmbxAccount";
            this.cmbxAccount.Size = new System.Drawing.Size(185, 21);
            this.cmbxAccount.TabIndex = 2;
            // 
            // cmbxCategory
            // 
            this.cmbxCategory.FormattingEnabled = true;
            this.cmbxCategory.Location = new System.Drawing.Point(12, 208);
            this.cmbxCategory.Name = "cmbxCategory";
            this.cmbxCategory.Size = new System.Drawing.Size(175, 21);
            this.cmbxCategory.TabIndex = 7;
            // 
            // cmbxVendor
            // 
            this.cmbxVendor.FormattingEnabled = true;
            this.cmbxVendor.Location = new System.Drawing.Point(13, 265);
            this.cmbxVendor.Name = "cmbxVendor";
            this.cmbxVendor.Size = new System.Drawing.Size(174, 21);
            this.cmbxVendor.TabIndex = 8;
            // 
            // cmbxTransferAccounts
            // 
            this.cmbxTransferAccounts.FormattingEnabled = true;
            this.cmbxTransferAccounts.Location = new System.Drawing.Point(229, 86);
            this.cmbxTransferAccounts.Name = "cmbxTransferAccounts";
            this.cmbxTransferAccounts.Size = new System.Drawing.Size(185, 21);
            this.cmbxTransferAccounts.TabIndex = 4;
            // 
            // btnAccountManager
            // 
            this.btnAccountManager.AutoSize = true;
            this.btnAccountManager.Location = new System.Drawing.Point(312, 3);
            this.btnAccountManager.Name = "btnAccountManager";
            this.btnAccountManager.Size = new System.Drawing.Size(102, 23);
            this.btnAccountManager.TabIndex = 17;
            this.btnAccountManager.Text = "Account Manager";
            this.btnAccountManager.UseVisualStyleBackColor = true;
            this.btnAccountManager.Click += new System.EventHandler(this.btnAccountManager_Click);
            // 
            // btnCategoryManager
            // 
            this.btnCategoryManager.AutoSize = true;
            this.btnCategoryManager.Location = new System.Drawing.Point(83, 182);
            this.btnCategoryManager.Name = "btnCategoryManager";
            this.btnCategoryManager.Size = new System.Drawing.Size(104, 23);
            this.btnCategoryManager.TabIndex = 18;
            this.btnCategoryManager.Text = "Category Manager";
            this.btnCategoryManager.UseVisualStyleBackColor = true;
            this.btnCategoryManager.Click += new System.EventHandler(this.btnCategoryManager_Click);
            // 
            // btnVendorManager
            // 
            this.btnVendorManager.AutoSize = true;
            this.btnVendorManager.Location = new System.Drawing.Point(91, 239);
            this.btnVendorManager.Name = "btnVendorManager";
            this.btnVendorManager.Size = new System.Drawing.Size(96, 23);
            this.btnVendorManager.TabIndex = 19;
            this.btnVendorManager.Text = "Vendor Manager";
            this.btnVendorManager.UseVisualStyleBackColor = true;
            this.btnVendorManager.Click += new System.EventHandler(this.btnVendorManager_Click);
            // 
            // btnAddTransaction
            // 
            this.btnAddTransaction.AutoSize = true;
            this.btnAddTransaction.Location = new System.Drawing.Point(13, 302);
            this.btnAddTransaction.Name = "btnAddTransaction";
            this.btnAddTransaction.Size = new System.Drawing.Size(401, 51);
            this.btnAddTransaction.TabIndex = 10;
            this.btnAddTransaction.Text = "Add Transaction";
            this.btnAddTransaction.UseVisualStyleBackColor = true;
            this.btnAddTransaction.Click += new System.EventHandler(this.btnAddTransaction_Click);
            // 
            // btnCancelTransaction
            // 
            this.btnCancelTransaction.AutoSize = true;
            this.btnCancelTransaction.Location = new System.Drawing.Point(13, 359);
            this.btnCancelTransaction.Name = "btnCancelTransaction";
            this.btnCancelTransaction.Size = new System.Drawing.Size(401, 51);
            this.btnCancelTransaction.TabIndex = 11;
            this.btnCancelTransaction.Text = "Cancel Transaction";
            this.btnCancelTransaction.UseVisualStyleBackColor = true;
            this.btnCancelTransaction.Click += new System.EventHandler(this.btnCancelTransaction_Click);
            // 
            // lblTransferAccount
            // 
            this.lblTransferAccount.AutoSize = true;
            this.lblTransferAccount.Location = new System.Drawing.Point(30, 90);
            this.lblTransferAccount.Name = "lblTransferAccount";
            this.lblTransferAccount.Size = new System.Drawing.Size(133, 13);
            this.lblTransferAccount.TabIndex = 22;
            this.lblTransferAccount.Text = "Select the partner account";
            // 
            // btnUpdateTransaction
            // 
            this.btnUpdateTransaction.Location = new System.Drawing.Point(13, 302);
            this.btnUpdateTransaction.Name = "btnUpdateTransaction";
            this.btnUpdateTransaction.Size = new System.Drawing.Size(402, 51);
            this.btnUpdateTransaction.TabIndex = 9;
            this.btnUpdateTransaction.Text = "Update Transaction";
            this.btnUpdateTransaction.UseVisualStyleBackColor = true;
            this.btnUpdateTransaction.Click += new System.EventHandler(this.btnUpdateTransaction_Click);
            // 
            // TransactionManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 424);
            this.Controls.Add(this.btnUpdateTransaction);
            this.Controls.Add(this.lblTransferAccount);
            this.Controls.Add(this.btnCancelTransaction);
            this.Controls.Add(this.btnVendorManager);
            this.Controls.Add(this.btnCategoryManager);
            this.Controls.Add(this.btnAccountManager);
            this.Controls.Add(this.cmbxTransferAccounts);
            this.Controls.Add(this.cmbxVendor);
            this.Controls.Add(this.cmbxCategory);
            this.Controls.Add(this.cmbxAccount);
            this.Controls.Add(this.cmbxTransType);
            this.Controls.Add(this.chckbxTransfer);
            this.Controls.Add(this.txtbxDescription);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.txtbxAmount);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblVendor);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblAccountTransfer);
            this.Controls.Add(this.lblAccount);
            this.Controls.Add(this.lblAccountTransactionType);
            this.Controls.Add(this.btnAddTransaction);
            this.Name = "TransactionManager";
            this.Text = "Transaction Manager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAccountTransactionType;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.Label lblAccountTransfer;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblVendor;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtbxAmount;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox txtbxDescription;
        private System.Windows.Forms.CheckBox chckbxTransfer;
        private System.Windows.Forms.ComboBox cmbxTransType;
        private System.Windows.Forms.ComboBox cmbxAccount;
        private System.Windows.Forms.ComboBox cmbxCategory;
        private System.Windows.Forms.ComboBox cmbxVendor;
        private System.Windows.Forms.ComboBox cmbxTransferAccounts;
        private System.Windows.Forms.Button btnAccountManager;
        private System.Windows.Forms.Button btnCategoryManager;
        private System.Windows.Forms.Button btnVendorManager;
        private System.Windows.Forms.Button btnAddTransaction;
        private System.Windows.Forms.Button btnCancelTransaction;
        private System.Windows.Forms.Label lblTransferAccount;
        private System.Windows.Forms.Button btnUpdateTransaction;
    }
}