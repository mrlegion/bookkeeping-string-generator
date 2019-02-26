using System;
using System.Linq;
using System.Windows.Forms;
using DataAccessLayer;
using DataAccessLayer.DTO;
using DataAccessLayer.Entity;

namespace WFApp
{
    public partial class AddCompanyForm : Form
    {
        public CompanyDetailDto Company { get; set; }

        public string Title
        {
            set
            {
                Text = value;
                TitleLabel.Text = value;
            }
        }
        public AddCompanyForm(CompanyDetailDto company)
        {
            InitializeComponent();
            Company = company;
            CName.Text = Company.CompanyName;
            CInn.Text = Company.CompanyInn;
            CKpp.Text = Company.CompanyKpp;
            CNumberAccount.Text = Company.CompanyAccountNumber;

            using (BookkeepingContext context = new BookkeepingContext())
            {
                BankList.DataSource = context.Banks.ToList();
                var b = context.Banks.FirstOrDefault(bank => bank.Id == Company.BankId);
                if (b != null)
                    BankList.SelectedItem = b;
            }

            
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            Company.CompanyName = CName.Text;
            Company.CompanyInn = CInn.Text;
            Company.CompanyKpp = CKpp.Text;
            Company.CompanyAccountNumber = CNumberAccount.Text;
            Company.BankId = ((Bank) BankList.SelectedItem).Id;

            DialogResult = DialogResult.OK;
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
