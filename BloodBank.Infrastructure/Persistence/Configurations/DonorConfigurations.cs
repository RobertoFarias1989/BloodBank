using BloodBank.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodBank.Infrastructure.Persistence.Configurations;

public class DonorConfigurations : BaseEntityConfigurations<Donor>
{
    public override void Configure(EntityTypeBuilder<Donor> builder)
    {
        base.Configure(builder);

        builder
            .Property(d => d.BloodType)
            .HasConversion(typeof(string))
            .HasMaxLength(20);

        builder
            .Property(d => d.Gender)
            .HasConversion(typeof(string))
            .HasMaxLength(20);

        builder
            .Property(bs => bs.RHFactor)
            .HasConversion(typeof(string))
            .HasMaxLength(20);

        builder
            .Property(d => d.BirthDate)
            .HasColumnName("datetime");

        builder
            .OwnsOne(d => d.Address);

        builder
            .OwnsOne(d => d.Name);

        builder
            .OwnsOne(d => d.CPF,
            cpf=>
            {
                cpf.HasIndex(d => d.Number)
                .IsUnique();
            });

        builder
            .OwnsOne(d => d.Email,
            email =>
            {
                //para que assim não seja possível cadastrar o mesmo email duas vezes
                email.HasIndex(e => e.EmailAddress)
                .IsUnique();
            });

    }
}
