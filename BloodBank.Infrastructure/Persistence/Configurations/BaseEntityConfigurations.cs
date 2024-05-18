using BloodBank.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodBank.Infrastructure.Persistence.Configurations
{
    public class BaseEntityConfigurations<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.CreatedAt)
                .HasColumnType("datetime");

            builder
                .Property(b => b.UpdatedAt)
                .HasColumnType("datetime");
        }
    }
}
