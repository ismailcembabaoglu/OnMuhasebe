using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnMuhasebe.Application.DTOs;
using OnMuhasebe.Application.IServices;
using OnMuhasebe.Application.ResponseModels;
using OnMuhasebe.Persistence.Services;

namespace OnMuhasebe.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeMotionController : ControllerBase
    {
        private readonly IEmployeeMotionService employeeMotionService;
        public EmployeeMotionController(IEmployeeMotionService _employeeMotionService)
        {
            employeeMotionService = _employeeMotionService;
        }
        [HttpGet("EmployeeMotions")]
        public async Task<ServiceResponse<List<EmployeeMotionDTO>>> GetEmployeeMotions()
        {
            return new ServiceResponse<List<EmployeeMotionDTO>>()
            {

                Value = await employeeMotionService.GetEmployeeMotions()
            };
        }
        [HttpPost("Create")]
        public async Task<ServiceResponse<EmployeeMotionDTO>> CreateEmployeeMotion([FromBody] EmployeeMotionDTO EmployeeMotion)
        {
            return new ServiceResponse<EmployeeMotionDTO>()
            {
                Value = await employeeMotionService.CreateEmployeeMotion(EmployeeMotion)
            };
        }
        [HttpPost("Update")]
        public async Task<ServiceResponse<EmployeeMotionDTO>> UpdateEmployeeMotion([FromBody] EmployeeMotionDTO EmployeeMotion)
        {
            return new ServiceResponse<EmployeeMotionDTO>()
            {
                Value = await employeeMotionService.UpdateEmployeeMotion(EmployeeMotion)
            };
        }
        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> DeleteEmployeeMotionId([FromBody] Guid Id)
        {
            return new ServiceResponse<bool>()
            {
                Value = await employeeMotionService.DeleteEmployeeMotionId(Id)
            };
        }
        [HttpGet("EmployeeMotionById/{Id}")]
        public async Task<ServiceResponse<EmployeeMotionDTO>> GetEmployeeMotionById(Guid Id)
        {
            return new ServiceResponse<EmployeeMotionDTO>()
            {
                Value = await employeeMotionService.GetEmployeeMotionById(Id)
            };
        }
    }
}
