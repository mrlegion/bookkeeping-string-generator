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
            this.AddBankBtn = new System.Windows.Forms.Button();
            this.AddCompanyBtn = new System.Windows.Forms.Button();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 52);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(649, 247);
            this.dataGridView1.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(673, 359);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.AddCompanyBtn);
            this.Controls.Add(this.AddBankBtn);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bookkeppeng text generator";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AddBankBtn;
        private System.Windows.Forms.Button AddCompanyBtn;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

