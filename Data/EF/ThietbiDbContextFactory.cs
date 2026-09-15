using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace WebApi.Data.EF
{
    public class ThietbiDbContextFactory : IDesignTimeDbContextFactory<ThietbiDbContext>
    {
        public ThietbiDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("ThietbiDb");

            var optionsBuilder = new DbContextOptionsBuilder<ThietbiDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new ThietbiDbContext(optionsBuilder.Options);
        }
    }
}
