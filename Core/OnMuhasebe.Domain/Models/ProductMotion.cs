using OnMuhasebe.Domain.Enums;
using OnMuhasebe.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Domain.Models
{
    public class ProductMotion:BaseModel
    {
        public string VoucherCode { get; set; }
        public string MotionType { get; set; }
        public Guid ProductId { get; set; }
        public Product? Product { get; set; }
        public decimal Quantity { get; set; }

        public Guid KdvId { get; set; }
        public Kdv? Kdv { get; set; }
        public decimal Price { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DiscountRate { get; set; }
        public DateTime Date { get; set; }
        public Guid WarehouseId { get; set; }
        public Warehouse? Warehouse { get; set; }
    }
}
