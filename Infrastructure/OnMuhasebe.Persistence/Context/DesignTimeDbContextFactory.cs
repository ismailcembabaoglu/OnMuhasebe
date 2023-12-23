using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Persistence.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<OnMuhasebePsqlDbContext>
    {
        public OnMuhasebePsqlDbContext CreateDbContext(string[] args)
        {
            ConfigurationManager configurationManager = new ConfigurationManager();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../OnMuhasebe/Server"));
            configurationManager.AddJsonFile("appsettings.json");
            var builder = new DbContextOptionsBuilder<OnMuhasebePsqlDbContext>();
            builder.UseNpgsql(configurationManager.GetConnectionString("PostgreSQL"));
            return new OnMuhasebePsqlDbContext(builder.Options);
        }
    }
}
