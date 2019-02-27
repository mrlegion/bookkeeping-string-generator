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
        //private bool init = true;
        public MainForm()
        {
            InitializeComponent();
            UpdateData();
        }

        // Генерация случайных 
        //private List<Account> InitData(int banks, int companies, int accounts)
        //{
        //    Bank[] banksArray = new Bank[banks];
        //    Company[] companiesArray = new Company[companies];
        //    var accountsList = new List<Account>();

        //    for (int i = 0; i < banks; i++)
        //        banksArray[i] = new Bank()
        //        {
        //            Name = $"Банк {i + 1}",
        //            City = $"Город {i + 1}",
        //            AccountNumber = GetRandomNumber(20),
        //            Bik = GetRandomNumber(9)
        //        };

        //    for (int i = 0; i < companies; i++)
        //        companiesArray[i] = new Company()
        //        {
        //            Name = $"Компания {i + 1}",
        //            Inn = GetRandomNumber(11),
        //            Kpp = GetRandomNumber(9)
        //        };

        //    for (int i = 0; i < accounts; i++)
        //        accountsList.Add(new Account()
        //        {
        //            AccountNumber = GetRandomNumber(20),
        //            Bank = banksArray[_random.Next(0, banksArray.Length - 1)],
        //            Company = companiesArray[_random.Next(0, companiesArray.Length - 1)]
        //        });

        //    return accountsList;
        //}

        // Обновление основной таблицы с данными
        private void UpdateData()
        {
            //using (var context = new BookkeepingContext())
            //{
            //    if (!context.Database.Exists() && init)
            //    {
            //        List<Account> accounts = InitData(6, 10, 20);

            //        context.Accounts.AddRange(accounts);
            //        context.SaveChanges();

            //        context.Accounts.Add(new Account()
            //        {
            //            AccountNumber = GetRandomNumber(20),
            //            Bank = context.Banks.First(bank => bank.Id == 2),
            //            Company = context.Companies.First(company => company.Id == 3)
            //        });
            //        context.SaveChanges();
            //        init = false;
            //    }

            //    var query = await (from account in context.Accounts
            //                       join company in context.Companies on account.CompanyId equals company.Id
            //                       join bank in context.Banks on account.BankId equals bank.Id
            //                       select new CompanyDetailDto()
            //                       {
            //                           CompanyId = company.Id,
            //                           CompanyName = company.Name,
            //                           CompanyInn = company.Inn,
            //                           CompanyKpp = company.Kpp,
            //                           CompanyAccountNumber = account.AccountNumber,
            //                           BankId = bank.Id,
            //                           BankName = bank.Name,
            //                           BankCity = bank.City,
            //                           BankBik = bank.Bik,
            //                           BankAccountNumber = bank.AccountNumber
            //                       }).ToListAsync();
            //    CompanyInfo.DataSource = query;
            //}
        }

        /// <summary>
        /// Генерация случайного чиста задданой длины
        /// </summary>
        /// <param name="lenght">Длина генерируемого числа</param>
        /// <returns></returns>
        private string GetRandomNumber(int lenght)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < lenght; i++) sb.Append(_random.Next(0, 9));

            return sb.ToString();
        }

        // Закрытие приложения
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Добавление нового банка
        private void Button1_Click(object sender, EventArgs e)
        {

        }

        // Добавление новой компании
        private void AddCompanyBtn_Click(object sender, EventArgs e)
        {

        }

        private void EditCompanyClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
