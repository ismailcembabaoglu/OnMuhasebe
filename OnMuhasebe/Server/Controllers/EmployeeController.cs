using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnMuhasebe.Application.DTOs;
using OnMuhasebe.Application.IServices;
using OnMuhasebe.Application.ResponseModels;

namespace OnMuhasebe.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;
        public EmployeeController(IEmployeeService _employeeService)
        {
            employeeService = _employeeService;
        }
        [HttpGet("Employees")]
        public async Task<ServiceResponse<List<EmployeeDTO>>> GetEmployees()
        {
            return new ServiceResponse<List<EmployeeDTO>>()
            {

                Value = await employeeService.GetEmployees()
            };
        }
        [HttpPost("Create")]
        public async Task<ServiceResponse<EmployeeDTO>> CreateEmployee([FromBody] EmployeeDTO Employee)
        {
            return new ServiceResponse<EmployeeDTO>()
            {
                Value = await employeeService.CreateEmployee(Employee)
            };
        }
        [HttpPost("Update")]
        public async Task<ServiceResponse<EmployeeDTO>> UpdateEmployee([FromBody] EmployeeDTO Employee)
        {
            return new ServiceResponse<EmployeeDTO>()
            {
                Value = await employeeService.UpdateEmployee(Employee)
            };
        }
        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> DeleteEmployeeId([FromBody] Guid Id)
        {
            return new ServiceResponse<bool>()
            {
                Value = await employeeService.DeleteEmployeeId(Id)
            };
        }
        [HttpGet("EmployeeById/{Id}")]
        public async Task<ServiceResponse<EmployeeDTO>> GetEmployeeById(Guid Id)
        {
            return new ServiceResponse<EmployeeDTO>()
            {
                Value = await employeeService.GetEmployeeById(Id)
            };
        }
    }
}
