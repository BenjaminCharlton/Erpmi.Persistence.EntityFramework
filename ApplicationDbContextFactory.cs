using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace Erpmi.Persistence.EntityFramework
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                         .SetBasePath(Directory.GetCurrentDirectory())
                         .AddJsonFile("appsettings.json")
                         .AddJsonFile("appsettings.Development.json", optional: true)
                         .Build();

            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();

            //builder.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"], b => b.MigrationsAssembly("Erpmi"));
            //builder.UseOpenIddict();

            return new ApplicationDbContext(builder.Options);
        }
    }
}