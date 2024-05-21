using OnMuhasebe.Domain.Enums;
using OnMuhasebe.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Domain.Models
{
    public class Discount:BaseModel
    {
        public Guid ProductId { get; set; }
        public Product? Product { get; set; }
        public string DiscountType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Decimal DiscountRatio { get; set; }
    }


}
