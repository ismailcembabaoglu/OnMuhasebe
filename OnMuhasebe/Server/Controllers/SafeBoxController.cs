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
    public class SafeBoxController : ControllerBase
    {
        private readonly ISafeBoxService safeBoxService;
        public SafeBoxController(ISafeBoxService _safeBoxService)
        {
            safeBoxService = _safeBoxService;
        }
        [HttpGet("SafeBoxs")]
        public async Task<ServiceResponse<List<SafeBoxDTO>>> GetSafeBoxs()
        {
            return new ServiceResponse<List<SafeBoxDTO>>()
            {

                Value = await safeBoxService.GetSafeBoxs()
            };
        }
        [HttpPost("Create")]
        public async Task<ServiceResponse<SafeBoxDTO>> CreateSafeBox([FromBody] SafeBoxDTO SafeBox)
        {
            return new ServiceResponse<SafeBoxDTO>()
            {
                Value = await safeBoxService.CreateSafeBox(SafeBox)
            };
        }
        [HttpPost("Update")]
        public async Task<ServiceResponse<SafeBoxDTO>> UpdateSafeBox([FromBody] SafeBoxDTO SafeBox)
        {
            return new ServiceResponse<SafeBoxDTO>()
            {
                Value = await safeBoxService.UpdateSafeBox(SafeBox)
            };
        }
        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> DeleteSafeBoxId([FromBody] Guid Id)
        {
            return new ServiceResponse<bool>()
            {
                Value = await safeBoxService.DeleteSafeBoxId(Id)
            };
        }
        [HttpGet("SafeBoxById/{Id}")]
        public async Task<ServiceResponse<SafeBoxDTO>> GetSafeBoxById(Guid Id)
        {
            return new ServiceResponse<SafeBoxDTO>()
            {
                Value = await safeBoxService.GetSafeBoxById(Id)
            };
        }
    }
}
