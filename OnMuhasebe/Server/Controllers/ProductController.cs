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
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductController(IProductService _productService)
        {
            productService = _productService;
        }
        [HttpGet("Products")]
        public async Task<ServiceResponse<List<ProductDTO>>> GetProducts()
        {
            return new ServiceResponse<List<ProductDTO>>()
            {

                Value = await productService.GetProducts()
            };
        }
        [HttpPost("Create")]
        public async Task<ServiceResponse<ProductDTO>> CreateProduct([FromBody] ProductDTO Product)
        {
            return new ServiceResponse<ProductDTO>()
            {
                Value = await productService.CreateProduct(Product)
            };
        }
        [HttpPost("Update")]
        public async Task<ServiceResponse<ProductDTO>> UpdateProduct([FromBody] ProductDTO Product)
        {
            return new ServiceResponse<ProductDTO>()
            {
                Value = await productService.UpdateProduct(Product)
            };
        }
        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> DeleteProductId([FromBody] Guid Id)
        {
            return new ServiceResponse<bool>()
            {
                Value = await productService.DeleteProductId(Id)
            };
        }
        [HttpGet("ProductById/{Id}")]
        public async Task<ServiceResponse<ProductDTO>> GetProductById(Guid Id)
        {
            return new ServiceResponse<ProductDTO>()
            {
                Value = await productService.GetProductById(Id)
            };
        }
    }
}
