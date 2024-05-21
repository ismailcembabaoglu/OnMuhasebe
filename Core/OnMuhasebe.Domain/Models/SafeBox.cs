using OnMuhasebe.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Domain.Models
{
    public class SafeBox:BaseModel
    {
        public string SafeBoxCode { get; set; }
        public string SafeBoxName { get; set;}

        public string AuthCode { get; set; }
        public string AuthName { get; set; }
        public ICollection<SafeBoxMotion>? SafeBoxMotions { get; set; }


    }
}
