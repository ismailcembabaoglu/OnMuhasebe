using OnMuhasebe.Application.DTOs.BaseModelDTOs;
using OnMuhasebe.Domain.Models;
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
        public MotionTypeDTO MotionType { get; set; }
        public Guid ProductId { get; set; }
        public decimal Quantity { get; set; }

        public Guid KdvId { get; set; }
        public decimal Price { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DiscountRate { get; set; }
        public DateTime Date { get; set; }
        public Guid WarehouseId { get; set; }

    }
    public enum MotionTypeDTO
    {
        InStock,
        OutStock
    }
}
