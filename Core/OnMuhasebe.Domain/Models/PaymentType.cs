using OnMuhasebe.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Domain.Models
{
    public class PaymentType:BaseModel
    {
        public string PaymentTypeCode { get; set; }
        public string PaymentTypeName { get; set; }
        public ICollection<SafeBoxMotion>? SafeBoxMotions { get; set; }
    }
}
