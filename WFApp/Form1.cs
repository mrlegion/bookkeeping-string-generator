using System;
using System.Linq;
using System.Windows.Forms;
using DataAccessLayer;
using DataAccessLayer.DTO;
using DataAccessLayer.Entity;

namespace WFApp
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
            UpdateData();
        }

        private void UpdateData()
        {
            using (BookkeepingContext context = new BookkeepingContext())
            {
                var query = from company in context.Companies
                    join bank in context.Banks
                        on company.BankId.Id equals bank.Id
                    select new CompanySimpleDto()
                    {
                        CompanyId = company.Id,
                        BankId = bank.Id,
                        CompanyName = company.Name,
                        CompanyInn = company.Inn,
                        CompanyKpp = company.Kpp,
                        BankName = bank.Name
                    };
                CompanyInfo.DataSource = query.ToList();
            }
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var af = new AddBankForm(new Bank()) { Title = "Add new Bank", Owner = this };
            if (af.ShowDialog() == DialogResult.OK)
            {
                using (BookkeepingContext context = new BookkeepingContext())
                {
                    context.Banks.Add(af.Bank);
                    context.SaveChanges();
                    UpdateData();
                }
            }

            
        }

        private void AddCompanyBtn_Click(object sender, EventArgs e)
        {
            var ac = new AddCompanyForm(new Company()) {Title = "Add new Company", Owner = this};
            if (ac.ShowDialog() == DialogResult.OK)
            {
                using (BookkeepingContext context = new BookkeepingContext())
                {
                    context.Companies.Add(ac.Company);
                    context.SaveChanges();
                    UpdateData();
                }
            }
        }

        private void EditCompanyClick(object sender, DataGridViewCellEventArgs e)
        {
            return;
        }
    }
}
