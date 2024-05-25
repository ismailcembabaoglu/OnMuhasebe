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
    public class FastSaleController : ControllerBase
    {
        private readonly IFastSaleService fastSaleService;
        public FastSaleController(IFastSaleService _fastSaleService)
        {
            fastSaleService = _fastSaleService;
        }
        [HttpGet("FastSales")]
        public async Task<ServiceResponse<List<FastSaleDTO>>> GetFastSales()
        {
            return new ServiceResponse<List<FastSaleDTO>>()
            {

                Value = await fastSaleService.GetFastSales()
            };
        }
        [HttpPost("Create")]
        public async Task<ServiceResponse<FastSaleDTO>> CreateFastSale([FromBody] FastSaleDTO FastSale)
        {
            return new ServiceResponse<FastSaleDTO>()
            {
                Value = await fastSaleService.CreateFastSale(FastSale)
            };
        }
        [HttpPost("Update")]
        public async Task<ServiceResponse<FastSaleDTO>> UpdateFastSale([FromBody] FastSaleDTO FastSale)
        {
            return new ServiceResponse<FastSaleDTO>()
            {
                Value = await fastSaleService.UpdateFastSale(FastSale)
            };
        }
        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> DeleteFastSaleId([FromBody] Guid Id)
        {
            return new ServiceResponse<bool>()
            {
                Value = await fastSaleService.DeleteFastSaleId(Id)
            };
        }
        [HttpGet("FastSaleById/{Id}")]
        public async Task<ServiceResponse<FastSaleDTO>> GetFastSaleById(Guid Id)
        {
            return new ServiceResponse<FastSaleDTO>()
            {
                Value = await fastSaleService.GetFastSaleById(Id)
            };
        }
    }
}
