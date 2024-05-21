using OnMuhasebe.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Domain.Models
{
    public class CustomerUnderGroup:BaseModel
    {
        public string CustomerUnderGroupName { get; set; }

        public Guid CustomerGroupID { get; set; }
        public CustomerGroup? CustomerGroup { get; set; }
    }
}
