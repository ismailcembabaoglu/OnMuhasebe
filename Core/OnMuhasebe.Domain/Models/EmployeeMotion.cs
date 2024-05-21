using OnMuhasebe.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Domain.Models
{
    public class EmployeeMotion:BaseModel
    {
        public Guid EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        public DateTime Period { get; set; }
        public decimal PrimRatio { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal MonthlySalary { get; set; }
    }
}
