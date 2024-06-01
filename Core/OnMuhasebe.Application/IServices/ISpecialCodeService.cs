using OnMuhasebe.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Application.IServices
{
    public interface ISpecialCodeService
    {
        public Task<List<SpecialCodeDTO>> GetSpecialCodes();
        public Task<SpecialCodeDTO> CreateSpecialCode(SpecialCodeDTO SpecialCode);
        public Task<SpecialCodeDTO> UpdateSpecialCode(SpecialCodeDTO SpecialCode);
        public Task<List<SpecialCodeDTO>> GetSpecialCodeProductById(Guid productId);
        public Task<bool> DeleteSpecialCodeId(Guid id);
        public Task<SpecialCodeDTO> GetSpecialCodeById(Guid Id);
    }
}
