using OnMuhasebe.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Application.IServices
{
    public interface IBankService
    {
        public Task<List<BankDTO>> GetBanks();
        public Task<BankDTO> CreateBank(BankDTO Bank);
        public Task<BankDTO> UpdateBank(BankDTO Bank);
        public Task<bool> DeleteBankId(Guid id);
        public Task<BankDTO> GetBankById(Guid Id);
    }
}
