namespace BudgetAp
{
    partial class Form1
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadExistingBudgetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveBudgetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvTransactions = new System.Windows.Forms.DataGridView();
            this.lblTransactions = new System.Windows.Forms.Label();
            this.lblSpendingByCategory = new System.Windows.Forms.Label();
            this.lblAccountOverview = new System.Windows.Forms.Label();
            this.btnCategoryManager = new System.Windows.Forms.Button();
            this.btnAccountManager = new System.Windows.Forms.Button();
            this.btnNewTransaction = new System.Windows.Forms.Button();
            this.btnEditTransaction = new System.Windows.Forms.Button();
            this.btnDeleteTransaction = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.dgvAccountOverview = new System.Windows.Forms.DataGridView();
            this.dgvSpendingByCategory = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccountOverview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpendingByCategory)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "bak";
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "*.bak|*.bak";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "bak";
            this.saveFileDialog1.Filter = "*.bak|*.bak";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1769, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.loadExistingBudgetToolStripMenuItem,
            this.saveBudgetToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.newToolStripMenuItem.Text = "New Budget";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // loadExistingBudgetToolStripMenuItem
            // 
            this.loadExistingBudgetToolStripMenuItem.Name = "loadExistingBudgetToolStripMenuItem";
            this.loadExistingBudgetToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.loadExistingBudgetToolStripMenuItem.Text = "Load Budget";
            this.loadExistingBudgetToolStripMenuItem.Click += new System.EventHandler(this.loadBudgetToolStripMenuItem_Click);
            // 
            // saveBudgetToolStripMenuItem
            // 
            this.saveBudgetToolStripMenuItem.Name = "saveBudgetToolStripMenuItem";
            this.saveBudgetToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.saveBudgetToolStripMenuItem.Text = "Save Budget";
            this.saveBudgetToolStripMenuItem.Click += new System.EventHandler(this.saveBudgetToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // dgvTransactions
            // 
            this.dgvTransactions.AllowUserToAddRows = false;
            this.dgvTransactions.AllowUserToDeleteRows = false;
            this.dgvTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransactions.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvTransactions.Location = new System.Drawing.Point(12, 52);
            this.dgvTransactions.MultiSelect = false;
            this.dgvTransactions.Name = "dgvTransactions";
            this.dgvTransactions.ReadOnly = true;
            this.dgvTransactions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransactions.Size = new System.Drawing.Size(922, 648);
            this.dgvTransactions.TabIndex = 1;
            // 
            // lblTransactions
            // 
            this.lblTransactions.AutoSize = true;
            this.lblTransactions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTransactions.Location = new System.Drawing.Point(8, 29);
            this.lblTransactions.Name = "lblTransactions";
            this.lblTransactions.Size = new System.Drawing.Size(112, 20);
            this.lblTransactions.TabIndex = 2;
            this.lblTransactions.Text = "Transactions";
            // 
            // lblSpendingByCategory
            // 
            this.lblSpendingByCategory.AutoSize = true;
            this.lblSpendingByCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblSpendingByCategory.Location = new System.Drawing.Point(940, 29);
            this.lblSpendingByCategory.Name = "lblSpendingByCategory";
            this.lblSpendingByCategory.Size = new System.Drawing.Size(187, 20);
            this.lblSpendingByCategory.TabIndex = 3;
            this.lblSpendingByCategory.Text = "Spending By Category";
            // 
            // lblAccountOverview
            // 
            this.lblAccountOverview.AutoSize = true;
            this.lblAccountOverview.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblAccountOverview.Location = new System.Drawing.Point(940, 511);
            this.lblAccountOverview.Name = "lblAccountOverview";
            this.lblAccountOverview.Size = new System.Drawing.Size(151, 20);
            this.lblAccountOverview.TabIndex = 4;
            this.lblAccountOverview.Text = "Account Overview";
            // 
            // btnCategoryManager
            // 
            this.btnCategoryManager.Location = new System.Drawing.Point(1631, 24);
            this.btnCategoryManager.Name = "btnCategoryManager";
            this.btnCategoryManager.Size = new System.Drawing.Size(126, 27);
            this.btnCategoryManager.TabIndex = 5;
            this.btnCategoryManager.Text = "Category Manager";
            this.btnCategoryManager.UseVisualStyleBackColor = true;
            this.btnCategoryManager.Click += new System.EventHandler(this.btnCategoryManager_Click);
            // 
            // btnAccountManager
            // 
            this.btnAccountManager.Location = new System.Drawing.Point(1242, 503);
            this.btnAccountManager.Name = "btnAccountManager";
            this.btnAccountManager.Size = new System.Drawing.Size(119, 28);
            this.btnAccountManager.TabIndex = 6;
            this.btnAccountManager.Text = "Account Manager";
            this.btnAccountManager.UseVisualStyleBackColor = true;
            this.btnAccountManager.Click += new System.EventHandler(this.btnAccountManager_Click);
            // 
            // btnNewTransaction
            // 
            this.btnNewTransaction.Location = new System.Drawing.Point(1405, 537);
            this.btnNewTransaction.Name = "btnNewTransaction";
            this.btnNewTransaction.Size = new System.Drawing.Size(352, 48);
            this.btnNewTransaction.TabIndex = 7;
            this.btnNewTransaction.Text = "New Transaction";
            this.btnNewTransaction.UseVisualStyleBackColor = true;
            this.btnNewTransaction.Click += new System.EventHandler(this.btnNewTransaction_Click);
            // 
            // btnEditTransaction
            // 
            this.btnEditTransaction.Location = new System.Drawing.Point(1405, 591);
            this.btnEditTransaction.Name = "btnEditTransaction";
            this.btnEditTransaction.Size = new System.Drawing.Size(174, 48);
            this.btnEditTransaction.TabIndex = 8;
            this.btnEditTransaction.Text = "Edit Transaction";
            this.btnEditTransaction.UseVisualStyleBackColor = true;
            this.btnEditTransaction.Click += new System.EventHandler(this.btnEditTransaction_Click);
            // 
            // btnDeleteTransaction
            // 
            this.btnDeleteTransaction.Location = new System.Drawing.Point(1585, 591);
            this.btnDeleteTransaction.Name = "btnDeleteTransaction";
            this.btnDeleteTransaction.Size = new System.Drawing.Size(172, 48);
            this.btnDeleteTransaction.TabIndex = 9;
            this.btnDeleteTransaction.Text = "Delete Transaction";
            this.btnDeleteTransaction.UseVisualStyleBackColor = true;
            this.btnDeleteTransaction.Click += new System.EventHandler(this.btnDeleteTransaction_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(1405, 645);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(352, 48);
            this.btnExport.TabIndex = 10;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // dgvAccountOverview
            // 
            this.dgvAccountOverview.AllowUserToAddRows = false;
            this.dgvAccountOverview.AllowUserToDeleteRows = false;
            this.dgvAccountOverview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAccountOverview.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvAccountOverview.Location = new System.Drawing.Point(943, 532);
            this.dgvAccountOverview.MultiSelect = false;
            this.dgvAccountOverview.Name = "dgvAccountOverview";
            this.dgvAccountOverview.ReadOnly = true;
            this.dgvAccountOverview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAccountOverview.Size = new System.Drawing.Size(418, 168);
            this.dgvAccountOverview.TabIndex = 11;
            // 
            // dgvSpendingByCategory
            // 
            this.dgvSpendingByCategory.AllowUserToAddRows = false;
            this.dgvSpendingByCategory.AllowUserToDeleteRows = false;
            this.dgvSpendingByCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSpendingByCategory.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvSpendingByCategory.Location = new System.Drawing.Point(943, 52);
            this.dgvSpendingByCategory.MultiSelect = false;
            this.dgvSpendingByCategory.Name = "dgvSpendingByCategory";
            this.dgvSpendingByCategory.ReadOnly = true;
            this.dgvSpendingByCategory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSpendingByCategory.Size = new System.Drawing.Size(814, 440);
            this.dgvSpendingByCategory.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1769, 712);
            this.Controls.Add(this.dgvSpendingByCategory);
            this.Controls.Add(this.dgvAccountOverview);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnDeleteTransaction);
            this.Controls.Add(this.btnEditTransaction);
            this.Controls.Add(this.btnNewTransaction);
            this.Controls.Add(this.btnAccountManager);
            this.Controls.Add(this.btnCategoryManager);
            this.Controls.Add(this.lblAccountOverview);
            this.Controls.Add(this.lblSpendingByCategory);
            this.Controls.Add(this.lblTransactions);
            this.Controls.Add(this.dgvTransactions);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccountOverview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpendingByCategory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadExistingBudgetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvTransactions;
        private System.Windows.Forms.Label lblTransactions;
        private System.Windows.Forms.Label lblSpendingByCategory;
        private System.Windows.Forms.Label lblAccountOverview;
        private System.Windows.Forms.Button btnCategoryManager;
        private System.Windows.Forms.Button btnAccountManager;
        private System.Windows.Forms.Button btnNewTransaction;
        private System.Windows.Forms.Button btnEditTransaction;
        private System.Windows.Forms.Button btnDeleteTransaction;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DataGridView dgvAccountOverview;
        private System.Windows.Forms.DataGridView dgvSpendingByCategory;
        private System.Windows.Forms.ToolStripMenuItem saveBudgetToolStripMenuItem;
    }
}

