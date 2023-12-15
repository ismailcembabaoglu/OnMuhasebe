using OnMuhasebe.Application.DTOs.BaseModelDTOs;
using OnMuhasebe.Domain.Models;
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
        public VoucherTypeDTO VoucherType { get; set; }
        public Guid CustomerId { get; set; }
        public string DocumentNo { get; set; }
        public decimal DiscountRate { get; set; }
        public decimal DiscountPrice { get; set; }
        public decimal Owed { get; set; }
        public decimal Debt { get; set; }
        public decimal TotalPrice { get; set; }
        public Guid BankId { get; set; }
    }
    public enum VoucherTypeDTO
    {
        Sales,
        Purchase
    }
}
