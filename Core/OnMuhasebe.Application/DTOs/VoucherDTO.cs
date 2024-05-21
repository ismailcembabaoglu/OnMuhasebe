using OnMuhasebe.Application.DTOs.BaseModelDTOs;
using OnMuhasebe.Domain.Models;
using OnMuhasebe.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Application.DTOs
{
    public class VoucherDTO : BaseModelDTO
    {
        public string VoucherCode { get; set; }
        public string VoucherType { get; set; }
        public Guid CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerCode { get; set; }
        public string DocumentNo { get; set; }
        public decimal DiscountRate { get; set; }
        public decimal DiscountPrice { get; set; }
        public decimal Owed { get; set; }
        public decimal Debt { get; set; }
        public decimal TotalPrice { get; set; }
        public Guid BankId { get; set; }
        public string? AccountCode { get; set; }
        public string? AccountName { get; set; }
        public string? IbanNo { get; set; }
    }

}
