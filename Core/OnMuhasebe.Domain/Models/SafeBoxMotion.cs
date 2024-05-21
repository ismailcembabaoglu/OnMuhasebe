using OnMuhasebe.Domain.Enums;
using OnMuhasebe.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Domain.Models
{
    public class SafeBoxMotion:BaseModel
    {
        public string VoucherCode { get; set; }
        public string SafeBoxMotionType { get; set;}
        public Guid SafeBoxId { get; set; }
        public SafeBox? SafeBox { get; set;}
        public Guid PaymentTypeId { get; set; }
        public PaymentType? PaymentType { get; set;}
        public Guid CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public decimal Price { get; set; }
    }
}
