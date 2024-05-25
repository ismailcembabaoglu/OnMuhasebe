using OnMuhasebe.Application.DTOs.BaseModelDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Application.DTOs
{
    public class CustomerUnderGroupDTO : BaseModelDTO
    {
        public string CustomerUnderGroupName { get; set; }

        public Guid CustomerGroupID { get; set; }
        public string? CustomerGroupName { get; set; }
    }
}
