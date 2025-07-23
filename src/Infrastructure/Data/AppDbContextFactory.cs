using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            // Cambia la cadena de conexión por la que uses en desarrollo
            optionsBuilder.UseNpgsql("Host=localhost;Database=appdb;Username=appuser;Password=appsecret");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
