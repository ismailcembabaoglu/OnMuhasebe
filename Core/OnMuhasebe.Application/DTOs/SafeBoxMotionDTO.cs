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
    public class SafeBoxMotionDTO : BaseModelDTO
    {
        public string VoucherCode { get; set; }
        public string SafeBoxMotionType { get; set; }
        public Guid SafeBoxId { get; set; }
        public string? SafeBoxCode { get; set; }
        public string? SafeBoxName { get; set; }
        public Guid PaymentTypeId { get; set; }
        public string? PaymentTypeCode { get; set; }
        public string? PaymentTypeName { get; set; }
        public Guid CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerCode { get; set; }
        public decimal Price { get; set; }
    }

}
