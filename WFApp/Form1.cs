using System;
using System.Windows.Forms;
using Domain;
using Domain.DtoService;
using Domain.DTO;
using Domain.Entities;
using Domain.Repositories;

namespace WFApp
{
    public partial class MainForm : Form
    {

        private readonly IRepository<Bank> _bankRepository;
        private readonly IRepository<Company> _companyRepository;
        private readonly IDtoRepository<CompanyDetailsDto> _companyDtoRepository;

        public MainForm()
        {
            InitializeComponent();

            _bankRepository = new BankRepository();
            _companyRepository = new CompanyRepository();
            _companyDtoRepository = new CompanyDtoRepository();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var af = new AddBankForm(new Bank()) {Title = "Add new Bank", Owner = this};
            if (af.ShowDialog() == DialogResult.OK)
            {
                _bankRepository.Add(af.Bank);
                _bankRepository.Save();
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
