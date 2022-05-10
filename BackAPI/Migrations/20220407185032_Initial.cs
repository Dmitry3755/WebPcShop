using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    category_id = table.Column<int>(nullable: false),
                    category_name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.category_id);
                });

            migrationBuilder.CreateTable(
                name: "LegalPerson",
                columns: table => new
                {
                    legal_person_id = table.Column<int>(nullable: false),
                    Legal_person_TIN = table.Column<string>(maxLength: 50, nullable: false),
                    Legal_person_CRS = table.Column<string>(maxLength: 50, nullable: false),
                    Legal_person_MSRN = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalPerson", x => x.legal_person_id);
                });

            migrationBuilder.CreateTable(
                name: "PhysicalPerson",
                columns: table => new
                {
                    physical_person_id = table.Column<int>(nullable: false),
                    physical_person_name = table.Column<string>(maxLength: 100, nullable: false),
                    physical_person_pasport_number = table.Column<string>(maxLength: 50, nullable: false),
                    physical_person_TIN = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicalPerson", x => x.physical_person_id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    role_id = table.Column<int>(nullable: false),
                    role_name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.role_id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    user_id = table.Column<int>(nullable: false),
                    user_login = table.Column<string>(maxLength: 50, nullable: false),
                    user_password = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    product_id = table.Column<int>(nullable: false),
                    product_name = table.Column<string>(maxLength: 50, nullable: false),
                    technical_specifications = table.Column<string>(maxLength: 777, nullable: false),
                    count_of_products = table.Column<int>(nullable: false),
                    product_price = table.Column<decimal>(type: "money", nullable: false),
                    discount = table.Column<double>(nullable: false),
                    category_FK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.product_id);
                    table.ForeignKey(
                        name: "FK_Products_Category_category_FK",
                        column: x => x.category_FK,
                        principalTable: "Category",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    supplier_id = table.Column<int>(nullable: false),
                    physical_person_FK = table.Column<int>(nullable: true),
                    legal_person_FK = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.supplier_id);
                    table.ForeignKey(
                        name: "FK_Supplier_LegalPerson_legal_person_FK",
                        column: x => x.legal_person_FK,
                        principalTable: "LegalPerson",
                        principalColumn: "legal_person_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Supplier_PhysicalPerson_physical_person_FK",
                        column: x => x.physical_person_FK,
                        principalTable: "PhysicalPerson",
                        principalColumn: "physical_person_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    users_roles_id = table.Column<int>(nullable: false),
                    user_id_FK = table.Column<int>(nullable: false),
                    role_id_FK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.users_roles_id);
                    table.ForeignKey(
                        name: "FK_UserRole_Roles_role_id_FK",
                        column: x => x.role_id_FK,
                        principalTable: "Roles",
                        principalColumn: "role_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User_user_id_FK",
                        column: x => x.user_id_FK,
                        principalTable: "User",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InformationAboutSales",
                columns: table => new
                {
                    Information_about_sales_id = table.Column<int>(nullable: false),
                    sales_count = table.Column<int>(nullable: false),
                    sales_price = table.Column<decimal>(type: "money", nullable: false),
                    sales_date = table.Column<DateTime>(nullable: false),
                    product_FK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformationAboutSales", x => x.Information_about_sales_id);
                    table.ForeignKey(
                        name: "FK_InformationAboutSales_Products_product_FK",
                        column: x => x.product_FK,
                        principalTable: "Products",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InformationAboutSuppliers",
                columns: table => new
                {
                    Information_about_supplie_id = table.Column<int>(nullable: false),
                    supplies_count = table.Column<int>(nullable: false),
                    supplies_price = table.Column<decimal>(type: "money", nullable: false),
                    supplies_date = table.Column<DateTime>(nullable: false),
                    supplier_FK = table.Column<int>(nullable: false),
                    product_FK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformationAboutSuppliers", x => x.Information_about_supplie_id);
                    table.ForeignKey(
                        name: "FK_InformationAboutSuppliers_Products_product_FK",
                        column: x => x.product_FK,
                        principalTable: "Products",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InformationAboutSuppliers_Supplier_supplier_FK",
                        column: x => x.supplier_FK,
                        principalTable: "Supplier",
                        principalColumn: "supplier_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InformationAboutSales_product_FK",
                table: "InformationAboutSales",
                column: "product_FK");

            migrationBuilder.CreateIndex(
                name: "IX_InformationAboutSuppliers_product_FK",
                table: "InformationAboutSuppliers",
                column: "product_FK");

            migrationBuilder.CreateIndex(
                name: "IX_InformationAboutSuppliers_supplier_FK",
                table: "InformationAboutSuppliers",
                column: "supplier_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Products_category_FK",
                table: "Products",
                column: "category_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_legal_person_FK",
                table: "Supplier",
                column: "legal_person_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_physical_person_FK",
                table: "Supplier",
                column: "physical_person_FK");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_role_id_FK",
                table: "UserRole",
                column: "role_id_FK");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_user_id_FK",
                table: "UserRole",
                column: "user_id_FK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InformationAboutSales");

            migrationBuilder.DropTable(
                name: "InformationAboutSuppliers");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "LegalPerson");

            migrationBuilder.DropTable(
                name: "PhysicalPerson");
        }
    }
}
