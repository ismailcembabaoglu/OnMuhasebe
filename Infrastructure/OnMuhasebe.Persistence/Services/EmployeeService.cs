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
    public class EmployeeService : IEmployeeService
    {
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly OnMuhasebePsqlDbContext context;

        public EmployeeService(IMapper _mapper, IConfiguration _configuration, OnMuhasebePsqlDbContext _context)
        {
            mapper = _mapper;
            configuration = _configuration;
            context = _context;
        }

        public async Task<EmployeeDTO> CreateEmployee(EmployeeDTO Employee)
        {
            var dbEmployee = await context.Employees.Where(c => c.Id == Employee.Id).FirstOrDefaultAsync();
            if (dbEmployee != null)
                throw new Exception("Çalışan Zaten Sistemde Kayıtlı");
            dbEmployee = mapper.Map<Employee>(Employee);
            dbEmployee.CreateDate = DateTime.Now;
            await context.Employees.AddAsync(dbEmployee);
            int result = await context.SaveChangesAsync();

            return mapper.Map<EmployeeDTO>(dbEmployee);
        }

        public async Task<bool> DeleteEmployeeId(Guid id)
        {
            var dbEmployee = await context.Employees.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (dbEmployee == null)
                throw new Exception("Çalışan Bulunamadı");
            context.Employees.Remove(dbEmployee);
            int result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<EmployeeDTO> GetEmployeeById(Guid Id)
        {
            var dbEmployee = await context.Employees.Where(c => c.Id == Id)
                .ProjectTo<EmployeeDTO>(mapper.ConfigurationProvider).FirstOrDefaultAsync();
            if (dbEmployee == null)
                throw new Exception("Çalışan Bulunamadı.");
            return dbEmployee;
        }

        public async Task<List<EmployeeDTO>> GetEmployees()
        {
            var dbEmployee = await context.Employees.ProjectTo<EmployeeDTO>(mapper.ConfigurationProvider).ToListAsync();
            return dbEmployee;
        }

        public async Task<EmployeeDTO> UpdateEmployee(EmployeeDTO Employee)
        {
            var dbEmployee = await context.Employees.Where(c => c.Id == Employee.Id).FirstOrDefaultAsync();

            if (dbEmployee == null)
                throw new Exception("Çalışan Bulunamadığından Dolayı Güncelleme İşlemi Başarısız");
            mapper.Map(Employee, dbEmployee);

            int result = await context.SaveChangesAsync();
            return mapper.Map<EmployeeDTO>(dbEmployee);
        }
    }
}
