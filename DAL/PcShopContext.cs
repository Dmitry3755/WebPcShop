using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using DAL.Models;

namespace DAL
{
    public partial class PcshopContext : DbContext
    {
        public PcShopContext(DbContextOptions<PcShopContext> options)
             : base(options)
        { }

        public virtual DbSet<InformationAboutSales> InformationAboutSales { get; set; }
        public virtual DbSet<LegalPerson> LegalPerson { get; set; }
        public virtual DbSet<PhysicalPerson> PhysicalPerson { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<InformationAboutSuppliers> InformationAboutSuppliers { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Information_about_sales>()
                .Property(e => e.sales_price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Legal_person>()
                .Property(e => e.Legal_person_TIN)
                .IsUnicode(false);

            modelBuilder.Entity<Legal_person>()
                .Property(e => e.Legal_person_CRS)
                .IsUnicode(false);

            modelBuilder.Entity<Legal_person>()
                .Property(e => e.Legal_person_MSRN)
                .IsUnicode(false);

            modelBuilder.Entity<Legal_person>()
                .HasMany(e => e.Supplier)
                .WithOptional(e => e.Legal_person)
                .HasForeignKey(e => e.legal_person_FK);

            modelBuilder.Entity<Physical_person>()
                .Property(e => e.physical_person_name)
                .IsUnicode(false);

            modelBuilder.Entity<Physical_person>()
                .Property(e => e.physical_person_pasport_number)
                .IsUnicode(false);

            modelBuilder.Entity<Physical_person>()
                .Property(e => e.physical_person_TIN)
                .IsUnicode(false);

            modelBuilder.Entity<Physical_person>()
                .HasMany(e => e.Supplier)
                .WithOptional(e => e.Physical_person)
                .HasForeignKey(e => e.physical_person_FK);

            modelBuilder.Entity<Products>()
                .Property(e => e.product_name)
                .IsUnicode(false);

            modelBuilder.Entity<Products>()
                .Property(e => e.technical_specifications)
                .IsUnicode(false);

            modelBuilder.Entity<Products>()
                .Property(e => e.product_price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Products>()
                .HasMany(e => e.Information_about_sales)
                .WithRequired(e => e.Products)
                .HasForeignKey(e => e.product_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Products>()
                .HasMany(e => e.Information_about_suppliers)
                .WithRequired(e => e.Products)
                .HasForeignKey(e => e.product_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Roles>()
                .Property(e => e.role_name)
                .IsUnicode(false);

            modelBuilder.Entity<Roles>()
                .HasMany(e => e.Users_roles)
                .WithRequired(e => e.Roles)
                .HasForeignKey(e => e.role_id_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.Information_about_suppliers)
                .WithRequired(e => e.Supplier)
                .HasForeignKey(e => e.supplier_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.user_login)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.user_password)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Users_roles)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.user_id_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Сategory>()
                .Property(e => e.category_name)
                .IsUnicode(false);

            modelBuilder.Entity<Сategory>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Сategory)
                .HasForeignKey(e => e.category_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Information_about_suppliers>()
                .Property(e => e.supplies_price)
                .HasPrecision(19, 4);
        }
    }
}
