using System;
using System.Linq;
using System.Windows.Forms;
using DataAccessLayer;
using DataAccessLayer.Entity;

namespace WFApp
{
    public partial class AddCompanyForm : Form
    {
        public Company Company { get; set; }

        public string Title
        {
            set
            {
                Text = value;
                TitleLabel.Text = value;
            }
        }
        public AddCompanyForm(Company company)
        {
            InitializeComponent();
            Company = company;
            CName.Text = Company.Name;
            CInn.Text = Company.Inn;
            CKpp.Text = Company.Kpp;
            CNumberAccount.Text = Company.AccountNumber;

            using (BookkeepingContext context = new BookkeepingContext())
            {
                BankList.DataSource = context.Banks.ToList();
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            Company.Name = CName.Text;
            Company.Inn = CInn.Text;
            Company.Kpp = CKpp.Text;
            Company.AccountNumber = CNumberAccount.Text;
            using (BookkeepingContext context = new BookkeepingContext())
            {
                Company.BankId = context.Banks.Find(((Bank) BankList.SelectedItem).Id);
            }
            

            DialogResult = DialogResult.OK;
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
