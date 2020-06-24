namespace BudgetAp
{
    partial class DisplayCategoriesManager
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
            this.lstbxDisplayedCategories = new System.Windows.Forms.ListBox();
            this.lstbxNotDisplayedCategories = new System.Windows.Forms.ListBox();
            this.btnMoveSelectedToDisplayedList = new System.Windows.Forms.Button();
            this.btnMoveSelectedToNotDisplayedList = new System.Windows.Forms.Button();
            this.btnFinished = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblDisplayedList = new System.Windows.Forms.Label();
            this.lblNotDisplayedList = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstbxDisplayedCategories
            // 
            this.lstbxDisplayedCategories.FormattingEnabled = true;
            this.lstbxDisplayedCategories.Location = new System.Drawing.Point(12, 42);
            this.lstbxDisplayedCategories.Name = "lstbxDisplayedCategories";
            this.lstbxDisplayedCategories.Size = new System.Drawing.Size(154, 355);
            this.lstbxDisplayedCategories.TabIndex = 0;
            // 
            // lstbxNotDisplayedCategories
            // 
            this.lstbxNotDisplayedCategories.FormattingEnabled = true;
            this.lstbxNotDisplayedCategories.Location = new System.Drawing.Point(307, 42);
            this.lstbxNotDisplayedCategories.Name = "lstbxNotDisplayedCategories";
            this.lstbxNotDisplayedCategories.Size = new System.Drawing.Size(154, 355);
            this.lstbxNotDisplayedCategories.TabIndex = 1;
            // 
            // btnMoveSelectedToDisplayedList
            // 
            this.btnMoveSelectedToDisplayedList.Location = new System.Drawing.Point(184, 145);
            this.btnMoveSelectedToDisplayedList.Name = "btnMoveSelectedToDisplayedList";
            this.btnMoveSelectedToDisplayedList.Size = new System.Drawing.Size(97, 38);
            this.btnMoveSelectedToDisplayedList.TabIndex = 3;
            this.btnMoveSelectedToDisplayedList.Text = "<";
            this.btnMoveSelectedToDisplayedList.UseVisualStyleBackColor = true;
            this.btnMoveSelectedToDisplayedList.Click += new System.EventHandler(this.btnMoveSelectedToDisplayedList_Click);
            // 
            // btnMoveSelectedToNotDisplayedList
            // 
            this.btnMoveSelectedToNotDisplayedList.Location = new System.Drawing.Point(184, 189);
            this.btnMoveSelectedToNotDisplayedList.Name = "btnMoveSelectedToNotDisplayedList";
            this.btnMoveSelectedToNotDisplayedList.Size = new System.Drawing.Size(97, 38);
            this.btnMoveSelectedToNotDisplayedList.TabIndex = 4;
            this.btnMoveSelectedToNotDisplayedList.Text = ">";
            this.btnMoveSelectedToNotDisplayedList.UseVisualStyleBackColor = true;
            this.btnMoveSelectedToNotDisplayedList.Click += new System.EventHandler(this.btnMoveSelectedToNotDisplayedList_Click);
            // 
            // btnFinished
            // 
            this.btnFinished.Location = new System.Drawing.Point(184, 316);
            this.btnFinished.Name = "btnFinished";
            this.btnFinished.Size = new System.Drawing.Size(97, 38);
            this.btnFinished.TabIndex = 6;
            this.btnFinished.Text = "Finished";
            this.btnFinished.UseVisualStyleBackColor = true;
            this.btnFinished.Click += new System.EventHandler(this.btnFinished_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(184, 360);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(97, 38);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblDisplayedList
            // 
            this.lblDisplayedList.AutoSize = true;
            this.lblDisplayedList.Location = new System.Drawing.Point(10, 23);
            this.lblDisplayedList.Name = "lblDisplayedList";
            this.lblDisplayedList.Size = new System.Drawing.Size(106, 13);
            this.lblDisplayedList.TabIndex = 8;
            this.lblDisplayedList.Text = "Displayed Categories";
            // 
            // lblNotDisplayedList
            // 
            this.lblNotDisplayedList.AutoSize = true;
            this.lblNotDisplayedList.Location = new System.Drawing.Point(304, 26);
            this.lblNotDisplayedList.Name = "lblNotDisplayedList";
            this.lblNotDisplayedList.Size = new System.Drawing.Size(73, 13);
            this.lblNotDisplayedList.TabIndex = 9;
            this.lblNotDisplayedList.Text = "Not Displayed";
            // 
            // DisplayCategoriesManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 410);
            this.Controls.Add(this.lblNotDisplayedList);
            this.Controls.Add(this.lblDisplayedList);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnFinished);
            this.Controls.Add(this.btnMoveSelectedToNotDisplayedList);
            this.Controls.Add(this.btnMoveSelectedToDisplayedList);
            this.Controls.Add(this.lstbxNotDisplayedCategories);
            this.Controls.Add(this.lstbxDisplayedCategories);
            this.Name = "DisplayCategoriesManager";
            this.Text = "DisplayCategoriesManager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstbxDisplayedCategories;
        private System.Windows.Forms.ListBox lstbxNotDisplayedCategories;
        private System.Windows.Forms.Button btnMoveSelectedToDisplayedList;
        private System.Windows.Forms.Button btnMoveSelectedToNotDisplayedList;
        private System.Windows.Forms.Button btnFinished;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblDisplayedList;
        private System.Windows.Forms.Label lblNotDisplayedList;
    }
}