using OnMuhasebe.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Domain.Models
{
    public class Employee:BaseModel
    {
        public bool IsWork { get; set; }
        public string EmployeeTitle { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public string IdentityNo { get; set; }
        public DateTime WorkStartDate { get; set; }
        public DateTime WorkOutDate { get; set; }
        public string TaskOffice { get; set;}
        public string TaskNo { get; set; }
        public string MobilePhone { get; set;}
        public string Phone { get; set;}
        public string Fax { get; set;}
        public string Email { get; set;}
        public string Website { get; set;}
        public string Country { get; set;}
        public string City { get; set;}
        public string District { get; set;}
        public string Address { get; set;}
        public decimal PrimRatio { get; set;}
        public decimal MonthlySalary { get; set;}
        public ICollection<Voucher>? Vouchers { get; set;}
        public ICollection<EmployeeMotion>? EmployeeMotions { get; set;}
    }
}
