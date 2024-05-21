using OnMuhasebe.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Domain.Models
{
    public class Bank:BaseModel
    {
        public string AccountCode { get; set; }
        public string AccountName { get; set;}
        public string BankName { get; set;}
        public string Branch { get; set;}
        public string IbanNo { get; set; }
        public string AccountNo { get; set; }
        public string AuthName { get; set; }
        public string AuthPhone { get; set;}
        public ICollection<BankMotion>? BankMotions { get; set; }
        public ICollection<Voucher>? Vouchers { get; set; }


    }
}
