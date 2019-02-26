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
            this.bankInfo = new System.Windows.Forms.Button();
            this.companyInfo = new System.Windows.Forms.Button();
            this.closeBtn = new System.Windows.Forms.Button();
            this.generateFile = new System.Windows.Forms.Button();
            this.companySimpleDtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.companyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.organizationInfo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.companySimpleDtoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bankInfo
            // 
            this.bankInfo.Location = new System.Drawing.Point(8, 8);
            this.bankInfo.Name = "bankInfo";
            this.bankInfo.Size = new System.Drawing.Size(216, 32);
            this.bankInfo.TabIndex = 0;
            this.bankInfo.Text = "Информация о банках";
            this.bankInfo.UseVisualStyleBackColor = true;
            // 
            // companyInfo
            // 
            this.companyInfo.Location = new System.Drawing.Point(8, 56);
            this.companyInfo.Name = "companyInfo";
            this.companyInfo.Size = new System.Drawing.Size(216, 32);
            this.companyInfo.TabIndex = 1;
            this.companyInfo.Text = "Информация о компаниях";
            this.companyInfo.UseVisualStyleBackColor = true;
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(8, 216);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(216, 34);
            this.closeBtn.TabIndex = 2;
            this.closeBtn.Text = "Закрыть приложение";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // generateFile
            // 
            this.generateFile.Location = new System.Drawing.Point(8, 152);
            this.generateFile.Name = "generateFile";
            this.generateFile.Size = new System.Drawing.Size(216, 34);
            this.generateFile.TabIndex = 3;
            this.generateFile.Text = "Создание файла";
            this.generateFile.UseVisualStyleBackColor = true;
            // 
            // companySimpleDtoBindingSource
            // 
            this.companySimpleDtoBindingSource.DataSource = typeof(DataAccessLayer.DTO.CompanySimpleDto);
            // 
            // companyBindingSource
            // 
            this.companyBindingSource.DataSource = typeof(DataAccessLayer.Entity.Company);
            // 
            // organizationInfo
            // 
            this.organizationInfo.Location = new System.Drawing.Point(8, 104);
            this.organizationInfo.Name = "organizationInfo";
            this.organizationInfo.Size = new System.Drawing.Size(216, 32);
            this.organizationInfo.TabIndex = 4;
            this.organizationInfo.Text = "Информация о организациях";
            this.organizationInfo.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(233, 257);
            this.Controls.Add(this.organizationInfo);
            this.Controls.Add(this.generateFile);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.companyInfo);
            this.Controls.Add(this.bankInfo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bookkeppeng text generator";
            ((System.ComponentModel.ISupportInitialize)(this.companySimpleDtoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bankInfo;
        private System.Windows.Forms.Button companyInfo;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Button generateFile;
        private System.Windows.Forms.BindingSource companySimpleDtoBindingSource;
        private System.Windows.Forms.BindingSource companyBindingSource;
        private System.Windows.Forms.Button organizationInfo;
    }
}

