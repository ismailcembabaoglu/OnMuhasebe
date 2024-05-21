using OnMuhasebe.Domain.Enums;
using OnMuhasebe.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Domain.Models
{
    public class BankMotion:BaseModel
    {
        public string VoucherCode { get; set; }
        public string BankMotionType { get; set; }
        public Guid BankId { get; set; }
        public Bank? Bank { get; set;}
        public Guid CustomerId { get; set;}
        public Customer? Customer { get; set;}
        public decimal Price { get; set;}
    }
}
