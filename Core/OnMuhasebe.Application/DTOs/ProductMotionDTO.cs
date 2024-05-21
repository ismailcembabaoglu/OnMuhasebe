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
    public class ProductMotionDTO : BaseModelDTO
    {
        public string VoucherCode { get; set; }
        public string MotionType { get; set; }
        public Guid ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductNumber { get; set; }
        public decimal Quantity { get; set; }

        public Guid KdvId { get; set; }
        public string? KdvName { get; set; }
        public decimal? KdvRatio { get; set; }
        public decimal Price { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DiscountRate { get; set; }
        public DateTime Date { get; set; }
        public Guid WarehouseId { get; set; }
        public string? WarehouseName { get; set; }
        public string? WarehouseCode { get; set; }

    }
}
