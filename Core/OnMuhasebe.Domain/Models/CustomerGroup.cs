﻿using OnMuhasebe.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Domain.Models
{
    public class CustomerGroup:BaseModel
    {
        public string CustomerGroupName { get; set; }
       public ICollection<Customer>? Customers { get; set; }
       public ICollection<CustomerUnderGroup>? CustomerUnderGroups { get; set; }
    }
}
