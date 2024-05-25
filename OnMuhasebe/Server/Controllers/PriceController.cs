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
    public class PriceController : ControllerBase
    {
        private readonly IPriceService priceService;
        public PriceController(IPriceService _priceService)
        {
            priceService = _priceService;
        }
        [HttpGet("Prices")]
        public async Task<ServiceResponse<List<PriceDTO>>> GetPrices()
        {
            return new ServiceResponse<List<PriceDTO>>()
            {

                Value = await priceService.GetPrices()
            };
        }
        [HttpPost("Create")]
        public async Task<ServiceResponse<PriceDTO>> CreatePrice([FromBody] PriceDTO Price)
        {
            return new ServiceResponse<PriceDTO>()
            {
                Value = await priceService.CreatePrice(Price)
            };
        }
        [HttpPost("Update")]
        public async Task<ServiceResponse<PriceDTO>> UpdatePrice([FromBody] PriceDTO Price)
        {
            return new ServiceResponse<PriceDTO>()
            {
                Value = await priceService.UpdatePrice(Price)
            };
        }
        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> DeletePriceId([FromBody] Guid Id)
        {
            return new ServiceResponse<bool>()
            {
                Value = await priceService.DeletePriceId(Id)
            };
        }
        [HttpGet("PriceById/{Id}")]
        public async Task<ServiceResponse<PriceDTO>> GetPriceById(Guid Id)
        {
            return new ServiceResponse<PriceDTO>()
            {
                Value = await priceService.GetPriceById(Id)
            };
        }
    }
}
