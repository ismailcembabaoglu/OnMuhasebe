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
    public class CustomerUnderGroupController : ControllerBase
    {
        private readonly ICustomerUnderGroupService customerUnderGroupService;
        public CustomerUnderGroupController(ICustomerUnderGroupService _customerUnderGroupService)
        {
            customerUnderGroupService = _customerUnderGroupService;
        }
        [HttpGet("CustomerUnderGroups")]
        public async Task<ServiceResponse<List<CustomerUnderGroupDTO>>> GetCustomerUnderGroups()
        {
            return new ServiceResponse<List<CustomerUnderGroupDTO>>()
            {

                Value = await customerUnderGroupService.GetCustomerUnderGroups()
            };
        }
        [HttpPost("Create")]
        public async Task<ServiceResponse<CustomerUnderGroupDTO>> CreateCustomerUnderGroup([FromBody] CustomerUnderGroupDTO CustomerUnderGroup)
        {
            return new ServiceResponse<CustomerUnderGroupDTO>()
            {
                Value = await customerUnderGroupService.CreateCustomerUnderGroup(CustomerUnderGroup)
            };
        }
        [HttpPost("Update")]
        public async Task<ServiceResponse<CustomerUnderGroupDTO>> UpdateCustomerUnderGroup([FromBody] CustomerUnderGroupDTO CustomerUnderGroup)
        {
            return new ServiceResponse<CustomerUnderGroupDTO>()
            {
                Value = await customerUnderGroupService.UpdateCustomerUnderGroup(CustomerUnderGroup)
            };
        }
        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> DeleteCustomerUnderGroupId([FromBody] Guid Id)
        {
            return new ServiceResponse<bool>()
            {
                Value = await customerUnderGroupService.DeleteCustomerUnderGroupId(Id)
            };
        }
        [HttpGet("CustomerUnderGroupById/{Id}")]
        public async Task<ServiceResponse<CustomerUnderGroupDTO>> GetCustomerUnderGroupById(Guid Id)
        {
            return new ServiceResponse<CustomerUnderGroupDTO>()
            {
                Value = await customerUnderGroupService.GetCustomerUnderGroupById(Id)
            };
        }
    }
}
