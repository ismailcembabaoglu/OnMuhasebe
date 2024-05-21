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
    public class DiscountDTO : BaseModelDTO
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductNumber { get; set; }
        public string DiscountType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal DiscountRatio { get; set; }
    }

}
