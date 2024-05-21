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
    public class BankMotionDTO : BaseModelDTO
    {
        public string VoucherCode { get; set; }
        public string BankMotionType { get; set; }
        public Guid BankId { get; set; }
        public string? AccountName { get; set; }
        public string? BankName { get; set; }
        public string? IbanNo { get; set; }
        public Guid CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerCode { get; set; }
        public string? AuthName { get; set; }
        public decimal Price { get; set; }
    }

}
