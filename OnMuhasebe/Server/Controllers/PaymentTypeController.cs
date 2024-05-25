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
    public class PaymentTypeController : ControllerBase
    {
        private readonly IPaymentTypeService paymentTypeService;
        public PaymentTypeController(IPaymentTypeService _paymentTypeService)
        {
            paymentTypeService = _paymentTypeService;
        }
        [HttpGet("PaymentTypes")]
        public async Task<ServiceResponse<List<PaymentTypeDTO>>> GetPaymentTypes()
        {
            return new ServiceResponse<List<PaymentTypeDTO>>()
            {

                Value = await paymentTypeService.GetPaymentTypes()
            };
        }
        [HttpPost("Create")]
        public async Task<ServiceResponse<PaymentTypeDTO>> CreatePaymentType([FromBody] PaymentTypeDTO PaymentType)
        {
            return new ServiceResponse<PaymentTypeDTO>()
            {
                Value = await paymentTypeService.CreatePaymentType(PaymentType)
            };
        }
        [HttpPost("Update")]
        public async Task<ServiceResponse<PaymentTypeDTO>> UpdatePaymentType([FromBody] PaymentTypeDTO PaymentType)
        {
            return new ServiceResponse<PaymentTypeDTO>()
            {
                Value = await paymentTypeService.UpdatePaymentType(PaymentType)
            };
        }
        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> DeletePaymentTypeId([FromBody] Guid Id)
        {
            return new ServiceResponse<bool>()
            {
                Value = await paymentTypeService.DeletePaymentTypeId(Id)
            };
        }
        [HttpGet("PaymentTypeById/{Id}")]
        public async Task<ServiceResponse<PaymentTypeDTO>> GetPaymentTypeById(Guid Id)
        {
            return new ServiceResponse<PaymentTypeDTO>()
            {
                Value = await paymentTypeService.GetPaymentTypeById(Id)
            };
        }
    }
}
