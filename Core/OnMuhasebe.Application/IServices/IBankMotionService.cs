using OnMuhasebe.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Application.IServices
{
    public interface IBankMotionService
    {
        public Task<List<BankMotionDTO>> GetBankMotions();
        public Task<BankMotionDTO> CreateBankMotion(BankMotionDTO BankMotion);
        public Task<BankMotionDTO> UpdateBankMotion(BankMotionDTO BankMotion);
        public Task<bool> DeleteBankMotionId(Guid id);
        public Task<BankMotionDTO> GetBankMotionById(Guid Id);
    }
}
