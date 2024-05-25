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
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;
        public CustomerController(ICustomerService _customerService)
        {
            customerService = _customerService;
        }
        [HttpGet("Customers")]
        public async Task<ServiceResponse<List<CustomerDTO>>> GetCustomers()
        {
            return new ServiceResponse<List<CustomerDTO>>()
            {

                Value = await customerService.GetCustomers()
            };
        }
        [HttpPost("Create")]
        public async Task<ServiceResponse<CustomerDTO>> CreateCustomer([FromBody] CustomerDTO Customer)
        {
            return new ServiceResponse<CustomerDTO>()
            {
                Value = await customerService.CreateCustomer(Customer)
            };
        }
        [HttpPost("Update")]
        public async Task<ServiceResponse<CustomerDTO>> UpdateCustomer([FromBody] CustomerDTO Customer)
        {
            return new ServiceResponse<CustomerDTO>()
            {
                Value = await customerService.UpdateCustomer(Customer)
            };
        }
        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> DeleteCustomerId([FromBody] Guid Id)
        {
            return new ServiceResponse<bool>()
            {
                Value = await customerService.DeleteCustomerId(Id)
            };
        }
        [HttpGet("CustomerById/{Id}")]
        public async Task<ServiceResponse<CustomerDTO>> GetCustomerById(Guid Id)
        {
            return new ServiceResponse<CustomerDTO>()
            {
                Value = await customerService.GetCustomerById(Id)
            };
        }
    }
}
