using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OnMuhasebe.Application.DTOs;
using OnMuhasebe.Application.IServices;
using OnMuhasebe.Domain.Models;
using OnMuhasebe.Persistence.Context;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Persistence.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly OnMuhasebePsqlDbContext context;
        public UserService(IMapper _mapper, IConfiguration _configuration, OnMuhasebePsqlDbContext _context)
        {
            mapper = _mapper;
            configuration = _configuration;
            context = _context;
        }
        public async Task<UserDTO> CreateUser(UserDTO user)
        {
            var dbUser = await context.Users.Where(c => c.Id == user.Id).FirstOrDefaultAsync();
            if (dbUser != null)
                throw new Exception("Bu Kullanıcı Zaten Sistemde Kayıtlı");
            dbUser = mapper.Map<User>(user);
            dbUser.CreatedAt = DateTime.Now;
            await context.Users.AddAsync(dbUser);
            int result = await context.SaveChangesAsync();

            return mapper.Map<UserDTO>(dbUser);

        }

        public async Task<bool> DeleteUserId(Guid id)
        {
            var dbUser = await context.Users.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (dbUser == null)
                throw new Exception("Kullanıcı Bulunamadı");
            context.Users.Remove(dbUser);
            int result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<UserDTO> GetUserById(Guid Id)
        {
            var dbUser = await context.Users.Where(c => c.Id == Id)
                .ProjectTo<UserDTO>(mapper.ConfigurationProvider).FirstOrDefaultAsync();
            if (dbUser == null)
                throw new Exception("Kullanıcı Bulunamadı.");
            return dbUser;
        }

        public async Task<List<UserDTO>> GetUsers()
        {
            var dbUser = await context.Users.ProjectTo<UserDTO>(mapper.ConfigurationProvider).ToListAsync();
            return dbUser;
        }

        public async Task<UserLoginResponseDTO> Login(string Email, string Password)
        {
            var dbUser = await context.Users.FirstOrDefaultAsync(c => c.Email == Email && c.Password == Password);
            if (dbUser == null)
                throw new Exception("Kıllanıcı Bulunamadı veya girilen bilgiler yanlış");
            if (!dbUser.IsActive)
                throw new Exception("Kullanıcı Durumu Pasif");

            UserLoginResponseDTO result = new UserLoginResponseDTO();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSecurityKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.Now.AddDays(int.Parse(configuration["JwtExpiryInDays"].ToString()));
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, Email),
                new Claim(ClaimTypes.Name, dbUser.FirstName + " " + dbUser.LastName),
                new Claim(ClaimTypes.UserData, dbUser.Id.ToString())
            };
            var token = new JwtSecurityToken(configuration["JwtIssuer"], configuration["JwtAudience"], claims.ToArray(), null, expiry, creds);
            result.ApiToken = new JwtSecurityTokenHandler().WriteToken(token);
            result.User = mapper.Map<UserDTO>(dbUser);

            return result;
        }

        public async Task<UserDTO> UpdateUser(UserDTO User)
        {
            var dbUser = await context.Users.Where(c => c.Id == User.Id).FirstOrDefaultAsync();
            if (dbUser == null)
                throw new Exception("Kullanıcı Bulunamadığından Dolayı Güncelleme İşlemi Başarısız");
            mapper.Map(User, dbUser);

            int result = await context.SaveChangesAsync();
            return mapper.Map<UserDTO>(dbUser);
        }
    }
}
