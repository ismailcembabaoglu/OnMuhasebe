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
    public class ProductUnderGroupController : ControllerBase
    {
        private readonly IProductUnderGroupService productUnderGroupService;
        public ProductUnderGroupController(IProductUnderGroupService _productUnderGroupService)
        {
            productUnderGroupService = _productUnderGroupService;
        }
        [HttpGet("ProductUnderGroups")]
        public async Task<ServiceResponse<List<ProductUnderGroupDTO>>> GetProductUnderGroups()
        {
            return new ServiceResponse<List<ProductUnderGroupDTO>>()
            {

                Value = await productUnderGroupService.GetProductUnderGroups()
            };
        }
        [HttpPost("Create")]
        public async Task<ServiceResponse<ProductUnderGroupDTO>> CreateProductUnderGroup([FromBody] ProductUnderGroupDTO ProductUnderGroup)
        {
            return new ServiceResponse<ProductUnderGroupDTO>()
            {
                Value = await productUnderGroupService.CreateProductUnderGroup(ProductUnderGroup)
            };
        }
        [HttpPost("Update")]
        public async Task<ServiceResponse<ProductUnderGroupDTO>> UpdateProductUnderGroup([FromBody] ProductUnderGroupDTO ProductUnderGroup)
        {
            return new ServiceResponse<ProductUnderGroupDTO>()
            {
                Value = await productUnderGroupService.UpdateProductUnderGroup(ProductUnderGroup)
            };
        }
        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> DeleteProductUnderGroupId([FromBody] Guid Id)
        {
            return new ServiceResponse<bool>()
            {
                Value = await productUnderGroupService.DeleteProductUnderGroupId(Id)
            };
        }
        [HttpGet("ProductUnderGroupById/{Id}")]
        public async Task<ServiceResponse<ProductUnderGroupDTO>> GetProductUnderGroupById(Guid Id)
        {
            return new ServiceResponse<ProductUnderGroupDTO>()
            {
                Value = await productUnderGroupService.GetProductUnderGroupById(Id)
            };
        }
    }
}
