using OnMuhasebe.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Application.IServices
{
    public interface IEmployeeMotionService
    {
        public Task<List<EmployeeMotionDTO>> GetEmployeeMotions();
        public Task<EmployeeMotionDTO> CreateEmployeeMotion(EmployeeMotionDTO EmployeeMotion);
        public Task<EmployeeMotionDTO> UpdateEmployeeMotion(EmployeeMotionDTO EmployeeMotion);
        public Task<bool> DeleteEmployeeMotionId(Guid id);
        public Task<EmployeeMotionDTO> GetEmployeeMotionById(Guid Id);
    }
}
