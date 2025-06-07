using Carpro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Carpro.Infrastructure.Data.Configurations;

/// <summary>
/// Configuration for the Vehicle entity
/// </summary>
public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.HasKey(v => v.VehicleRegNum);

        builder.Property(v => v.VehicleRegNum)
            .ValueGeneratedNever();

        builder.Property(v => v.VehicleModel)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(v => v.VehicleProdYear)
            .IsRequired()
            .HasMaxLength(4);
    }
}

