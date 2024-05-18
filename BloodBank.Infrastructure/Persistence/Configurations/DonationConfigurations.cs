using BloodBank.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodBank.Infrastructure.Persistence.Configurations
{
    public class DonationConfigurations : BaseEntityConfigurations<Donation>
    {
        public override void Configure(EntityTypeBuilder<Donation> builder)
        {
            base.Configure(builder);

            builder
                .Property(d => d.DonationDate)
                .HasColumnType("datetime");

            
        }
    }
}
