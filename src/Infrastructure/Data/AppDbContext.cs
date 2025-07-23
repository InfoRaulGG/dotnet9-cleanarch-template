using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.TypedIds;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración para User
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(u => u.Id)
                      .HasConversion(
                          id => id.Value,
                          value => new UserId(value));

                entity.HasKey(u => u.Id);

                entity.OwnsOne(u => u.Email, email =>
                {
                    email.Property(e => e.Value).HasColumnName("Email");
                });

                entity.OwnsOne(u => u.Name, userName =>
                {
                    userName.Property(e => e.Value).HasColumnName("UserName");
                });

                // Aquí puedes mapear otras propiedades, relaciones, etc.
            });

            // Configuración para Message, Email, y otras entidades o Value Objects
            // Por ejemplo, para Email como Owned Type (si aplica)
            // modelBuilder.Entity<User>()
            //     .OwnsOne(u => u.Email, email =>
            //     {
            //         email.Property(e => e.Value).HasColumnName("Email");
            //     });

            // Similar para otros Value Objects o propiedades complejas
        }

    }
}
