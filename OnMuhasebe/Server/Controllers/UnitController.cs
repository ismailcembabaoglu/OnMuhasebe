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
    public class UnitController : ControllerBase
    {
        private readonly IUnitService unitService;
        public UnitController(IUnitService _unitService)
        {
            unitService = _unitService;
        }
        [HttpGet("Units")]
        public async Task<ServiceResponse<List<UnitDTO>>> GetUnits()
        {
            return new ServiceResponse<List<UnitDTO>>()
            {

                Value = await unitService.GetUnits()
            };
        }
        [HttpPost("Create")]
        public async Task<ServiceResponse<UnitDTO>> CreateUnit([FromBody] UnitDTO Unit)
        {
            return new ServiceResponse<UnitDTO>()
            {
                Value = await unitService.CreateUnit(Unit)
            };
        }
        [HttpPost("Update")]
        public async Task<ServiceResponse<UnitDTO>> UpdateUnit([FromBody] UnitDTO Unit)
        {
            return new ServiceResponse<UnitDTO>()
            {
                Value = await unitService.UpdateUnit(Unit)
            };
        }
        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> DeleteUnitId([FromBody] Guid Id)
        {
            return new ServiceResponse<bool>()
            {
                Value = await unitService.DeleteUnitId(Id)
            };
        }
        [HttpGet("UnitById/{Id}")]
        public async Task<ServiceResponse<UnitDTO>> GetUnitById(Guid Id)
        {
            return new ServiceResponse<UnitDTO>()
            {
                Value = await unitService.GetUnitById(Id)
            };
        }
    }
}
