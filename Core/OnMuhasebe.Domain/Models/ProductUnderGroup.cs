using OnMuhasebe.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Domain.Models
{
    public class ProductUnderGroup:BaseModel
    {
        public string ProductUnderGroupName { get; set; }
        public Guid ProductGroupId { get; set; }
        public ProductGroup? ProductGroup { get; set; }
    }
}
