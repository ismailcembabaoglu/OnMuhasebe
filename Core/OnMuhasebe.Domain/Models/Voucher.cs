using OnMuhasebe.Domain.Enums;
using OnMuhasebe.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Domain.Models
{
    public class Voucher:BaseModel
    {
        public string VoucherCode { get; set; }
        public VoucherType VoucherType { get; set;}
        public Guid CustomerId  { get; set; }
        public Customer? Customer { get; set; }
        public string DocumentNo { get; set; }
        public decimal DiscountRate { get; set; }
        public decimal DiscountPrice { get; set; }
        public decimal Owed { get; set;}
        public decimal Debt { get; set;}
        public decimal TotalPrice { get; set;}
        public Guid BankId { get; set;}
        public Bank Bank { get; set;}

    }
}
