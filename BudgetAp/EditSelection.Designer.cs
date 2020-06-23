namespace BudgetAp
{
    partial class EditSelection
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
            this.dgvSelectionList = new System.Windows.Forms.DataGridView();
            this.gpbxAddNewEntry = new System.Windows.Forms.GroupBox();
            this.btnAddEntry = new System.Windows.Forms.Button();
            this.txtbxNewEntry = new System.Windows.Forms.TextBox();
            this.lblNewEntry = new System.Windows.Forms.Label();
            this.gpbxUpdateEntry = new System.Windows.Forms.GroupBox();
            this.btnUpdateEntry = new System.Windows.Forms.Button();
            this.txtbxUpdatedEntry = new System.Windows.Forms.TextBox();
            this.txtbxSelectedEntry = new System.Windows.Forms.TextBox();
            this.lblUpdatedEntry = new System.Windows.Forms.Label();
            this.lblSelectedEntry = new System.Windows.Forms.Label();
            this.btnFinished = new System.Windows.Forms.Button();
            this.chckbxNewDisplaySpendByMonth = new System.Windows.Forms.CheckBox();
            this.chckbxUpdatedDisplaySpendByMonth = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectionList)).BeginInit();
            this.gpbxAddNewEntry.SuspendLayout();
            this.gpbxUpdateEntry.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvSelectionList
            // 
            this.dgvSelectionList.AllowUserToAddRows = false;
            this.dgvSelectionList.AllowUserToDeleteRows = false;
            this.dgvSelectionList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSelectionList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvSelectionList.Location = new System.Drawing.Point(12, 12);
            this.dgvSelectionList.Name = "dgvSelectionList";
            this.dgvSelectionList.Size = new System.Drawing.Size(359, 378);
            this.dgvSelectionList.TabIndex = 0;
            this.dgvSelectionList.SelectionChanged += new System.EventHandler(this.dgvSelectionList_SelectionChanged);
            // 
            // gpbxAddNewEntry
            // 
            this.gpbxAddNewEntry.Controls.Add(this.chckbxNewDisplaySpendByMonth);
            this.gpbxAddNewEntry.Controls.Add(this.btnAddEntry);
            this.gpbxAddNewEntry.Controls.Add(this.txtbxNewEntry);
            this.gpbxAddNewEntry.Controls.Add(this.lblNewEntry);
            this.gpbxAddNewEntry.Location = new System.Drawing.Point(399, 13);
            this.gpbxAddNewEntry.Name = "gpbxAddNewEntry";
            this.gpbxAddNewEntry.Size = new System.Drawing.Size(215, 142);
            this.gpbxAddNewEntry.TabIndex = 1;
            this.gpbxAddNewEntry.TabStop = false;
            this.gpbxAddNewEntry.Text = "Add New Entry";
            // 
            // btnAddEntry
            // 
            this.btnAddEntry.Location = new System.Drawing.Point(100, 92);
            this.btnAddEntry.Name = "btnAddEntry";
            this.btnAddEntry.Size = new System.Drawing.Size(103, 38);
            this.btnAddEntry.TabIndex = 2;
            this.btnAddEntry.Text = "Add Entry";
            this.btnAddEntry.UseVisualStyleBackColor = true;
            this.btnAddEntry.Click += new System.EventHandler(this.btnAddEntry_Click);
            // 
            // txtbxNewEntry
            // 
            this.txtbxNewEntry.Location = new System.Drawing.Point(6, 43);
            this.txtbxNewEntry.Name = "txtbxNewEntry";
            this.txtbxNewEntry.Size = new System.Drawing.Size(200, 20);
            this.txtbxNewEntry.TabIndex = 1;
            // 
            // lblNewEntry
            // 
            this.lblNewEntry.AutoSize = true;
            this.lblNewEntry.Location = new System.Drawing.Point(3, 27);
            this.lblNewEntry.Name = "lblNewEntry";
            this.lblNewEntry.Size = new System.Drawing.Size(141, 13);
            this.lblNewEntry.TabIndex = 0;
            this.lblNewEntry.Text = "Enter New Entry Name Here";
            // 
            // gpbxUpdateEntry
            // 
            this.gpbxUpdateEntry.Controls.Add(this.chckbxUpdatedDisplaySpendByMonth);
            this.gpbxUpdateEntry.Controls.Add(this.btnUpdateEntry);
            this.gpbxUpdateEntry.Controls.Add(this.txtbxUpdatedEntry);
            this.gpbxUpdateEntry.Controls.Add(this.txtbxSelectedEntry);
            this.gpbxUpdateEntry.Controls.Add(this.lblUpdatedEntry);
            this.gpbxUpdateEntry.Controls.Add(this.lblSelectedEntry);
            this.gpbxUpdateEntry.Location = new System.Drawing.Point(399, 155);
            this.gpbxUpdateEntry.Name = "gpbxUpdateEntry";
            this.gpbxUpdateEntry.Size = new System.Drawing.Size(215, 191);
            this.gpbxUpdateEntry.TabIndex = 2;
            this.gpbxUpdateEntry.TabStop = false;
            this.gpbxUpdateEntry.Text = "Update Entry";
            // 
            // btnUpdateEntry
            // 
            this.btnUpdateEntry.Location = new System.Drawing.Point(103, 147);
            this.btnUpdateEntry.Name = "btnUpdateEntry";
            this.btnUpdateEntry.Size = new System.Drawing.Size(103, 38);
            this.btnUpdateEntry.TabIndex = 3;
            this.btnUpdateEntry.Text = "Update Entry";
            this.btnUpdateEntry.UseVisualStyleBackColor = true;
            this.btnUpdateEntry.Click += new System.EventHandler(this.btnUpdateEntry_Click);
            // 
            // txtbxUpdatedEntry
            // 
            this.txtbxUpdatedEntry.Location = new System.Drawing.Point(9, 93);
            this.txtbxUpdatedEntry.Name = "txtbxUpdatedEntry";
            this.txtbxUpdatedEntry.Size = new System.Drawing.Size(197, 20);
            this.txtbxUpdatedEntry.TabIndex = 3;
            // 
            // txtbxSelectedEntry
            // 
            this.txtbxSelectedEntry.Location = new System.Drawing.Point(9, 43);
            this.txtbxSelectedEntry.Name = "txtbxSelectedEntry";
            this.txtbxSelectedEntry.ReadOnly = true;
            this.txtbxSelectedEntry.Size = new System.Drawing.Size(197, 20);
            this.txtbxSelectedEntry.TabIndex = 2;
            // 
            // lblUpdatedEntry
            // 
            this.lblUpdatedEntry.AutoSize = true;
            this.lblUpdatedEntry.Location = new System.Drawing.Point(6, 77);
            this.lblUpdatedEntry.Name = "lblUpdatedEntry";
            this.lblUpdatedEntry.Size = new System.Drawing.Size(75, 13);
            this.lblUpdatedEntry.TabIndex = 2;
            this.lblUpdatedEntry.Text = "Updated Entry";
            // 
            // lblSelectedEntry
            // 
            this.lblSelectedEntry.AutoSize = true;
            this.lblSelectedEntry.Location = new System.Drawing.Point(6, 27);
            this.lblSelectedEntry.Name = "lblSelectedEntry";
            this.lblSelectedEntry.Size = new System.Drawing.Size(76, 13);
            this.lblSelectedEntry.TabIndex = 1;
            this.lblSelectedEntry.Text = "Selected Entry";
            // 
            // btnFinished
            // 
            this.btnFinished.Location = new System.Drawing.Point(399, 352);
            this.btnFinished.Name = "btnFinished";
            this.btnFinished.Size = new System.Drawing.Size(215, 38);
            this.btnFinished.TabIndex = 3;
            this.btnFinished.Text = "Finished";
            this.btnFinished.UseVisualStyleBackColor = true;
            this.btnFinished.Click += new System.EventHandler(this.btnFinished_Click);
            // 
            // chckbxNewDisplaySpendByMonth
            // 
            this.chckbxNewDisplaySpendByMonth.AutoSize = true;
            this.chckbxNewDisplaySpendByMonth.Location = new System.Drawing.Point(6, 69);
            this.chckbxNewDisplaySpendByMonth.Name = "chckbxNewDisplaySpendByMonth";
            this.chckbxNewDisplaySpendByMonth.Size = new System.Drawing.Size(197, 17);
            this.chckbxNewDisplaySpendByMonth.TabIndex = 3;
            this.chckbxNewDisplaySpendByMonth.Text = "Display in Spending By Month Table";
            this.chckbxNewDisplaySpendByMonth.UseVisualStyleBackColor = true;
            // 
            // chckbxUpdatedDisplaySpendByMonth
            // 
            this.chckbxUpdatedDisplaySpendByMonth.AutoSize = true;
            this.chckbxUpdatedDisplaySpendByMonth.Location = new System.Drawing.Point(9, 119);
            this.chckbxUpdatedDisplaySpendByMonth.Name = "chckbxUpdatedDisplaySpendByMonth";
            this.chckbxUpdatedDisplaySpendByMonth.Size = new System.Drawing.Size(197, 17);
            this.chckbxUpdatedDisplaySpendByMonth.TabIndex = 4;
            this.chckbxUpdatedDisplaySpendByMonth.Text = "Display in Spending By Month Table";
            this.chckbxUpdatedDisplaySpendByMonth.UseVisualStyleBackColor = true;
            // 
            // EditSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 402);
            this.Controls.Add(this.btnFinished);
            this.Controls.Add(this.gpbxUpdateEntry);
            this.Controls.Add(this.gpbxAddNewEntry);
            this.Controls.Add(this.dgvSelectionList);
            this.Name = "EditSelection";
            this.Text = "EditSelection";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectionList)).EndInit();
            this.gpbxAddNewEntry.ResumeLayout(false);
            this.gpbxAddNewEntry.PerformLayout();
            this.gpbxUpdateEntry.ResumeLayout(false);
            this.gpbxUpdateEntry.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSelectionList;
        private System.Windows.Forms.GroupBox gpbxAddNewEntry;
        private System.Windows.Forms.Button btnAddEntry;
        private System.Windows.Forms.TextBox txtbxNewEntry;
        private System.Windows.Forms.Label lblNewEntry;
        private System.Windows.Forms.GroupBox gpbxUpdateEntry;
        private System.Windows.Forms.Button btnUpdateEntry;
        private System.Windows.Forms.TextBox txtbxUpdatedEntry;
        private System.Windows.Forms.TextBox txtbxSelectedEntry;
        private System.Windows.Forms.Label lblUpdatedEntry;
        private System.Windows.Forms.Label lblSelectedEntry;
        private System.Windows.Forms.Button btnFinished;
        private System.Windows.Forms.CheckBox chckbxNewDisplaySpendByMonth;
        private System.Windows.Forms.CheckBox chckbxUpdatedDisplaySpendByMonth;
    }
}