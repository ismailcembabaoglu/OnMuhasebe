using OnMuhasebe.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Application.IServices
{
    public interface ISafeBoxService
    {
        public Task<List<SafeBoxDTO>> GetSafeBoxs();
        public Task<SafeBoxDTO> CreateSafeBox(SafeBoxDTO SafeBox);
        public Task<SafeBoxDTO> UpdateSafeBox(SafeBoxDTO SafeBox);
        public Task<bool> DeleteSafeBoxId(Guid id);
        public Task<SafeBoxDTO> GetSafeBoxById(Guid Id);
    }
}
