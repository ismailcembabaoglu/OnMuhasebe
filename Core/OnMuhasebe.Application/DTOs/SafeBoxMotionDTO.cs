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
        public SafeBoxMotionType SafeBoxMotionType { get; set; }
        public Guid SafeBoxId { get; set; }
        public Guid PaymentTypeId { get; set; }
        public Guid CustomerId { get; set; }
        public decimal Price { get; set; }
    }

}
