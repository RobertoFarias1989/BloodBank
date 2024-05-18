using BloodBank.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BloodBank.Infrastructure.Persistence
{
    public class BloodBankDbContext : DbContext
    {
        public BloodBankDbContext(DbContextOptions<BloodBankDbContext> options) : base(options)
        {

        }

        public DbSet<BloodStock> BloodStocks { get; set; }
        public DbSet<Donation>  Donations{ get; set; }
        public DbSet<Donor> Donors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
