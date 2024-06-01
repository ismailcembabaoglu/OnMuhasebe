using OnMuhasebe.Domain.Models;
using OnMuhasebe.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Domain.Models
{
    public class SpecialCode : BaseModel
    {
        public string SpecialName { get; set; }

        public Guid ProductId { get; set; }
        public Product? Product { get; set; }
    }
}






