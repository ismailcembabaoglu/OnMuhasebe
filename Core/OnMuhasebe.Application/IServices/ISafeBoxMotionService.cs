using OnMuhasebe.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Application.IServices
{
    public interface ISafeBoxMotionService
    {
        public Task<List<SafeBoxMotionDTO>> GetSafeBoxMotions();
        public Task<SafeBoxMotionDTO> CreateSafeBoxMotion(SafeBoxMotionDTO SafeBoxMotion);
        public Task<SafeBoxMotionDTO> UpdateSafeBoxMotion(SafeBoxMotionDTO SafeBoxMotion);
        public Task<bool> DeleteSafeBoxMotionId(Guid id);
        public Task<SafeBoxMotionDTO> GetSafeBoxMotionById(Guid Id);
    }
}
