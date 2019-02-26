using DataAccessLayer;
using DataAccessLayer.DTO;
using DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WFApp
{
    public partial class MainForm : Form
    {
        private static Random _random = new Random();
        private bool init = true;
        public MainForm()
        {
            InitializeComponent();
            UpdateData();
        }

        private List<Account> InitData(int banks, int companies, int accounts)
        {
            Bank[] banksArray = new Bank[banks];
            Company[] companiesArray = new Company[companies];
            var accountsList = new List<Account>();

            for (int i = 0; i < banks; i++)
                banksArray[i] = new Bank()
                {
                    Name = $"Банк {i + 1}",
                    City = $"Город {i + 1}",
                    AccountNumber = GetRandomNumber(20),
                    Bik = GetRandomNumber(9)
                };

            for (int i = 0; i < companies; i++)
                companiesArray[i] = new Company()
                {
                    Name = $"Компания {i + 1}",
                    Inn = GetRandomNumber(11),
                    Kpp = GetRandomNumber(9)
                };

            for (int i = 0; i < accounts; i++)
                accountsList.Add(new Account()
                {
                    AccountNumber = GetRandomNumber(20),
                    Bank = banksArray[_random.Next(0, banksArray.Length - 1)],
                    Company = companiesArray[_random.Next(0, companiesArray.Length - 1)]
                });

            return accountsList;
        }

        private async void UpdateData()
        {
            using (var context = new BookkeepingContext())
            {
                if (!context.Database.Exists() && init)
                {
                    List<Account> accounts = InitData(6, 10, 20);

                    context.Accounts.AddRange(accounts);
                    context.SaveChanges();

                    context.Accounts.Add(new Account()
                    {
                        AccountNumber = GetRandomNumber(20),
                        Bank = context.Banks.First(bank => bank.Id == 2),
                        Company = context.Companies.First(company => company.Id == 3)
                    });
                    context.SaveChanges();
                    init = false;
                }

                var query = await (from account in context.Accounts
                                   join company in context.Companies on account.CompanyId equals company.Id
                                   join bank in context.Banks on account.BankId equals bank.Id
                                   select new CompanyDetailDto()
                                   {
                                       CompanyId = company.Id,
                                       CompanyName = company.Name,
                                       CompanyInn = company.Inn,
                                       CompanyKpp = company.Kpp,
                                       CompanyAccountNumber = account.AccountNumber,
                                       BankId = bank.Id,
                                       BankName = bank.Name,
                                       BankCity = bank.City,
                                       BankBik = bank.Bik,
                                       BankAccountNumber = bank.AccountNumber
                                   }).ToListAsync();
                CompanyInfo.DataSource = query;
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
            var ac = new AddCompanyForm(new CompanyDetailDto()
            {
                CompanyInn = GetRandomNumber(12),
                CompanyKpp = GetRandomNumber(9),
                CompanyAccountNumber = GetRandomNumber(20)
            })
            {
                Title = "Add new Company",
                Owner = this
            };

            if (ac.ShowDialog() == DialogResult.OK)
            {
                using (BookkeepingContext context = new BookkeepingContext())
                {
                    var company = new Company()
                    {
                        Name = ac.Company.CompanyName,
                        Inn = ac.Company.CompanyInn,
                        Kpp = ac.Company.CompanyKpp,
                    };

                    var account = new Account()
                    {
                        Company = company,
                        Bank = context.Banks.First(bank => bank.Id == ac.Company.BankId),
                        AccountNumber = ac.Company.CompanyAccountNumber
                    };
                    context.Accounts.Add(account);
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
