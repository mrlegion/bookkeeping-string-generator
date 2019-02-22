using System;
using System.Windows.Forms;

namespace WFApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var af = new AddBankForm {Title = "Add new Bank", Owner = this};
            if (af.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void AddCompanyBtn_Click(object sender, EventArgs e)
        {
            var ac = new AddCompanyForm() {Title = "Add new Company", Owner = this};
            if (ac.ShowDialog() == DialogResult.OK)
            {

            }
        }
    }
}
