using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using FlowardEntities.Catalog.Models;

namespace FlowardEntities.Catalog.DBContexts
{
    public partial class CatalogContext : DbContext
    {
        public CatalogContext()
        {
        }

        public CatalogContext(DbContextOptions<CatalogContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Cost).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Image).HasColumnType("image");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            });

            //Seeding sample data if no exist
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Product1",
                    Price = 10.2M,
                    Cost = 8.3M
                },
                new Product
                {
                    Id = 2,
                    Name = "Product2",
                    Price = 20.2M,
                    Cost = 18.3M
                },
                new Product
                {
                    Id = 3,
                    Name = "Product3",
                    Price = 30.2M,
                    Cost = 28.3M
                }
            );

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
