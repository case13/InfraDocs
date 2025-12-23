using InfraDocs.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace InfraDocs.Infrastructure.Data
{
    public class InfraDocsDbContextFactory : IDesignTimeDbContextFactory<InfraDocsDbContext>
    {
        public InfraDocsDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<InfraDocsDbContext>();

            optionsBuilder.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")
            );

            return new InfraDocsDbContext(optionsBuilder.Options);
        }
    }
}
