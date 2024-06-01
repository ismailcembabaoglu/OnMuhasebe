using OnMuhasebe.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Application.IServices
{
    public interface IPriceService
    {
        public Task<List<PriceDTO>> GetPrices();
        public Task<PriceDTO> CreatePrice(PriceDTO Price);
        public Task<PriceDTO> UpdatePrice(PriceDTO Price);
        public Task<bool> DeletePriceId(Guid id);
        public Task<PriceDTO> GetPriceById(Guid Id);
        public Task<List<PriceDTO>> GetPriceProductById(Guid productId);
    }
}
