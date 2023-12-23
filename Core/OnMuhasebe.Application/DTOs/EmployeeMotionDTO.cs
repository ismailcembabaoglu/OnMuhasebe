using OnMuhasebe.Application.DTOs.BaseModelDTOs;
using OnMuhasebe.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Application.DTOs
{
    public class EmployeeMotionDTO : BaseModelDTO
    {
        public Guid EmployeeId { get; set; }
        public string? EmployeeTitle { get; set; }
        public string? EmployeeCode { get; set; }
        public string? EmployeeName { get; set; }
        public DateTime Period { get; set; }
        public decimal PrimRatio { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal MonthlySalary { get; set; }
    }
}
