﻿using OnMuhasebe.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Domain.Models
{
    public class Unit:BaseModel
    {
        public string UnitName { get; set; }

        public ICollection<Product> Products { get; set; }

    }
}
