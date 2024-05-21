
using OnMuhasebe.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Domain.Models
{
    public class Product : BaseModel
    {
        public bool IsActive { get; set; }
        public string ProductName { get; set; }
        public string ProductNumber { get; set; }
        public string Barcode { get; set; }
        public Guid UnitId { get; set; }
        public Unit? Unit { get; set; }

        public Guid ProductGroupId { get; set; }
        public ProductGroup? ProductGroup { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public ICollection<SpecialCode>? SpecialCodes { get; set; }
        public string GuaranteePeriod { get; set; }
        public string Producer { get; set; }

        public ICollection<Price>? Prices { get; set; }
        public ICollection<ProductMotion>? ProductMotions { get; set; }
        public string Photo { get; set; }
    }
}
