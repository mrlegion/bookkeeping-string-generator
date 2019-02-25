namespace WFApp
{
    partial class AddCompanyForm
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
            this.components = new System.ComponentModel.Container();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.NumberAccountLabel = new System.Windows.Forms.Label();
            this.CNumberAccount = new System.Windows.Forms.TextBox();
            this.CKppLabel = new System.Windows.Forms.Label();
            this.CKpp = new System.Windows.Forms.TextBox();
            this.CityLabel = new System.Windows.Forms.Label();
            this.CInn = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CName = new System.Windows.Forms.TextBox();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.CBankLabel = new System.Windows.Forms.Label();
            this.BankList = new System.Windows.Forms.ComboBox();
            this.bankBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bankBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(251, 338);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 33);
            this.CancelBtn.TabIndex = 21;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(16, 338);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(156, 33);
            this.SaveBtn.TabIndex = 20;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // NumberAccountLabel
            // 
            this.NumberAccountLabel.AutoSize = true;
            this.NumberAccountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NumberAccountLabel.Location = new System.Drawing.Point(13, 211);
            this.NumberAccountLabel.Name = "NumberAccountLabel";
            this.NumberAccountLabel.Size = new System.Drawing.Size(106, 16);
            this.NumberAccountLabel.TabIndex = 19;
            this.NumberAccountLabel.Text = "Number account";
            // 
            // CNumberAccount
            // 
            this.CNumberAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CNumberAccount.Location = new System.Drawing.Point(16, 230);
            this.CNumberAccount.Name = "CNumberAccount";
            this.CNumberAccount.Size = new System.Drawing.Size(311, 22);
            this.CNumberAccount.TabIndex = 18;
            // 
            // CKppLabel
            // 
            this.CKppLabel.AutoSize = true;
            this.CKppLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CKppLabel.Location = new System.Drawing.Point(13, 157);
            this.CKppLabel.Name = "CKppLabel";
            this.CKppLabel.Size = new System.Drawing.Size(34, 16);
            this.CKppLabel.TabIndex = 17;
            this.CKppLabel.Text = "KPP";
            // 
            // CKpp
            // 
            this.CKpp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CKpp.Location = new System.Drawing.Point(16, 176);
            this.CKpp.Name = "CKpp";
            this.CKpp.Size = new System.Drawing.Size(311, 22);
            this.CKpp.TabIndex = 16;
            // 
            // CityLabel
            // 
            this.CityLabel.AutoSize = true;
            this.CityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CityLabel.Location = new System.Drawing.Point(12, 103);
            this.CityLabel.Name = "CityLabel";
            this.CityLabel.Size = new System.Drawing.Size(31, 16);
            this.CityLabel.TabIndex = 15;
            this.CityLabel.Text = "INN";
            // 
            // CInn
            // 
            this.CInn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CInn.Location = new System.Drawing.Point(15, 122);
            this.CInn.Name = "CInn";
            this.CInn.Size = new System.Drawing.Size(311, 22);
            this.CInn.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(13, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "Name of Company";
            // 
            // CName
            // 
            this.CName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CName.Location = new System.Drawing.Point(16, 68);
            this.CName.Name = "CName";
            this.CName.Size = new System.Drawing.Size(311, 22);
            this.CName.TabIndex = 12;
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TitleLabel.Location = new System.Drawing.Point(12, 9);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(243, 24);
            this.TitleLabel.TabIndex = 11;
            this.TitleLabel.Text = "Add new Company to DB";
            // 
            // CBankLabel
            // 
            this.CBankLabel.AutoSize = true;
            this.CBankLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CBankLabel.Location = new System.Drawing.Point(13, 265);
            this.CBankLabel.Name = "CBankLabel";
            this.CBankLabel.Size = new System.Drawing.Size(39, 16);
            this.CBankLabel.TabIndex = 23;
            this.CBankLabel.Text = "Bank";
            // 
            // BankList
            // 
            this.BankList.DataSource = this.bankBindingSource;
            this.BankList.DisplayMember = "Name";
            this.BankList.FormattingEnabled = true;
            this.BankList.Location = new System.Drawing.Point(16, 284);
            this.BankList.Name = "BankList";
            this.BankList.Size = new System.Drawing.Size(311, 21);
            this.BankList.TabIndex = 24;
            this.BankList.ValueMember = "Id";
            // 
            // bankBindingSource
            // 
            this.bankBindingSource.DataSource = typeof(DataAccessLayer.Entity.Bank);
            // 
            // AddCompanyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 386);
            this.Controls.Add(this.BankList);
            this.Controls.Add(this.CBankLabel);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.NumberAccountLabel);
            this.Controls.Add(this.CNumberAccount);
            this.Controls.Add(this.CKppLabel);
            this.Controls.Add(this.CKpp);
            this.Controls.Add(this.CityLabel);
            this.Controls.Add(this.CInn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CName);
            this.Controls.Add(this.TitleLabel);
            this.Name = "AddCompanyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddCompanyForm";
            ((System.ComponentModel.ISupportInitialize)(this.bankBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Label NumberAccountLabel;
        private System.Windows.Forms.TextBox CNumberAccount;
        private System.Windows.Forms.Label CKppLabel;
        private System.Windows.Forms.TextBox CKpp;
        private System.Windows.Forms.Label CityLabel;
        private System.Windows.Forms.TextBox CInn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox CName;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label CBankLabel;
        private System.Windows.Forms.ComboBox BankList;
        private System.Windows.Forms.BindingSource bankBindingSource;
    }
}