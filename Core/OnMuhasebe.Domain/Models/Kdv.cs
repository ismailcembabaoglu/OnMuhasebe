using OnMuhasebe.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Domain.Models
{
    public class Kdv:BaseModel
    {
        public string KdvName { get; set; }

        public decimal KdvRatio { get; set; }
        public ICollection<Price>? Prices { get; set; }
    }
}
