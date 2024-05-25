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
    public class ProductGroupController : ControllerBase
    {
        private readonly IProductGroupService productGroupService;
        public ProductGroupController(IProductGroupService _productGroupService)
        {
            productGroupService = _productGroupService;
        }
        [HttpGet("ProductGroups")]
        public async Task<ServiceResponse<List<ProductGroupDTO>>> GetProductGroups()
        {
            return new ServiceResponse<List<ProductGroupDTO>>()
            {

                Value = await productGroupService.GetProductGroups()
            };
        }
        [HttpPost("Create")]
        public async Task<ServiceResponse<ProductGroupDTO>> CreateProductGroup([FromBody] ProductGroupDTO ProductGroup)
        {
            return new ServiceResponse<ProductGroupDTO>()
            {
                Value = await productGroupService.CreateProductGroup(ProductGroup)
            };
        }
        [HttpPost("Update")]
        public async Task<ServiceResponse<ProductGroupDTO>> UpdateProductGroup([FromBody] ProductGroupDTO ProductGroup)
        {
            return new ServiceResponse<ProductGroupDTO>()
            {
                Value = await productGroupService.UpdateProductGroup(ProductGroup)
            };
        }
        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> DeleteProductGroupId([FromBody] Guid Id)
        {
            return new ServiceResponse<bool>()
            {
                Value = await productGroupService.DeleteProductGroupId(Id)
            };
        }
        [HttpGet("ProductGroupById/{Id}")]
        public async Task<ServiceResponse<ProductGroupDTO>> GetProductGroupById(Guid Id)
        {
            return new ServiceResponse<ProductGroupDTO>()
            {
                Value = await productGroupService.GetProductGroupById(Id)
            };
        }
    }
}
