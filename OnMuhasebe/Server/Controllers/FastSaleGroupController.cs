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
    public class FastSaleGroupController : ControllerBase
    {
        private readonly IFastSaleGroupService fastSaleGroupService;
        public FastSaleGroupController(IFastSaleGroupService _fastSaleGroupService)
        {
            fastSaleGroupService = _fastSaleGroupService;
        }
        [HttpGet("FastSaleGroups")]
        public async Task<ServiceResponse<List<FastSaleGroupDTO>>> GetFastSaleGroups()
        {
            return new ServiceResponse<List<FastSaleGroupDTO>>()
            {

                Value = await fastSaleGroupService.GetFastSaleGroups()
            };
        }
        [HttpPost("Create")]
        public async Task<ServiceResponse<FastSaleGroupDTO>> CreateFastSaleGroup([FromBody] FastSaleGroupDTO FastSaleGroup)
        {
            return new ServiceResponse<FastSaleGroupDTO>()
            {
                Value = await fastSaleGroupService.CreateFastSaleGroup(FastSaleGroup)
            };
        }
        [HttpPost("Update")]
        public async Task<ServiceResponse<FastSaleGroupDTO>> UpdateFastSaleGroup([FromBody] FastSaleGroupDTO FastSaleGroup)
        {
            return new ServiceResponse<FastSaleGroupDTO>()
            {
                Value = await fastSaleGroupService.UpdateFastSaleGroup(FastSaleGroup)
            };
        }
        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> DeleteFastSaleGroupId([FromBody] Guid Id)
        {
            return new ServiceResponse<bool>()
            {
                Value = await fastSaleGroupService.DeleteFastSaleGroupId(Id)
            };
        }
        [HttpGet("FastSaleGroupById/{Id}")]
        public async Task<ServiceResponse<FastSaleGroupDTO>> GetFastSaleGroupById(Guid Id)
        {
            return new ServiceResponse<FastSaleGroupDTO>()
            {
                Value = await fastSaleGroupService.GetFastSaleGroupById(Id)
            };
        }
    }
}
