using Congestion_tax_calculator_api.Entities.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Congestion_tax_calculator_api.DataAccess
{
    public class VehicleTaxContext : DbContext
    {
        public VehicleTaxContext(DbContextOptions<VehicleTaxContext> options) : base(options)
        {
        }

        public DbSet<City> City { get; set; }
        public DbSet<VehicleEntry> VehicleEntry { get; set; }
        public DbSet<VehicleType> VehicleType { get; set; }
        public DbSet<ExcemptVehicle> ExcemptVehicle { get; set; }
        public DbSet<CityTaxRule> CityTaxRule { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().ToTable("City");
            modelBuilder.Entity<VehicleType>().ToTable("VehicleType");
            modelBuilder.Entity<ExcemptVehicle>().ToTable("ExcemptVehicle");
            modelBuilder.Entity<VehicleEntry>().ToTable("VehicleEntry");
            modelBuilder.Entity<CityTaxRule>().ToTable("CityTaxRule");
            modelBuilder.Entity<CityTaxRule>().Property(s => s.FromTime).HasConversion(new TimeSpanToTicksConverter());
            modelBuilder.Entity<CityTaxRule>().Property(s => s.ToTime).HasConversion(new TimeSpanToTicksConverter());



        }
    }
}