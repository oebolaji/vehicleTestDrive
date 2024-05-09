using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VehiclesApi.Models;

namespace VehiclesApi.Entity_Configuration
{
    public class VehicleEntityTypeConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.Property(b => b.Price).IsRequired();
            builder.Property(b => b.Displacement).HasMaxLength(50);
        }


    }
}
