namespace WFApp
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AddBankBtn = new System.Windows.Forms.Button();
            this.AddCompanyBtn = new System.Windows.Forms.Button();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.CompanyInfo = new System.Windows.Forms.DataGridView();
            this.companySimpleDtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.companyIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bankIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.companyNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.companyInnDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.companyKppDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bankNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companySimpleDtoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // AddBankBtn
            // 
            this.AddBankBtn.Location = new System.Drawing.Point(12, 12);
            this.AddBankBtn.Name = "AddBankBtn";
            this.AddBankBtn.Size = new System.Drawing.Size(125, 34);
            this.AddBankBtn.TabIndex = 0;
            this.AddBankBtn.Text = "Add new Bank";
            this.AddBankBtn.UseVisualStyleBackColor = true;
            this.AddBankBtn.Click += new System.EventHandler(this.Button1_Click);
            // 
            // AddCompanyBtn
            // 
            this.AddCompanyBtn.Location = new System.Drawing.Point(153, 12);
            this.AddCompanyBtn.Name = "AddCompanyBtn";
            this.AddCompanyBtn.Size = new System.Drawing.Size(149, 34);
            this.AddCompanyBtn.TabIndex = 1;
            this.AddCompanyBtn.Text = "Add new Company";
            this.AddCompanyBtn.UseVisualStyleBackColor = true;
            this.AddCompanyBtn.Click += new System.EventHandler(this.AddCompanyBtn_Click);
            // 
            // CloseBtn
            // 
            this.CloseBtn.Location = new System.Drawing.Point(556, 314);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(105, 34);
            this.CloseBtn.TabIndex = 2;
            this.CloseBtn.Text = "Close App";
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(371, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(290, 34);
            this.button4.TabIndex = 3;
            this.button4.Text = "Generate new text file";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // CompanyInfo
            // 
            this.CompanyInfo.AllowUserToAddRows = false;
            this.CompanyInfo.AllowUserToDeleteRows = false;
            this.CompanyInfo.AutoGenerateColumns = false;
            this.CompanyInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CompanyInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.companyIdDataGridViewTextBoxColumn,
            this.bankIdDataGridViewTextBoxColumn,
            this.companyNameDataGridViewTextBoxColumn,
            this.companyInnDataGridViewTextBoxColumn,
            this.companyKppDataGridViewTextBoxColumn,
            this.bankNameDataGridViewTextBoxColumn});
            this.CompanyInfo.DataSource = this.companySimpleDtoBindingSource;
            this.CompanyInfo.Location = new System.Drawing.Point(12, 52);
            this.CompanyInfo.Name = "CompanyInfo";
            this.CompanyInfo.ReadOnly = true;
            this.CompanyInfo.Size = new System.Drawing.Size(649, 247);
            this.CompanyInfo.TabIndex = 4;
            this.CompanyInfo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.EditCompanyClick);
            // 
            // companySimpleDtoBindingSource
            // 
            this.companySimpleDtoBindingSource.DataSource = typeof(DataAccessLayer.DTO.CompanySimpleDto);
            // 
            // companyIdDataGridViewTextBoxColumn
            // 
            this.companyIdDataGridViewTextBoxColumn.DataPropertyName = "CompanyId";
            this.companyIdDataGridViewTextBoxColumn.HeaderText = "CompanyId";
            this.companyIdDataGridViewTextBoxColumn.Name = "companyIdDataGridViewTextBoxColumn";
            this.companyIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.companyIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // bankIdDataGridViewTextBoxColumn
            // 
            this.bankIdDataGridViewTextBoxColumn.DataPropertyName = "BankId";
            this.bankIdDataGridViewTextBoxColumn.HeaderText = "BankId";
            this.bankIdDataGridViewTextBoxColumn.Name = "bankIdDataGridViewTextBoxColumn";
            this.bankIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.bankIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // companyNameDataGridViewTextBoxColumn
            // 
            this.companyNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.companyNameDataGridViewTextBoxColumn.DataPropertyName = "CompanyName";
            this.companyNameDataGridViewTextBoxColumn.HeaderText = "CompanyName";
            this.companyNameDataGridViewTextBoxColumn.Name = "companyNameDataGridViewTextBoxColumn";
            this.companyNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // companyInnDataGridViewTextBoxColumn
            // 
            this.companyInnDataGridViewTextBoxColumn.DataPropertyName = "CompanyInn";
            this.companyInnDataGridViewTextBoxColumn.HeaderText = "CompanyInn";
            this.companyInnDataGridViewTextBoxColumn.Name = "companyInnDataGridViewTextBoxColumn";
            this.companyInnDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // companyKppDataGridViewTextBoxColumn
            // 
            this.companyKppDataGridViewTextBoxColumn.DataPropertyName = "CompanyKpp";
            this.companyKppDataGridViewTextBoxColumn.HeaderText = "CompanyKpp";
            this.companyKppDataGridViewTextBoxColumn.Name = "companyKppDataGridViewTextBoxColumn";
            this.companyKppDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bankNameDataGridViewTextBoxColumn
            // 
            this.bankNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.bankNameDataGridViewTextBoxColumn.DataPropertyName = "BankName";
            this.bankNameDataGridViewTextBoxColumn.HeaderText = "BankName";
            this.bankNameDataGridViewTextBoxColumn.Name = "bankNameDataGridViewTextBoxColumn";
            this.bankNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.bankNameDataGridViewTextBoxColumn.Width = 101;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(673, 359);
            this.Controls.Add(this.CompanyInfo);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.AddCompanyBtn);
            this.Controls.Add(this.AddBankBtn);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bookkeppeng text generator";
            ((System.ComponentModel.ISupportInitialize)(this.CompanyInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companySimpleDtoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AddBankBtn;
        private System.Windows.Forms.Button AddCompanyBtn;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView CompanyInfo;
        private System.Windows.Forms.BindingSource companySimpleDtoBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn companyIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bankIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn companyNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn companyInnDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn companyKppDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bankNameDataGridViewTextBoxColumn;
    }
}

