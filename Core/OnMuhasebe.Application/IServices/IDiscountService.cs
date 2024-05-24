using OnMuhasebe.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Application.IServices
{
    public interface IDiscountService
    {
        public Task<List<DiscountDTO>> GetDiscounts();
        public Task<DiscountDTO> CreateDiscount(DiscountDTO Discount);
        public Task<DiscountDTO> UpdateDiscount(DiscountDTO Discount);
        public Task<bool> DeleteDiscountId(Guid id);
        public Task<DiscountDTO> GetDiscountById(Guid Id);
    }
}
