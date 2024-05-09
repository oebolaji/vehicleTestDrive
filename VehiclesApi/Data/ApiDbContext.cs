using Microsoft.EntityFrameworkCore;
using System.Reflection;
using VehiclesApi.Models;

namespace VehiclesApi.Data
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; Database=VehicleApiDb;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //modelBuilder.Entity<Vehicle>()
            //    .Property(b => b.MaxSpeed)
            //    .HasMaxLength(50)
            //    .IsRequired();
        }


    }
}
