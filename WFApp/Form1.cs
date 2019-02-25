using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccessLayer;
using DataAccessLayer.DTO;
using DataAccessLayer.Entity;

namespace WFApp
{
    public partial class MainForm : Form
    {
        private static Random _random = new Random();
        public MainForm()
        {
            InitializeComponent();
            UpdateData();
        }

        private void UpdateData()
        {
            //using (BookkeepingContext context = new BookkeepingContext())
            //{
            //    var query = await (from company in context.Companies
            //        join bank in context.Banks
            //            on company.BankId equals bank.Id
            //        select new CompanySimpleDto()
            //        {
            //            CompanyId = company.Id,
            //            BankId = bank.Id,
            //            CompanyName = company.Name,
            //            CompanyInn = company.Inn,
            //            CompanyKpp = company.Kpp,
            //            BankName = bank.Name
            //        }).ToListAsync();
            //    CompanyInfo.DataSource = query;
            //}


            using (var context = new BookkeepingContext())
            {
                var bank1 = new Bank() { Name = "Банк 1", City = "Город 1", AccountNumber = GetRandomNumber(20), Bik = GetRandomNumber(9) };
                var bank2 = new Bank() { Name = "Банк 2", City = "Город 2", AccountNumber = GetRandomNumber(20), Bik = GetRandomNumber(9) };
                var bank3 = new Bank() { Name = "Банк 3", City = "Город 3", AccountNumber = GetRandomNumber(20), Bik = GetRandomNumber(9) };
                var company1 = new Company() { Name = "Компания 1", Inn = GetRandomNumber(11), Kpp = "0" };
                var company2 = new Company() { Name = "Компания 2", Inn = GetRandomNumber(11), Kpp = GetRandomNumber(9) };
                var company3 = new Company() { Name = "Компания 3", Inn = GetRandomNumber(11), Kpp = "0" };
                var company4 = new Company() { Name = "Компания 4", Inn = GetRandomNumber(11), Kpp = GetRandomNumber(9) };
                var company5 = new Company() { Name = "Компания 5", Inn = GetRandomNumber(11), Kpp = "0" };
                List<Account> accounts = new List<Account>()
                {
                    new Account() {AccountNumber = GetRandomNumber(20), Bank = bank1, Company = company1},
                    new Account() {AccountNumber = GetRandomNumber(20), Bank = bank1, Company = company2},
                    new Account() {AccountNumber = GetRandomNumber(20), Bank = bank2, Company = company1},
                    new Account() {AccountNumber = GetRandomNumber(20), Bank = bank1, Company = company3},
                    new Account() {AccountNumber = GetRandomNumber(20), Bank = bank3, Company = company3},
                    new Account() {AccountNumber = GetRandomNumber(20), Bank = bank1, Company = company5},
                    new Account() {AccountNumber = GetRandomNumber(20), Bank = bank1, Company = company4},
                    new Account() {AccountNumber = GetRandomNumber(20), Bank = bank2, Company = company5},
                    new Account() {AccountNumber = GetRandomNumber(20), Bank = bank2, Company = company2},
                };

                context.Accounts.AddRange(accounts);
                context.SaveChanges();

                context.Accounts.Add(new Account()
                {
                    AccountNumber = GetRandomNumber(20),
                    Bank = context.Banks.First(bank => bank.Id == 2),
                    Company = context.Companies.First(company => company.Id == 3)
                });
                context.SaveChanges();
            }
        }

        private string GetRandomNumber(int lenght)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < lenght; i++) sb.Append(_random.Next(0, 9));

            return sb.ToString();
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
