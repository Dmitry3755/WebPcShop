using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BackAPI.Models
{
    public class PcShopContext : IdentityDbContext<User>
    {
        public PcShopContext(DbContextOptions<PcShopContext> options) : base(options)
        {}

        public virtual DbSet<InformationAboutSales> InformationAboutSales { get; set; }
        public virtual DbSet<InformationAboutSuppliers> InformationAboutSuppliers { get; set; }
        public virtual DbSet<LegalPerson> LegalPerson { get; set; }
        public virtual DbSet<PhysicalPerson> PhysicalPerson { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<InformationAboutSales>(entity =>
            {
                entity.Property(e => e.sales_count).IsRequired();
                entity.Property(e => e.sales_price).IsRequired();
                entity.Property(e => e.sales_date).IsRequired();
                entity.HasOne(e => e.Products)
                .WithMany(p => p.InformationAboutSales)
                .HasForeignKey(e => e.product_FK);
            });

            modelBuilder.Entity<InformationAboutSuppliers>(entity =>
            {
                entity.Property(e => e.supplies_count).IsRequired();
                entity.Property(e => e.supplies_price).IsRequired();
                entity.Property(e => e.supplies_date).IsRequired();
                entity.HasOne(e => e.Products)
                .WithMany(p => p.InformationAboutSuppliers)
                .HasForeignKey(e => e.product_FK);
                entity.HasOne(e => e.Supplier)
                .WithMany(s => s.InformationAboutSuppliers)
                .HasForeignKey(e => e.supplier_FK);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.category_name).IsRequired();
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.Property(e => e.product_name).IsRequired();
                entity.Property(e => e.technical_specifications).IsRequired();
                entity.Property(e => e.count_of_products).IsRequired();
                entity.Property(e => e.product_price).IsRequired();
                entity.Property(e => e.discount).IsRequired();
                entity.HasOne(e => e.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(e => e.category_FK);
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasOne(e => e.PhysicalPerson)
                .WithMany(p => p.Supplier)
                .HasForeignKey(e => e.physical_person_FK);
                entity.HasOne(e => e.LegalPerson)
                .WithMany(l => l.Supplier)
                .HasForeignKey(e => e.legal_person_FK);
                
            });

            modelBuilder.Entity<LegalPerson>(entity =>
            {
                entity.Property(e => e.Legal_person_TIN).IsRequired();
                entity.Property(e => e.Legal_person_CRS).IsRequired();
                entity.Property(e => e.Legal_person_MSRN).IsRequired();
            });

            modelBuilder.Entity<PhysicalPerson>(entity =>
            {
                entity.Property(e => e.physical_person_name).IsRequired();
                entity.Property(e => e.physical_person_pasport_number).IsRequired();
                entity.Property(e => e.physical_person_TIN).IsRequired();
            });

        }
    }
}
