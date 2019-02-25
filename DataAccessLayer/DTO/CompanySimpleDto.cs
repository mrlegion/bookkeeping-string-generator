using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTO
{
    public class CompanySimpleDto
    {
        public int CompanyId { get; set; }
        public int BankId { get; set; }

        public string CompanyName { get; set; }
        public string CompanyInn { get; set; }
        public string CompanyKpp { get; set; }
        public string BankName { get; set; }
    }
}
