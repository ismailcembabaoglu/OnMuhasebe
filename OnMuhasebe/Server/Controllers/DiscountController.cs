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
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService discountService;
        public DiscountController(IDiscountService _discountService)
        {
            discountService = _discountService;
        }
        [HttpGet("Discounts")]
        public async Task<ServiceResponse<List<DiscountDTO>>> GetDiscounts()
        {
            return new ServiceResponse<List<DiscountDTO>>()
            {

                Value = await discountService.GetDiscounts()
            };
        }
        [HttpPost("Create")]
        public async Task<ServiceResponse<DiscountDTO>> CreateDiscount([FromBody] DiscountDTO Discount)
        {
            return new ServiceResponse<DiscountDTO>()
            {
                Value = await discountService.CreateDiscount(Discount)
            };
        }
        [HttpPost("Update")]
        public async Task<ServiceResponse<DiscountDTO>> UpdateDiscount([FromBody] DiscountDTO Discount)
        {
            return new ServiceResponse<DiscountDTO>()
            {
                Value = await discountService.UpdateDiscount(Discount)
            };
        }
        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> DeleteDiscountId([FromBody] Guid Id)
        {
            return new ServiceResponse<bool>()
            {
                Value = await discountService.DeleteDiscountId(Id)
            };
        }
        [HttpGet("DiscountById/{Id}")]
        public async Task<ServiceResponse<DiscountDTO>> GetDiscountById(Guid Id)
        {
            return new ServiceResponse<DiscountDTO>()
            {
                Value = await discountService.GetDiscountById(Id)
            };
        }
    }
}
