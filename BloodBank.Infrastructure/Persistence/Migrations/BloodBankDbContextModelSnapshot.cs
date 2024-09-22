﻿// <auto-generated />
using System;
using BloodBank.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BloodBank.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(BloodBankDbContext))]
    partial class BloodBankDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BloodBank.Core.Entities.BloodStock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BloodType")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<int>("IdDonation")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("QuantityML")
                        .HasColumnType("int");

                    b.Property<string>("RHFactor")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("ValidateUntil")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("BloodStocks");
                });

            modelBuilder.Entity("BloodBank.Core.Entities.Donation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DonationDate")
                        .HasColumnType("datetime");

                    b.Property<int>("IdDonor")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("QuantityML")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("IdDonor");

                    b.ToTable("Donations");
                });

            modelBuilder.Entity("BloodBank.Core.Entities.Donor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("BirthDate");

                    b.Property<string>("BloodType")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("RHFactor")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Donors");
                });

            modelBuilder.Entity("BloodBank.Core.Entities.Donation", b =>
                {
                    b.HasOne("BloodBank.Core.Entities.Donor", "Donor")
                        .WithMany("Donations")
                        .HasForeignKey("IdDonor")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Donor");
                });

            modelBuilder.Entity("BloodBank.Core.Entities.Donor", b =>
                {
                    b.OwnsOne("BloodBank.Core.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<int>("DonorId")
                                .HasColumnType("int");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("City");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)")
                                .HasColumnName("Country");

                            b1.Property<string>("PostalCode")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("PostalCode");

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("State");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("Street");

                            b1.HasKey("DonorId");

                            b1.ToTable("Donors");

                            b1.WithOwner()
                                .HasForeignKey("DonorId");
                        });

                    b.OwnsOne("BloodBank.Core.ValueObjects.CPF", "CPF", b1 =>
                        {
                            b1.Property<int>("DonorId")
                                .HasColumnType("int");

                            b1.Property<string>("CPFNumber")
                                .IsRequired()
                                .HasMaxLength(11)
                                .HasColumnType("nvarchar(11)")
                                .HasColumnName("CPFNumber");

                            b1.HasKey("DonorId");

                            b1.HasIndex("CPFNumber")
                                .IsUnique();

                            b1.ToTable("Donors");

                            b1.WithOwner()
                                .HasForeignKey("DonorId");
                        });

                    b.OwnsOne("BloodBank.Core.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<int>("DonorId")
                                .HasColumnType("int");

                            b1.Property<string>("EmailAddress")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("EmailAddress");

                            b1.HasKey("DonorId");

                            b1.HasIndex("EmailAddress")
                                .IsUnique();

                            b1.ToTable("Donors");

                            b1.WithOwner()
                                .HasForeignKey("DonorId");
                        });

                    b.OwnsOne("BloodBank.Core.ValueObjects.Name", "Name", b1 =>
                        {
                            b1.Property<int>("DonorId")
                                .HasColumnType("int");

                            b1.Property<string>("FullName")
                                .IsRequired()
                                .HasMaxLength(150)
                                .HasColumnType("nvarchar(150)")
                                .HasColumnName("FullName");

                            b1.HasKey("DonorId");

                            b1.ToTable("Donors");

                            b1.WithOwner()
                                .HasForeignKey("DonorId");
                        });

                    b.OwnsOne("BloodBank.Core.ValueObjects.Password", "Password", b1 =>
                        {
                            b1.Property<int>("DonorId")
                                .HasColumnType("int");

                            b1.Property<string>("PasswordValue")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("Password");

                            b1.HasKey("DonorId");

                            b1.ToTable("Donors");

                            b1.WithOwner()
                                .HasForeignKey("DonorId");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("CPF")
                        .IsRequired();

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("Name")
                        .IsRequired();

                    b.Navigation("Password")
                        .IsRequired();
                });

            modelBuilder.Entity("BloodBank.Core.Entities.Donor", b =>
                {
                    b.Navigation("Donations");
                });
#pragma warning restore 612, 618
        }
    }
}
