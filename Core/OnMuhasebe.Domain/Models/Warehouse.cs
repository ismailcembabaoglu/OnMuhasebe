using OnMuhasebe.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Domain.Models
{
    public class Warehouse:BaseModel
    {
        public string WarehouseName { get; set; } 
        public string WarehouseCode{ get; set; }
        public string AuthCode { get; set; }
        public string AuthName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public ICollection<ProductMotion>? ProductMotions { get; set; }
        public ICollection<Voucher>? Vouchers { get; set; }

    }
}
