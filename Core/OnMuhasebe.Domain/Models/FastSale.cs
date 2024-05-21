using OnMuhasebe.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Domain.Models
{
    public class FastSale:BaseModel
    {
        public Guid FastSaleGroupId { get; set; }
        public FastSaleGroup? FastSaleGroup { get; set;}
        public Guid ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
