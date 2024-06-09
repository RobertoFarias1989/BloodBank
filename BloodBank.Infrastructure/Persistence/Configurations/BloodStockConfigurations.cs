using BloodBank.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodBank.Infrastructure.Persistence.Configurations;

public class BloodStockConfigurations : BaseEntityConfigurations<BloodStock>
{
    public override void Configure(EntityTypeBuilder<BloodStock> builder)
    {
        base.Configure(builder);

        builder
            .Property(bs => bs.BloodType)
            .HasConversion(typeof(string))
            .HasMaxLength(20);

        builder
            .Property(bs => bs.RHFactor)
            .HasConversion(typeof(string))
            .HasMaxLength(20);
    }
}
