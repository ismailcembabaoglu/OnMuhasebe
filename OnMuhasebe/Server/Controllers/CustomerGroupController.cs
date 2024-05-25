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
    public class CustomerGroupController : ControllerBase
    {
        private readonly ICustomerGroupService customerGroupService;
        public CustomerGroupController(ICustomerGroupService _customerGroupService)
        {
            customerGroupService = _customerGroupService;
        }
        [HttpGet("CustomerGroups")]
        public async Task<ServiceResponse<List<CustomerGroupDTO>>> GetCustomerGroups()
        {
            return new ServiceResponse<List<CustomerGroupDTO>>()
            {

                Value = await customerGroupService.GetCustomerGroups()
            };
        }
        [HttpPost("Create")]
        public async Task<ServiceResponse<CustomerGroupDTO>> CreateCustomerGroup([FromBody] CustomerGroupDTO CustomerGroup)
        {
            return new ServiceResponse<CustomerGroupDTO>()
            {
                Value = await customerGroupService.CreateCustomerGroup(CustomerGroup)
            };
        }
        [HttpPost("Update")]
        public async Task<ServiceResponse<CustomerGroupDTO>> UpdateCustomerGroup([FromBody] CustomerGroupDTO CustomerGroup)
        {
            return new ServiceResponse<CustomerGroupDTO>()
            {
                Value = await customerGroupService.UpdateCustomerGroup(CustomerGroup)
            };
        }
        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> DeleteCustomerGroupId([FromBody] Guid Id)
        {
            return new ServiceResponse<bool>()
            {
                Value = await customerGroupService.DeleteCustomerGroupId(Id)
            };
        }
        [HttpGet("CustomerGroupById/{Id}")]
        public async Task<ServiceResponse<CustomerGroupDTO>> GetCustomerGroupById(Guid Id)
        {
            return new ServiceResponse<CustomerGroupDTO>()
            {
                Value = await customerGroupService.GetCustomerGroupById(Id)
            };
        }

    }
}
