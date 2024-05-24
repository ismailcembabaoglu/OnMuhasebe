using OnMuhasebe.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Application.IServices
{
    public interface IFastSaleService
    {
        public Task<List<FastSaleDTO>> GetFastSales();
        public Task<FastSaleDTO> CreateFastSale(FastSaleDTO FastSale);
        public Task<FastSaleDTO> UpdateFastSale(FastSaleDTO FastSale);
        public Task<bool> DeleteFastSaleId(Guid id);
        public Task<FastSaleDTO> GetFastSaleById(Guid Id);
    }
}
