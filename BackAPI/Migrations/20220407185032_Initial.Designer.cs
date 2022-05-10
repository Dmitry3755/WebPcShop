﻿// <auto-generated />
using System;
using BackAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BackAPI.Migrations
{
    [DbContext(typeof(PcShopContext))]
    [Migration("20220407185032_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BackAPI.Models.Category", b =>
                {
                    b.Property<int>("category_id");

                    b.Property<string>("category_name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("category_id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("BackAPI.Models.InformationAboutSales", b =>
                {
                    b.Property<int>("Information_about_sales_id");

                    b.Property<int>("product_FK");

                    b.Property<int>("sales_count");

                    b.Property<DateTime>("sales_date");

                    b.Property<decimal>("sales_price")
                        .HasColumnType("money");

                    b.HasKey("Information_about_sales_id");

                    b.HasIndex("product_FK");

                    b.ToTable("InformationAboutSales");
                });

            modelBuilder.Entity("BackAPI.Models.InformationAboutSuppliers", b =>
                {
                    b.Property<int>("Information_about_supplie_id");

                    b.Property<int>("product_FK");

                    b.Property<int>("supplier_FK");

                    b.Property<int>("supplies_count");

                    b.Property<DateTime>("supplies_date");

                    b.Property<decimal>("supplies_price")
                        .HasColumnType("money");

                    b.HasKey("Information_about_supplie_id");

                    b.HasIndex("product_FK");

                    b.HasIndex("supplier_FK");

                    b.ToTable("InformationAboutSuppliers");
                });

            modelBuilder.Entity("BackAPI.Models.LegalPerson", b =>
                {
                    b.Property<int>("legal_person_id");

                    b.Property<string>("Legal_person_CRS")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Legal_person_MSRN")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Legal_person_TIN")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("legal_person_id");

                    b.ToTable("LegalPerson");
                });

            modelBuilder.Entity("BackAPI.Models.PhysicalPerson", b =>
                {
                    b.Property<int>("physical_person_id");

                    b.Property<string>("physical_person_TIN")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("physical_person_name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("physical_person_pasport_number")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("physical_person_id");

                    b.ToTable("PhysicalPerson");
                });

            modelBuilder.Entity("BackAPI.Models.Products", b =>
                {
                    b.Property<int>("product_id");

                    b.Property<int>("category_FK");

                    b.Property<int>("count_of_products");

                    b.Property<double?>("discount")
                        .IsRequired();

                    b.Property<string>("product_name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<decimal>("product_price")
                        .HasColumnType("money");

                    b.Property<string>("technical_specifications")
                        .IsRequired()
                        .HasMaxLength(777);

                    b.HasKey("product_id");

                    b.HasIndex("category_FK");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("BackAPI.Models.Roles", b =>
                {
                    b.Property<int>("role_id");

                    b.Property<string>("role_name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("role_id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("BackAPI.Models.Supplier", b =>
                {
                    b.Property<int>("supplier_id");

                    b.Property<int?>("legal_person_FK");

                    b.Property<int?>("physical_person_FK");

                    b.HasKey("supplier_id");

                    b.HasIndex("legal_person_FK");

                    b.HasIndex("physical_person_FK");

                    b.ToTable("Supplier");
                });

            modelBuilder.Entity("BackAPI.Models.User", b =>
                {
                    b.Property<int>("user_id");

                    b.Property<string>("user_login")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("user_password")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("user_id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("BackAPI.Models.UserRole", b =>
                {
                    b.Property<int>("users_roles_id");

                    b.Property<int>("role_id_FK");

                    b.Property<int>("user_id_FK");

                    b.HasKey("users_roles_id");

                    b.HasIndex("role_id_FK");

                    b.HasIndex("user_id_FK");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("BackAPI.Models.InformationAboutSales", b =>
                {
                    b.HasOne("BackAPI.Models.Products", "Products")
                        .WithMany("InformationAboutSales")
                        .HasForeignKey("product_FK")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BackAPI.Models.InformationAboutSuppliers", b =>
                {
                    b.HasOne("BackAPI.Models.Products", "Products")
                        .WithMany("informationAboutSuppliers")
                        .HasForeignKey("product_FK")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BackAPI.Models.Supplier", "Supplier")
                        .WithMany("informationAboutSuppliers")
                        .HasForeignKey("supplier_FK")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BackAPI.Models.Products", b =>
                {
                    b.HasOne("BackAPI.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("category_FK")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BackAPI.Models.Supplier", b =>
                {
                    b.HasOne("BackAPI.Models.LegalPerson", "legalPerson")
                        .WithMany("Supplier")
                        .HasForeignKey("legal_person_FK");

                    b.HasOne("BackAPI.Models.PhysicalPerson", "physicalPerson")
                        .WithMany("Supplier")
                        .HasForeignKey("physical_person_FK");
                });

            modelBuilder.Entity("BackAPI.Models.UserRole", b =>
                {
                    b.HasOne("BackAPI.Models.Roles", "Roles")
                        .WithMany("userRoles")
                        .HasForeignKey("role_id_FK")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BackAPI.Models.User", "User")
                        .WithMany("userRoles")
                        .HasForeignKey("user_id_FK")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}