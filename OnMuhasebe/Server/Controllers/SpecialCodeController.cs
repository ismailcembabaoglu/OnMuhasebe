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
    public class SpecialCodeController : ControllerBase
    {
        private readonly ISpecialCodeService specialCodeService;
        public SpecialCodeController(ISpecialCodeService _specialCodeService)
        {
            specialCodeService = _specialCodeService;
        }
        [HttpGet("SpecialCodes")]
        public async Task<ServiceResponse<List<SpecialCodeDTO>>> GetSpecialCodes()
        {
            return new ServiceResponse<List<SpecialCodeDTO>>()
            {

                Value = await specialCodeService.GetSpecialCodes()
            };
        }
        [HttpPost("Create")]
        public async Task<ServiceResponse<SpecialCodeDTO>> CreateSpecialCode([FromBody] SpecialCodeDTO SpecialCode)
        {
            return new ServiceResponse<SpecialCodeDTO>()
            {
                Value = await specialCodeService.CreateSpecialCode(SpecialCode)
            };
        }
        [HttpPost("Update")]
        public async Task<ServiceResponse<SpecialCodeDTO>> UpdateSpecialCode([FromBody] SpecialCodeDTO SpecialCode)
        {
            return new ServiceResponse<SpecialCodeDTO>()
            { 
                Value = await specialCodeService.UpdateSpecialCode(SpecialCode)
            };
        }
        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> DeleteSpecialCodeId([FromBody] Guid Id)
        {
            return new ServiceResponse<bool>()
            {
                Value = await specialCodeService.DeleteSpecialCodeId(Id)
            };
        }
        [HttpGet("SpecialCodeById/{Id}")]
        public async Task<ServiceResponse<SpecialCodeDTO>> GetSpecialCodeById(Guid Id)
        {
            return new ServiceResponse<SpecialCodeDTO>()
            {
                Value = await specialCodeService.GetSpecialCodeById(Id)
            };
        }
    }
}
