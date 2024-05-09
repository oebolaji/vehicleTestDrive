using CustomersApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomersApi.Data
{
    public class ConsumerDbContext :DbContext
    {
        public DbSet<Consumer>? Consumers { get; set; }
        public DbSet<Vehicle>? Vehicles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; Database=ConsumerApiDb;");
        }
    }
}
