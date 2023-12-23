using OnMuhasebe.Application.DTOs.BaseModelDTOs;
using OnMuhasebe.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Application.DTOs
{
    public class CustomerDTO : BaseModelDTO
    {
        public bool IsActive { get; set; }
        public string CustomerType { get; set; }
        public string CustomerName { get; set; }
        public string CustomerCode { get; set; }

        public string AuthName { get; set; }
        public string InvoiceTitle { get; set; }
        public string PersonPhoneNumber { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }

        //public Guid CustomerGroupId { get; set;}
        public Guid SpecialCodeId { get; set; }
        public string SpecialName { get; set; }
        public string TaxOffice { get; set; }
        public string TaxNumber { get; set; }
        public decimal DiscountRatio { get; set; }
        public string RiskLimit { get; set; }
    }
}
