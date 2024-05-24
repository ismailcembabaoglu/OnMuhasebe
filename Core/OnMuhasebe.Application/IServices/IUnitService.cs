using OnMuhasebe.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Application.IServices
{
    public interface IUnitService
    {
        public Task<List<UnitDTO>> GetUnits();
        public Task<UnitDTO> CreateUnit(UnitDTO Unit);
        public Task<UnitDTO> UpdateUnit(UnitDTO Unit);
        public Task<bool> DeleteUnitId(Guid id);
        public Task<UnitDTO> GetUnitById(Guid Id);
    }
}
