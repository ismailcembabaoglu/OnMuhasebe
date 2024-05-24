using OnMuhasebe.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Application.IServices
{
    public interface IEmployeeService
    {
        public Task<List<EmployeeDTO>> GetEmployees();
        public Task<EmployeeDTO> CreateEmployee(EmployeeDTO Employee);
        public Task<EmployeeDTO> UpdateEmployee(EmployeeDTO Employee);
        public Task<bool> DeleteEmployeeId(Guid id);
        public Task<EmployeeDTO> GetEmployeeById(Guid Id);
    }
}
