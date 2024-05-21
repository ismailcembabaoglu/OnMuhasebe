using OnMuhasebe.Domain.Enums;
using OnMuhasebe.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Domain.Models
{
    public class Price : BaseModel
    {
        public Guid ProductId { get; set; }

        public Product? Product { get; set; }

        public PriceType PriceType { get; set; }

        public decimal PriceValue { get; set; }

        public Guid KdvId { get; set; }

        public Kdv? Kdv { get; set; }

        public bool IsDefault { get; set; }
    }
    
}
