using OnMuhasebe.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Domain.Models
{
    public class ProductGroup:BaseModel
    {
        public string ProductGroupName { get; set; }
        public ICollection<Product>? Products { get; set; }
        public ICollection<ProductUnderGroup>? ProductUnderGroups { get; set; }
    }
}
