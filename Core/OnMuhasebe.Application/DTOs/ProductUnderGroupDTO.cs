using OnMuhasebe.Application.DTOs.BaseModelDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Application.DTOs
{
    public class ProductUnderGroupDTO: BaseModelDTO
    {
        public string ProductUnderGroupName { get; set; }
        public Guid ProductGroupId { get; set; }
        public string? ProductGroupName { get; set; }
    }
}
