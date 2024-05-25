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
    public class ProductMotionController : ControllerBase
    {
        private readonly IProductMotionService productMotionService;
        public ProductMotionController(IProductMotionService _productMotionService)
        {
            productMotionService = _productMotionService;
        }
        [HttpGet("ProductMotions")]
        public async Task<ServiceResponse<List<ProductMotionDTO>>> GetProductMotions()
        {
            return new ServiceResponse<List<ProductMotionDTO>>()
            {

                Value = await productMotionService.GetProductMotions()
            };
        }
        [HttpPost("Create")]
        public async Task<ServiceResponse<ProductMotionDTO>> CreateProductMotion([FromBody] ProductMotionDTO ProductMotion)
        {
            return new ServiceResponse<ProductMotionDTO>()
            {
                Value = await productMotionService.CreateProductMotion(ProductMotion)
            };
        }
        [HttpPost("Update")]
        public async Task<ServiceResponse<ProductMotionDTO>> UpdateProductMotion([FromBody] ProductMotionDTO ProductMotion)
        {
            return new ServiceResponse<ProductMotionDTO>()
            {
                Value = await productMotionService.UpdateProductMotion(ProductMotion)
            };
        }
        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> DeleteProductMotionId([FromBody] Guid Id)
        {
            return new ServiceResponse<bool>()
            {
                Value = await productMotionService.DeleteProductMotionId(Id)
            };
        }
        [HttpGet("ProductMotionById/{Id}")]
        public async Task<ServiceResponse<ProductMotionDTO>> GetProductMotionById(Guid Id)
        {
            return new ServiceResponse<ProductMotionDTO>()
            {
                Value = await productMotionService.GetProductMotionById(Id)
            };
        }
    }
}

