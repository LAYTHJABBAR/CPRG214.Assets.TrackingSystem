using CPRG214.AssetTrackingSystem.Domain;
using Microsoft.EntityFrameworkCore;
using System;


namespace CPRG214.AssetTrackingSystem.Data
{

    public class AssetContext : DbContext
    {
        // Context which calls the base class constructor.
        public AssetContext() : base() { }

        // Collection properties for the Domain properties.
        public DbSet<Asset> Assets { get; set; }
        public DbSet<AssetType> AssetTypes { get; set; }

        // Connection Method / change for your home computer/Lap computer
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\sqlexpress01;
                                          Database=Assets;
                                          Trusted_Connection=True;", b => b.MigrationsAssembly("CPRG214.AssetTrackingSystem.Domain"));
        }

        // Seed Example data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AssetType>().HasData(
                new AssetType { Id = 1, Name = "Computer" },
                new AssetType { Id = 2, Name = "Monitor" },
                new AssetType { Id = 3, Name = "Phone" }
                );

            modelBuilder.Entity<Asset>().HasData(
                new Asset
                {
                    Id = 1,
                    TagNumber = "C-234a",
                    AssetTypeId = 1,
                    Manufacturer = "Dell",
                    Model = "G34625",
                    Description = "Inspiron 15 3000 Laptop",
                    SerialNumber = "a12bg5420"
                },
                new Asset
                {
                    Id = 2,
                    TagNumber = "c-235a",
                    AssetTypeId = 2,
                    Manufacturer = "Acer",
                    Model = "Sec23",
                    Description = "19inch LED backlit LCD security",
                    SerialNumber = "sd4346568"
                },
                new Asset
                {
                    Id = 3,
                    TagNumber = "c-236a",
                    AssetTypeId = 3,
                    Manufacturer = "Avaya",
                    Model = "9640G",
                    Description = "IP Phone 7000419195",
                    SerialNumber = "F23layth9000"
                }
                );
        }
    }
}

