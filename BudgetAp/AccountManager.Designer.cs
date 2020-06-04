namespace BudgetAp
{
    partial class AccountManager
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
            this.dgvAccounts = new System.Windows.Forms.DataGridView();
            this.lblAccountDGV = new System.Windows.Forms.Label();
            this.gbxAddAccount = new System.Windows.Forms.GroupBox();
            this.txtbxNewAccountBalance = new System.Windows.Forms.TextBox();
            this.txtbxNewAccountName = new System.Windows.Forms.TextBox();
            this.btnAddAccount = new System.Windows.Forms.Button();
            this.gbxNewAccountClassification = new System.Windows.Forms.GroupBox();
            this.rdbtnNewLiability = new System.Windows.Forms.RadioButton();
            this.rdbtnNewAsset = new System.Windows.Forms.RadioButton();
            this.lblNewAccountBalance = new System.Windows.Forms.Label();
            this.lblNewAccountName = new System.Windows.Forms.Label();
            this.gpbxEditAccount = new System.Windows.Forms.GroupBox();
            this.gpbxUpdatedAccountClassification = new System.Windows.Forms.GroupBox();
            this.rdbtnUpdatedAccountLiability = new System.Windows.Forms.RadioButton();
            this.rdbtnUpdatedAccountAsset = new System.Windows.Forms.RadioButton();
            this.txtbxUpdatedAccountBalance = new System.Windows.Forms.TextBox();
            this.txtbxUpdatedAccountName = new System.Windows.Forms.TextBox();
            this.txtbxSelectedAccountBalance = new System.Windows.Forms.TextBox();
            this.txtbxSelectedAccount = new System.Windows.Forms.TextBox();
            this.btnUpdateAccount = new System.Windows.Forms.Button();
            this.lblUpdatedAccountBalance = new System.Windows.Forms.Label();
            this.lblUpdatedAccountName = new System.Windows.Forms.Label();
            this.gpbxEditAccountClassification = new System.Windows.Forms.GroupBox();
            this.rdbtnSelectedAccountLiability = new System.Windows.Forms.RadioButton();
            this.rdbtnSelectedAccountAsset = new System.Windows.Forms.RadioButton();
            this.lblSelectedAccountBalance = new System.Windows.Forms.Label();
            this.lblSelectedAccount = new System.Windows.Forms.Label();
            this.gpbxNewAccountStatus = new System.Windows.Forms.GroupBox();
            this.rdbtnNewAccountInactive = new System.Windows.Forms.RadioButton();
            this.rdbtnNewAccountActive = new System.Windows.Forms.RadioButton();
            this.gpbxUpdatedAccountStatus = new System.Windows.Forms.GroupBox();
            this.rdbtnUpdatedAccountInactive = new System.Windows.Forms.RadioButton();
            this.rdbtnUpdatedAccountActive = new System.Windows.Forms.RadioButton();
            this.gpbxSelectedAccountStatus = new System.Windows.Forms.GroupBox();
            this.rdbtnSelectedAccountInactive = new System.Windows.Forms.RadioButton();
            this.rdbtnSelectedAccountActive = new System.Windows.Forms.RadioButton();
            this.btnFinished = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccounts)).BeginInit();
            this.gbxAddAccount.SuspendLayout();
            this.gbxNewAccountClassification.SuspendLayout();
            this.gpbxEditAccount.SuspendLayout();
            this.gpbxUpdatedAccountClassification.SuspendLayout();
            this.gpbxEditAccountClassification.SuspendLayout();
            this.gpbxNewAccountStatus.SuspendLayout();
            this.gpbxUpdatedAccountStatus.SuspendLayout();
            this.gpbxSelectedAccountStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvAccounts
            // 
            this.dgvAccounts.AllowUserToAddRows = false;
            this.dgvAccounts.AllowUserToDeleteRows = false;
            this.dgvAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAccounts.Location = new System.Drawing.Point(282, 59);
            this.dgvAccounts.MultiSelect = false;
            this.dgvAccounts.Name = "dgvAccounts";
            this.dgvAccounts.ReadOnly = true;
            this.dgvAccounts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAccounts.Size = new System.Drawing.Size(673, 707);
            this.dgvAccounts.TabIndex = 0;
            this.dgvAccounts.SelectionChanged += new System.EventHandler(this.dgvAccounts_SelectionChanged);
            // 
            // lblAccountDGV
            // 
            this.lblAccountDGV.AutoSize = true;
            this.lblAccountDGV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblAccountDGV.Location = new System.Drawing.Point(279, 39);
            this.lblAccountDGV.Name = "lblAccountDGV";
            this.lblAccountDGV.Size = new System.Drawing.Size(66, 17);
            this.lblAccountDGV.TabIndex = 1;
            this.lblAccountDGV.Text = "Accounts";
            // 
            // gbxAddAccount
            // 
            this.gbxAddAccount.Controls.Add(this.gpbxNewAccountStatus);
            this.gbxAddAccount.Controls.Add(this.txtbxNewAccountBalance);
            this.gbxAddAccount.Controls.Add(this.txtbxNewAccountName);
            this.gbxAddAccount.Controls.Add(this.btnAddAccount);
            this.gbxAddAccount.Controls.Add(this.gbxNewAccountClassification);
            this.gbxAddAccount.Controls.Add(this.lblNewAccountBalance);
            this.gbxAddAccount.Controls.Add(this.lblNewAccountName);
            this.gbxAddAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxAddAccount.Location = new System.Drawing.Point(12, 12);
            this.gbxAddAccount.Name = "gbxAddAccount";
            this.gbxAddAccount.Size = new System.Drawing.Size(253, 274);
            this.gbxAddAccount.TabIndex = 2;
            this.gbxAddAccount.TabStop = false;
            this.gbxAddAccount.Text = "Add Account";
            // 
            // txtbxNewAccountBalance
            // 
            this.txtbxNewAccountBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbxNewAccountBalance.Location = new System.Drawing.Point(7, 94);
            this.txtbxNewAccountBalance.Name = "txtbxNewAccountBalance";
            this.txtbxNewAccountBalance.Size = new System.Drawing.Size(236, 24);
            this.txtbxNewAccountBalance.TabIndex = 5;
            this.txtbxNewAccountBalance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbxNewAccountBalance_KeyPress);
            // 
            // txtbxNewAccountName
            // 
            this.txtbxNewAccountName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbxNewAccountName.Location = new System.Drawing.Point(7, 47);
            this.txtbxNewAccountName.Name = "txtbxNewAccountName";
            this.txtbxNewAccountName.Size = new System.Drawing.Size(236, 24);
            this.txtbxNewAccountName.TabIndex = 4;
            // 
            // btnAddAccount
            // 
            this.btnAddAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddAccount.Location = new System.Drawing.Point(6, 229);
            this.btnAddAccount.Name = "btnAddAccount";
            this.btnAddAccount.Size = new System.Drawing.Size(236, 33);
            this.btnAddAccount.TabIndex = 3;
            this.btnAddAccount.Text = "Add Account";
            this.btnAddAccount.UseVisualStyleBackColor = true;
            this.btnAddAccount.Click += new System.EventHandler(this.btnAddAccount_Click);
            // 
            // gbxNewAccountClassification
            // 
            this.gbxNewAccountClassification.Controls.Add(this.rdbtnNewLiability);
            this.gbxNewAccountClassification.Controls.Add(this.rdbtnNewAsset);
            this.gbxNewAccountClassification.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gbxNewAccountClassification.Location = new System.Drawing.Point(9, 121);
            this.gbxNewAccountClassification.Name = "gbxNewAccountClassification";
            this.gbxNewAccountClassification.Size = new System.Drawing.Size(234, 48);
            this.gbxNewAccountClassification.TabIndex = 2;
            this.gbxNewAccountClassification.TabStop = false;
            this.gbxNewAccountClassification.Text = "New Account Classification";
            // 
            // rdbtnNewLiability
            // 
            this.rdbtnNewLiability.AutoSize = true;
            this.rdbtnNewLiability.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.rdbtnNewLiability.Location = new System.Drawing.Point(97, 21);
            this.rdbtnNewLiability.Name = "rdbtnNewLiability";
            this.rdbtnNewLiability.Size = new System.Drawing.Size(66, 19);
            this.rdbtnNewLiability.TabIndex = 1;
            this.rdbtnNewLiability.TabStop = true;
            this.rdbtnNewLiability.Text = "Liability";
            this.rdbtnNewLiability.UseVisualStyleBackColor = true;
            // 
            // rdbtnNewAsset
            // 
            this.rdbtnNewAsset.AutoSize = true;
            this.rdbtnNewAsset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.rdbtnNewAsset.Location = new System.Drawing.Point(11, 21);
            this.rdbtnNewAsset.Name = "rdbtnNewAsset";
            this.rdbtnNewAsset.Size = new System.Drawing.Size(54, 19);
            this.rdbtnNewAsset.TabIndex = 0;
            this.rdbtnNewAsset.TabStop = true;
            this.rdbtnNewAsset.Text = "Asset";
            this.rdbtnNewAsset.UseVisualStyleBackColor = true;
            // 
            // lblNewAccountBalance
            // 
            this.lblNewAccountBalance.AutoSize = true;
            this.lblNewAccountBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewAccountBalance.Location = new System.Drawing.Point(4, 74);
            this.lblNewAccountBalance.Name = "lblNewAccountBalance";
            this.lblNewAccountBalance.Size = new System.Drawing.Size(145, 17);
            this.lblNewAccountBalance.TabIndex = 1;
            this.lblNewAccountBalance.Text = "New Account Balance";
            // 
            // lblNewAccountName
            // 
            this.lblNewAccountName.AutoSize = true;
            this.lblNewAccountName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewAccountName.Location = new System.Drawing.Point(4, 27);
            this.lblNewAccountName.Name = "lblNewAccountName";
            this.lblNewAccountName.Size = new System.Drawing.Size(131, 17);
            this.lblNewAccountName.TabIndex = 0;
            this.lblNewAccountName.Text = "New Account Name";
            // 
            // gpbxEditAccount
            // 
            this.gpbxEditAccount.Controls.Add(this.gpbxSelectedAccountStatus);
            this.gpbxEditAccount.Controls.Add(this.gpbxUpdatedAccountStatus);
            this.gpbxEditAccount.Controls.Add(this.gpbxUpdatedAccountClassification);
            this.gpbxEditAccount.Controls.Add(this.txtbxUpdatedAccountBalance);
            this.gpbxEditAccount.Controls.Add(this.txtbxUpdatedAccountName);
            this.gpbxEditAccount.Controls.Add(this.txtbxSelectedAccountBalance);
            this.gpbxEditAccount.Controls.Add(this.txtbxSelectedAccount);
            this.gpbxEditAccount.Controls.Add(this.btnUpdateAccount);
            this.gpbxEditAccount.Controls.Add(this.lblUpdatedAccountBalance);
            this.gpbxEditAccount.Controls.Add(this.lblUpdatedAccountName);
            this.gpbxEditAccount.Controls.Add(this.gpbxEditAccountClassification);
            this.gpbxEditAccount.Controls.Add(this.lblSelectedAccountBalance);
            this.gpbxEditAccount.Controls.Add(this.lblSelectedAccount);
            this.gpbxEditAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.gpbxEditAccount.Location = new System.Drawing.Point(12, 292);
            this.gpbxEditAccount.Name = "gpbxEditAccount";
            this.gpbxEditAccount.Size = new System.Drawing.Size(253, 474);
            this.gpbxEditAccount.TabIndex = 3;
            this.gpbxEditAccount.TabStop = false;
            this.gpbxEditAccount.Text = "Edit Account";
            // 
            // gpbxUpdatedAccountClassification
            // 
            this.gpbxUpdatedAccountClassification.Controls.Add(this.rdbtnUpdatedAccountLiability);
            this.gpbxUpdatedAccountClassification.Controls.Add(this.rdbtnUpdatedAccountAsset);
            this.gpbxUpdatedAccountClassification.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gpbxUpdatedAccountClassification.Location = new System.Drawing.Point(7, 331);
            this.gpbxUpdatedAccountClassification.Name = "gpbxUpdatedAccountClassification";
            this.gpbxUpdatedAccountClassification.Size = new System.Drawing.Size(232, 45);
            this.gpbxUpdatedAccountClassification.TabIndex = 4;
            this.gpbxUpdatedAccountClassification.TabStop = false;
            this.gpbxUpdatedAccountClassification.Text = "Updated Account Classification";
            // 
            // rdbtnUpdatedAccountLiability
            // 
            this.rdbtnUpdatedAccountLiability.AutoSize = true;
            this.rdbtnUpdatedAccountLiability.Location = new System.Drawing.Point(97, 19);
            this.rdbtnUpdatedAccountLiability.Name = "rdbtnUpdatedAccountLiability";
            this.rdbtnUpdatedAccountLiability.Size = new System.Drawing.Size(66, 19);
            this.rdbtnUpdatedAccountLiability.TabIndex = 1;
            this.rdbtnUpdatedAccountLiability.TabStop = true;
            this.rdbtnUpdatedAccountLiability.Text = "Liability";
            this.rdbtnUpdatedAccountLiability.UseVisualStyleBackColor = true;
            // 
            // rdbtnUpdatedAccountAsset
            // 
            this.rdbtnUpdatedAccountAsset.AutoSize = true;
            this.rdbtnUpdatedAccountAsset.Location = new System.Drawing.Point(6, 19);
            this.rdbtnUpdatedAccountAsset.Name = "rdbtnUpdatedAccountAsset";
            this.rdbtnUpdatedAccountAsset.Size = new System.Drawing.Size(54, 19);
            this.rdbtnUpdatedAccountAsset.TabIndex = 0;
            this.rdbtnUpdatedAccountAsset.TabStop = true;
            this.rdbtnUpdatedAccountAsset.Text = "Asset";
            this.rdbtnUpdatedAccountAsset.UseVisualStyleBackColor = true;
            // 
            // txtbxUpdatedAccountBalance
            // 
            this.txtbxUpdatedAccountBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtbxUpdatedAccountBalance.Location = new System.Drawing.Point(9, 300);
            this.txtbxUpdatedAccountBalance.Name = "txtbxUpdatedAccountBalance";
            this.txtbxUpdatedAccountBalance.Size = new System.Drawing.Size(232, 24);
            this.txtbxUpdatedAccountBalance.TabIndex = 9;
            this.txtbxUpdatedAccountBalance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbxUpdatedAccountBalance_KeyPress);
            // 
            // txtbxUpdatedAccountName
            // 
            this.txtbxUpdatedAccountName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtbxUpdatedAccountName.Location = new System.Drawing.Point(9, 247);
            this.txtbxUpdatedAccountName.Name = "txtbxUpdatedAccountName";
            this.txtbxUpdatedAccountName.Size = new System.Drawing.Size(230, 24);
            this.txtbxUpdatedAccountName.TabIndex = 8;
            // 
            // txtbxSelectedAccountBalance
            // 
            this.txtbxSelectedAccountBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtbxSelectedAccountBalance.Location = new System.Drawing.Point(6, 94);
            this.txtbxSelectedAccountBalance.Name = "txtbxSelectedAccountBalance";
            this.txtbxSelectedAccountBalance.ReadOnly = true;
            this.txtbxSelectedAccountBalance.Size = new System.Drawing.Size(233, 24);
            this.txtbxSelectedAccountBalance.TabIndex = 7;
            // 
            // txtbxSelectedAccount
            // 
            this.txtbxSelectedAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtbxSelectedAccount.Location = new System.Drawing.Point(6, 46);
            this.txtbxSelectedAccount.Name = "txtbxSelectedAccount";
            this.txtbxSelectedAccount.ReadOnly = true;
            this.txtbxSelectedAccount.Size = new System.Drawing.Size(233, 24);
            this.txtbxSelectedAccount.TabIndex = 6;
            // 
            // btnUpdateAccount
            // 
            this.btnUpdateAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnUpdateAccount.Location = new System.Drawing.Point(7, 434);
            this.btnUpdateAccount.Name = "btnUpdateAccount";
            this.btnUpdateAccount.Size = new System.Drawing.Size(236, 33);
            this.btnUpdateAccount.TabIndex = 4;
            this.btnUpdateAccount.Text = "Update Account";
            this.btnUpdateAccount.UseVisualStyleBackColor = true;
            this.btnUpdateAccount.Click += new System.EventHandler(this.btnUpdateAccount_Click);
            // 
            // lblUpdatedAccountBalance
            // 
            this.lblUpdatedAccountBalance.AutoSize = true;
            this.lblUpdatedAccountBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblUpdatedAccountBalance.Location = new System.Drawing.Point(6, 279);
            this.lblUpdatedAccountBalance.Name = "lblUpdatedAccountBalance";
            this.lblUpdatedAccountBalance.Size = new System.Drawing.Size(178, 18);
            this.lblUpdatedAccountBalance.TabIndex = 5;
            this.lblUpdatedAccountBalance.Text = "Updated Account Balance";
            // 
            // lblUpdatedAccountName
            // 
            this.lblUpdatedAccountName.AutoSize = true;
            this.lblUpdatedAccountName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblUpdatedAccountName.Location = new System.Drawing.Point(6, 226);
            this.lblUpdatedAccountName.Name = "lblUpdatedAccountName";
            this.lblUpdatedAccountName.Size = new System.Drawing.Size(165, 18);
            this.lblUpdatedAccountName.TabIndex = 4;
            this.lblUpdatedAccountName.Text = "Updated Account Name";
            // 
            // gpbxEditAccountClassification
            // 
            this.gpbxEditAccountClassification.Controls.Add(this.rdbtnSelectedAccountLiability);
            this.gpbxEditAccountClassification.Controls.Add(this.rdbtnSelectedAccountAsset);
            this.gpbxEditAccountClassification.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gpbxEditAccountClassification.Location = new System.Drawing.Point(6, 122);
            this.gpbxEditAccountClassification.Name = "gpbxEditAccountClassification";
            this.gpbxEditAccountClassification.Size = new System.Drawing.Size(233, 48);
            this.gpbxEditAccountClassification.TabIndex = 3;
            this.gpbxEditAccountClassification.TabStop = false;
            this.gpbxEditAccountClassification.Text = "Selected Account Classification";
            // 
            // rdbtnSelectedAccountLiability
            // 
            this.rdbtnSelectedAccountLiability.AutoCheck = false;
            this.rdbtnSelectedAccountLiability.AutoSize = true;
            this.rdbtnSelectedAccountLiability.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.rdbtnSelectedAccountLiability.Location = new System.Drawing.Point(97, 21);
            this.rdbtnSelectedAccountLiability.Name = "rdbtnSelectedAccountLiability";
            this.rdbtnSelectedAccountLiability.Size = new System.Drawing.Size(66, 19);
            this.rdbtnSelectedAccountLiability.TabIndex = 1;
            this.rdbtnSelectedAccountLiability.TabStop = true;
            this.rdbtnSelectedAccountLiability.Text = "Liability";
            this.rdbtnSelectedAccountLiability.UseVisualStyleBackColor = true;
            // 
            // rdbtnSelectedAccountAsset
            // 
            this.rdbtnSelectedAccountAsset.AutoCheck = false;
            this.rdbtnSelectedAccountAsset.AutoSize = true;
            this.rdbtnSelectedAccountAsset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.rdbtnSelectedAccountAsset.Location = new System.Drawing.Point(6, 21);
            this.rdbtnSelectedAccountAsset.Name = "rdbtnSelectedAccountAsset";
            this.rdbtnSelectedAccountAsset.Size = new System.Drawing.Size(54, 19);
            this.rdbtnSelectedAccountAsset.TabIndex = 0;
            this.rdbtnSelectedAccountAsset.TabStop = true;
            this.rdbtnSelectedAccountAsset.Text = "Asset";
            this.rdbtnSelectedAccountAsset.UseVisualStyleBackColor = true;
            // 
            // lblSelectedAccountBalance
            // 
            this.lblSelectedAccountBalance.AutoSize = true;
            this.lblSelectedAccountBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblSelectedAccountBalance.Location = new System.Drawing.Point(3, 75);
            this.lblSelectedAccountBalance.Name = "lblSelectedAccountBalance";
            this.lblSelectedAccountBalance.Size = new System.Drawing.Size(180, 18);
            this.lblSelectedAccountBalance.TabIndex = 1;
            this.lblSelectedAccountBalance.Text = "Selected Account Balance";
            // 
            // lblSelectedAccount
            // 
            this.lblSelectedAccount.AutoSize = true;
            this.lblSelectedAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblSelectedAccount.Location = new System.Drawing.Point(3, 25);
            this.lblSelectedAccount.Name = "lblSelectedAccount";
            this.lblSelectedAccount.Size = new System.Drawing.Size(123, 18);
            this.lblSelectedAccount.TabIndex = 0;
            this.lblSelectedAccount.Text = "Selected Account";
            // 
            // gpbxNewAccountStatus
            // 
            this.gpbxNewAccountStatus.Controls.Add(this.rdbtnNewAccountInactive);
            this.gpbxNewAccountStatus.Controls.Add(this.rdbtnNewAccountActive);
            this.gpbxNewAccountStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gpbxNewAccountStatus.Location = new System.Drawing.Point(9, 172);
            this.gpbxNewAccountStatus.Name = "gpbxNewAccountStatus";
            this.gpbxNewAccountStatus.Size = new System.Drawing.Size(234, 48);
            this.gpbxNewAccountStatus.TabIndex = 3;
            this.gpbxNewAccountStatus.TabStop = false;
            this.gpbxNewAccountStatus.Text = "New Account Status";
            // 
            // rdbtnNewAccountInactive
            // 
            this.rdbtnNewAccountInactive.AutoSize = true;
            this.rdbtnNewAccountInactive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.rdbtnNewAccountInactive.Location = new System.Drawing.Point(97, 21);
            this.rdbtnNewAccountInactive.Name = "rdbtnNewAccountInactive";
            this.rdbtnNewAccountInactive.Size = new System.Drawing.Size(66, 19);
            this.rdbtnNewAccountInactive.TabIndex = 1;
            this.rdbtnNewAccountInactive.TabStop = true;
            this.rdbtnNewAccountInactive.Text = "Inactive";
            this.rdbtnNewAccountInactive.UseVisualStyleBackColor = true;
            // 
            // rdbtnNewAccountActive
            // 
            this.rdbtnNewAccountActive.AutoSize = true;
            this.rdbtnNewAccountActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.rdbtnNewAccountActive.Location = new System.Drawing.Point(11, 21);
            this.rdbtnNewAccountActive.Name = "rdbtnNewAccountActive";
            this.rdbtnNewAccountActive.Size = new System.Drawing.Size(56, 19);
            this.rdbtnNewAccountActive.TabIndex = 0;
            this.rdbtnNewAccountActive.TabStop = true;
            this.rdbtnNewAccountActive.Text = "Active";
            this.rdbtnNewAccountActive.UseVisualStyleBackColor = true;
            // 
            // gpbxUpdatedAccountStatus
            // 
            this.gpbxUpdatedAccountStatus.Controls.Add(this.rdbtnUpdatedAccountInactive);
            this.gpbxUpdatedAccountStatus.Controls.Add(this.rdbtnUpdatedAccountActive);
            this.gpbxUpdatedAccountStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gpbxUpdatedAccountStatus.Location = new System.Drawing.Point(6, 382);
            this.gpbxUpdatedAccountStatus.Name = "gpbxUpdatedAccountStatus";
            this.gpbxUpdatedAccountStatus.Size = new System.Drawing.Size(232, 45);
            this.gpbxUpdatedAccountStatus.TabIndex = 10;
            this.gpbxUpdatedAccountStatus.TabStop = false;
            this.gpbxUpdatedAccountStatus.Text = "Updated Account Status";
            // 
            // rdbtnUpdatedAccountInactive
            // 
            this.rdbtnUpdatedAccountInactive.AutoSize = true;
            this.rdbtnUpdatedAccountInactive.Location = new System.Drawing.Point(97, 19);
            this.rdbtnUpdatedAccountInactive.Name = "rdbtnUpdatedAccountInactive";
            this.rdbtnUpdatedAccountInactive.Size = new System.Drawing.Size(66, 19);
            this.rdbtnUpdatedAccountInactive.TabIndex = 1;
            this.rdbtnUpdatedAccountInactive.TabStop = true;
            this.rdbtnUpdatedAccountInactive.Text = "Inactive";
            this.rdbtnUpdatedAccountInactive.UseVisualStyleBackColor = true;
            // 
            // rdbtnUpdatedAccountActive
            // 
            this.rdbtnUpdatedAccountActive.AutoSize = true;
            this.rdbtnUpdatedAccountActive.Location = new System.Drawing.Point(6, 19);
            this.rdbtnUpdatedAccountActive.Name = "rdbtnUpdatedAccountActive";
            this.rdbtnUpdatedAccountActive.Size = new System.Drawing.Size(56, 19);
            this.rdbtnUpdatedAccountActive.TabIndex = 0;
            this.rdbtnUpdatedAccountActive.TabStop = true;
            this.rdbtnUpdatedAccountActive.Text = "Active";
            this.rdbtnUpdatedAccountActive.UseVisualStyleBackColor = true;
            // 
            // gpbxSelectedAccountStatus
            // 
            this.gpbxSelectedAccountStatus.Controls.Add(this.rdbtnSelectedAccountInactive);
            this.gpbxSelectedAccountStatus.Controls.Add(this.rdbtnSelectedAccountActive);
            this.gpbxSelectedAccountStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gpbxSelectedAccountStatus.Location = new System.Drawing.Point(6, 173);
            this.gpbxSelectedAccountStatus.Name = "gpbxSelectedAccountStatus";
            this.gpbxSelectedAccountStatus.Size = new System.Drawing.Size(233, 48);
            this.gpbxSelectedAccountStatus.TabIndex = 4;
            this.gpbxSelectedAccountStatus.TabStop = false;
            this.gpbxSelectedAccountStatus.Text = "Selected Account Status";
            // 
            // rdbtnSelectedAccountInactive
            // 
            this.rdbtnSelectedAccountInactive.AutoCheck = false;
            this.rdbtnSelectedAccountInactive.AutoSize = true;
            this.rdbtnSelectedAccountInactive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.rdbtnSelectedAccountInactive.Location = new System.Drawing.Point(97, 21);
            this.rdbtnSelectedAccountInactive.Name = "rdbtnSelectedAccountInactive";
            this.rdbtnSelectedAccountInactive.Size = new System.Drawing.Size(66, 19);
            this.rdbtnSelectedAccountInactive.TabIndex = 1;
            this.rdbtnSelectedAccountInactive.TabStop = true;
            this.rdbtnSelectedAccountInactive.Text = "Inactive";
            this.rdbtnSelectedAccountInactive.UseVisualStyleBackColor = true;
            // 
            // rdbtnSelectedAccountActive
            // 
            this.rdbtnSelectedAccountActive.AutoCheck = false;
            this.rdbtnSelectedAccountActive.AutoSize = true;
            this.rdbtnSelectedAccountActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.rdbtnSelectedAccountActive.Location = new System.Drawing.Point(6, 21);
            this.rdbtnSelectedAccountActive.Name = "rdbtnSelectedAccountActive";
            this.rdbtnSelectedAccountActive.Size = new System.Drawing.Size(56, 19);
            this.rdbtnSelectedAccountActive.TabIndex = 0;
            this.rdbtnSelectedAccountActive.TabStop = true;
            this.rdbtnSelectedAccountActive.Text = "Active";
            this.rdbtnSelectedAccountActive.UseVisualStyleBackColor = true;
            // 
            // btnFinished
            // 
            this.btnFinished.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnFinished.Location = new System.Drawing.Point(720, 13);
            this.btnFinished.Name = "btnFinished";
            this.btnFinished.Size = new System.Drawing.Size(225, 40);
            this.btnFinished.TabIndex = 4;
            this.btnFinished.Text = "Finished Managing Accounts";
            this.btnFinished.UseVisualStyleBackColor = true;
            this.btnFinished.Click += new System.EventHandler(this.btnFinished_Click);
            // 
            // AccountManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 789);
            this.Controls.Add(this.btnFinished);
            this.Controls.Add(this.gpbxEditAccount);
            this.Controls.Add(this.gbxAddAccount);
            this.Controls.Add(this.lblAccountDGV);
            this.Controls.Add(this.dgvAccounts);
            this.Name = "AccountManager";
            this.Text = "AccountManager";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccounts)).EndInit();
            this.gbxAddAccount.ResumeLayout(false);
            this.gbxAddAccount.PerformLayout();
            this.gbxNewAccountClassification.ResumeLayout(false);
            this.gbxNewAccountClassification.PerformLayout();
            this.gpbxEditAccount.ResumeLayout(false);
            this.gpbxEditAccount.PerformLayout();
            this.gpbxUpdatedAccountClassification.ResumeLayout(false);
            this.gpbxUpdatedAccountClassification.PerformLayout();
            this.gpbxEditAccountClassification.ResumeLayout(false);
            this.gpbxEditAccountClassification.PerformLayout();
            this.gpbxNewAccountStatus.ResumeLayout(false);
            this.gpbxNewAccountStatus.PerformLayout();
            this.gpbxUpdatedAccountStatus.ResumeLayout(false);
            this.gpbxUpdatedAccountStatus.PerformLayout();
            this.gpbxSelectedAccountStatus.ResumeLayout(false);
            this.gpbxSelectedAccountStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAccounts;
        private System.Windows.Forms.Label lblAccountDGV;
        private System.Windows.Forms.GroupBox gbxAddAccount;
        private System.Windows.Forms.TextBox txtbxNewAccountBalance;
        private System.Windows.Forms.TextBox txtbxNewAccountName;
        private System.Windows.Forms.Button btnAddAccount;
        private System.Windows.Forms.GroupBox gbxNewAccountClassification;
        private System.Windows.Forms.RadioButton rdbtnNewLiability;
        private System.Windows.Forms.RadioButton rdbtnNewAsset;
        private System.Windows.Forms.Label lblNewAccountBalance;
        private System.Windows.Forms.Label lblNewAccountName;
        private System.Windows.Forms.GroupBox gpbxEditAccount;
        private System.Windows.Forms.GroupBox gpbxUpdatedAccountClassification;
        private System.Windows.Forms.RadioButton rdbtnUpdatedAccountLiability;
        private System.Windows.Forms.RadioButton rdbtnUpdatedAccountAsset;
        private System.Windows.Forms.TextBox txtbxUpdatedAccountBalance;
        private System.Windows.Forms.TextBox txtbxUpdatedAccountName;
        private System.Windows.Forms.TextBox txtbxSelectedAccountBalance;
        private System.Windows.Forms.TextBox txtbxSelectedAccount;
        private System.Windows.Forms.Button btnUpdateAccount;
        private System.Windows.Forms.Label lblUpdatedAccountBalance;
        private System.Windows.Forms.Label lblUpdatedAccountName;
        private System.Windows.Forms.GroupBox gpbxEditAccountClassification;
        private System.Windows.Forms.RadioButton rdbtnSelectedAccountLiability;
        private System.Windows.Forms.RadioButton rdbtnSelectedAccountAsset;
        private System.Windows.Forms.Label lblSelectedAccountBalance;
        private System.Windows.Forms.Label lblSelectedAccount;
        private System.Windows.Forms.GroupBox gpbxNewAccountStatus;
        private System.Windows.Forms.RadioButton rdbtnNewAccountInactive;
        private System.Windows.Forms.RadioButton rdbtnNewAccountActive;
        private System.Windows.Forms.GroupBox gpbxSelectedAccountStatus;
        private System.Windows.Forms.RadioButton rdbtnSelectedAccountInactive;
        private System.Windows.Forms.RadioButton rdbtnSelectedAccountActive;
        private System.Windows.Forms.GroupBox gpbxUpdatedAccountStatus;
        private System.Windows.Forms.RadioButton rdbtnUpdatedAccountInactive;
        private System.Windows.Forms.RadioButton rdbtnUpdatedAccountActive;
        private System.Windows.Forms.Button btnFinished;
    }
}