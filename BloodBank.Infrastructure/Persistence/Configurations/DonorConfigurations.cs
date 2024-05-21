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
            .OwnsOne(d => d.Address)
            .Property(a => a.Street)
            .HasMaxLength(100);

        builder
            .OwnsOne(d => d.Address)
            .Property(a => a.City)
            .HasMaxLength(100);

        builder
            .OwnsOne(d => d.Address)
            .Property(a => a.State)
            .HasMaxLength(100);

        builder
            .OwnsOne(d => d.Address)
            .Property(a => a.PostalCode)
            .HasMaxLength(100);

        builder
            .OwnsOne(d => d.Address)
            .Property(a => a.Country)
            .HasMaxLength(50);

        builder
            .OwnsOne(d => d.Name)
            .Property(n => n.FullName)
            .HasMaxLength(150);

        builder
            .OwnsOne(d => d.CPF,
            cpf=>
            {
                cpf.HasIndex(d => d.CPFNumber)
                .IsUnique();
            });

        builder
           .OwnsOne(d => d.CPF)
           .Property(c => c.CPFNumber)
           .HasMaxLength(11);

        builder
            .OwnsOne(d => d.Email,
            email =>
            {
                //para que assim não seja possível cadastrar o mesmo email duas vezes
                email.HasIndex(e => e.EmailAddress)
                .IsUnique();
            });

        builder
            .OwnsOne(d => d.Email)
            .Property(e => e.EmailAddress)
            .HasMaxLength(100);
    }
}
