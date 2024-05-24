using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OnMuhasebe.Application.DTOs;
using OnMuhasebe.Application.IServices;
using OnMuhasebe.Domain.Models;
using OnMuhasebe.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Persistence.Services
{
    public class FastSaleGroupService : IFastSaleGroupService
    {
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly OnMuhasebePsqlDbContext context;

        public FastSaleGroupService(IMapper _mapper, IConfiguration _configuration, OnMuhasebePsqlDbContext _context)
        {
            mapper = _mapper;
            configuration = _configuration;
            context = _context;
        }

        public async Task<FastSaleGroupDTO> CreateFastSaleGroup(FastSaleGroupDTO FastSaleGroup)
        {

            var dbFastSaleGroup = await context.FastSaleGroups.Where(c => c.Id == FastSaleGroup.Id).FirstOrDefaultAsync();
            if (dbFastSaleGroup != null)
                throw new Exception("Hızlı Satış Grubu Zaten Sistemde Kayıtlı");
            dbFastSaleGroup = mapper.Map<FastSaleGroup>(FastSaleGroup);
            dbFastSaleGroup.CreateDate = DateTime.Now;
            await context.FastSaleGroups.AddAsync(dbFastSaleGroup);
            int result = await context.SaveChangesAsync();

            return mapper.Map<FastSaleGroupDTO>(dbFastSaleGroup);
        }

        public async Task<bool> DeleteFastSaleGroupId(Guid id)
        {
            var dbFastSaleGroup = await context.FastSaleGroups.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (dbFastSaleGroup == null)
                throw new Exception("Hızlı Satış Grubu Bulunamadı");
            context.FastSaleGroups.Remove(dbFastSaleGroup);
            int result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<FastSaleGroupDTO> GetFastSaleGroupById(Guid Id)
        {
            var dbFastSaleGroup = await context.FastSaleGroups.Where(c => c.Id == Id)
                .ProjectTo<FastSaleGroupDTO>(mapper.ConfigurationProvider).FirstOrDefaultAsync();
            if (dbFastSaleGroup == null)
                throw new Exception("Hızlı Satış Grubu Bulunamadı.");
            return dbFastSaleGroup;
        }

        public async Task<List<FastSaleGroupDTO>> GetFastSaleGroups()
        {
            var dbFastSaleGroup = await context.FastSaleGroups.ProjectTo<FastSaleGroupDTO>(mapper.ConfigurationProvider).ToListAsync();
            return dbFastSaleGroup;
        }

        public async Task<FastSaleGroupDTO> UpdateFastSaleGroup(FastSaleGroupDTO FastSaleGroup)
        {
            var dbFastSaleGroup = await context.FastSaleGroups.Where(c => c.Id == FastSaleGroup.Id).FirstOrDefaultAsync();

            if (dbFastSaleGroup == null)
                throw new Exception("Hızlı Satış Grubu Bulunamadığından Dolayı Güncelleme İşlemi Başarısız");
            mapper.Map(FastSaleGroup, dbFastSaleGroup);

            int result = await context.SaveChangesAsync();
            return mapper.Map<FastSaleGroupDTO>(dbFastSaleGroup);
        }
    }
}
