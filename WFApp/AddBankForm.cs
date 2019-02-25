using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLayer.Entity;

namespace WFApp
{
    public partial class AddBankForm : Form
    {
        public Bank Bank { get; set; }

        public string Title
        {
            set
            {
                Text = value;
                TitleLabel.Text = value;
            }
        }
        public AddBankForm(Bank bank)
        {
            InitializeComponent();
            Bank = bank;
            BName.Text = Bank.Name;
            BCity.Text = Bank.City;
            BBik.Text = Bank.Bik;
            BNumberAccount.Text = Bank.AccountNumber;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            Bank.Name = BName.Text;
            Bank.City = BCity.Text;
            Bank.Bik = BBik.Text;
            Bank.AccountNumber = BNumberAccount.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}