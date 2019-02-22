namespace WFApp
{
    partial class AddBankForm
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
            this.TitleLabel = new System.Windows.Forms.Label();
            this.BName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CityLabel = new System.Windows.Forms.Label();
            this.BCity = new System.Windows.Forms.TextBox();
            this.BikLabel = new System.Windows.Forms.Label();
            this.BBik = new System.Windows.Forms.TextBox();
            this.NumberAccountLabel = new System.Windows.Forms.Label();
            this.BNumberAccount = new System.Windows.Forms.TextBox();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TitleLabel.Location = new System.Drawing.Point(12, 9);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(201, 24);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "Add new Bank to DB";
            // 
            // BName
            // 
            this.BName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BName.Location = new System.Drawing.Point(16, 68);
            this.BName.Name = "BName";
            this.BName.Size = new System.Drawing.Size(311, 22);
            this.BName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(13, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name of Bank";
            // 
            // CityLabel
            // 
            this.CityLabel.AutoSize = true;
            this.CityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CityLabel.Location = new System.Drawing.Point(12, 103);
            this.CityLabel.Name = "CityLabel";
            this.CityLabel.Size = new System.Drawing.Size(139, 16);
            this.CityLabel.TabIndex = 4;
            this.CityLabel.Text = "City where Bank found";
            // 
            // BCity
            // 
            this.BCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BCity.Location = new System.Drawing.Point(15, 122);
            this.BCity.Name = "BCity";
            this.BCity.Size = new System.Drawing.Size(311, 22);
            this.BCity.TabIndex = 3;
            // 
            // BikLabel
            // 
            this.BikLabel.AutoSize = true;
            this.BikLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BikLabel.Location = new System.Drawing.Point(13, 157);
            this.BikLabel.Name = "BikLabel";
            this.BikLabel.Size = new System.Drawing.Size(28, 16);
            this.BikLabel.TabIndex = 6;
            this.BikLabel.Text = "BIK";
            // 
            // BBik
            // 
            this.BBik.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BBik.Location = new System.Drawing.Point(16, 176);
            this.BBik.Name = "BBik";
            this.BBik.Size = new System.Drawing.Size(311, 22);
            this.BBik.TabIndex = 5;
            // 
            // NumberAccountLabel
            // 
            this.NumberAccountLabel.AutoSize = true;
            this.NumberAccountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NumberAccountLabel.Location = new System.Drawing.Point(13, 211);
            this.NumberAccountLabel.Name = "NumberAccountLabel";
            this.NumberAccountLabel.Size = new System.Drawing.Size(106, 16);
            this.NumberAccountLabel.TabIndex = 8;
            this.NumberAccountLabel.Text = "Number account";
            // 
            // BNumberAccount
            // 
            this.BNumberAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BNumberAccount.Location = new System.Drawing.Point(16, 230);
            this.BNumberAccount.Name = "BNumberAccount";
            this.BNumberAccount.Size = new System.Drawing.Size(311, 22);
            this.BNumberAccount.TabIndex = 7;
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(16, 278);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(156, 33);
            this.SaveBtn.TabIndex = 9;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(251, 278);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 33);
            this.CancelBtn.TabIndex = 10;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // AddBankForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(343, 326);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.NumberAccountLabel);
            this.Controls.Add(this.BNumberAccount);
            this.Controls.Add(this.BikLabel);
            this.Controls.Add(this.BBik);
            this.Controls.Add(this.CityLabel);
            this.Controls.Add(this.BCity);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BName);
            this.Controls.Add(this.TitleLabel);
            this.Name = "AddBankForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add or Edit new Bank";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.TextBox BName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label CityLabel;
        private System.Windows.Forms.TextBox BCity;
        private System.Windows.Forms.Label BikLabel;
        private System.Windows.Forms.TextBox BBik;
        private System.Windows.Forms.Label NumberAccountLabel;
        private System.Windows.Forms.TextBox BNumberAccount;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Button CancelBtn;
    }
}