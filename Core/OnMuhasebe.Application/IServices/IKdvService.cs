using OnMuhasebe.Application.DTOs;
using OnMuhasebe.Application.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Application.IServices
{
    public interface IKdvService
    {
        public Task<List<KdvDTO>> GetKdvs();
        public Task<KdvDTO> CreateKdv(KdvDTO Kdv);
        public Task<KdvDTO> UpdateKdv(KdvDTO Kdv);
        public Task<bool> DeleteKdvId(Guid id);
        public Task<KdvDTO> GetKdvId(Guid id);
    }
}
