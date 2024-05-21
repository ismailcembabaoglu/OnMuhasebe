using OnMuhasebe.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Domain.Models
{
    public class Customer:BaseModel
    {
        public bool IsActive { get; set; }
        public string CustomerType { get; set; }
        public string CustomerName { get; set; }
        public string CustomerCode { get; set; }

        public string AuthName { get; set; }
        public string InvoiceTitle { get; set; }
        public string PersonPhoneNumber { get; set;}
        public string Phone { get; set;}
        public string Fax { get; set;}
        public string Email { get; set;}
        public string Website { get; set;}
        public string Country { get; set;}
        public string City { get; set;}
        public string District { get; set;}

        public Guid CustomerGroupId { get; set;}
        public CustomerGroup? CustomerGroup { get; set;}
        public Guid SpecialCodeId { get; set;}
        public SpecialCode? SpecialCode { get; set;}
        public string TaxOffice { get; set;}
        public string TaxNumber { get; set;}
        public decimal DiscountRatio { get; set;}
        public string RiskLimit { get; set;}
        public ICollection<BankMotion>? BankMotions { get; set;}
        public ICollection<SafeBox>? SafeBoxes { get; set;}
        public ICollection<Voucher>? Vouchers { get; set;}

    }
}
