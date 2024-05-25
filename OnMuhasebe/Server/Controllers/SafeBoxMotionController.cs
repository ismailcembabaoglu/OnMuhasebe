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
    public class SafeBoxMotionController : ControllerBase
    {
        private readonly ISafeBoxMotionService safeBoxMotionService;
        public SafeBoxMotionController(ISafeBoxMotionService _safeBoxMotionService)
        {
            safeBoxMotionService = _safeBoxMotionService;
        }
        [HttpGet(" SafeBoxMotions")]
        public async Task<ServiceResponse<List<SafeBoxMotionDTO>>> GetSafeBoxMotions()
        {
            return new ServiceResponse<List<SafeBoxMotionDTO>>()
            {

                Value = await safeBoxMotionService.GetSafeBoxMotions()
            };
        }
        [HttpPost("Create")]
        public async Task<ServiceResponse<SafeBoxMotionDTO>> CreateSafeBoxMotion([FromBody] SafeBoxMotionDTO SafeBoxMotion)
        {
            return new ServiceResponse<SafeBoxMotionDTO>()
            {
                Value = await safeBoxMotionService.CreateSafeBoxMotion(SafeBoxMotion)
            };
        }
        [HttpPost("Update")]
        public async Task<ServiceResponse<SafeBoxMotionDTO>> UpdateSafeBoxMotion([FromBody] SafeBoxMotionDTO SafeBoxMotion)
        {
            return new ServiceResponse<SafeBoxMotionDTO>()
            {
                Value = await safeBoxMotionService.UpdateSafeBoxMotion(SafeBoxMotion)
            };
        }
        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> DeleteSafeBoxMotionId([FromBody] Guid Id)
        {
            return new ServiceResponse<bool>()
            {
                Value = await safeBoxMotionService.DeleteSafeBoxMotionId(Id)
            };
        }
        [HttpGet("SafeBoxMotionById/{Id}")]
        public async Task<ServiceResponse<SafeBoxMotionDTO>> GetSafeBoxMotionById(Guid Id)
        {
            return new ServiceResponse<SafeBoxMotionDTO>()
            {
                Value = await safeBoxMotionService.GetSafeBoxMotionById(Id)
            };
        }
    }
}
