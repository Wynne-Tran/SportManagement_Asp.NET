using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment1.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductsId);
                });

            migrationBuilder.CreateTable(
                name: "Technicians",
                columns: table => new
                {
                    TechniciansId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technicians", x => x.TechniciansId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomersId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomersId);
                    table.ForeignKey(
                        name: "FK_Customers_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Incidents",
                columns: table => new
                {
                    IncidentsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateClosed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomersId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false),
                    TechniciansId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidents", x => x.IncidentsId);
                    table.ForeignKey(
                        name: "FK_Incidents_Customers_CustomersId",
                        column: x => x.CustomersId,
                        principalTable: "Customers",
                        principalColumn: "CustomersId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidents_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "ProductsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidents_Technicians_TechniciansId",
                        column: x => x.TechniciansId,
                        principalTable: "Technicians",
                        principalColumn: "TechniciansId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Registrations",
                columns: table => new
                {
                    RegistrationsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomersId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registrations", x => x.RegistrationsId);
                    table.ForeignKey(
                        name: "FK_Registrations_Customers_CustomersId",
                        column: x => x.CustomersId,
                        principalTable: "Customers",
                        principalColumn: "CustomersId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registrations_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "ProductsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "CountryId", "CountryName" },
                values: new object[,]
                {
                    { 1, "Canada" },
                    { 2, "USA" },
                    { 3, "Uk" },
                    { 4, "China" },
                    { 5, "Japan" },
                    { 6, "France" },
                    { 7, "Italia" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductsId", "Code", "PName", "Price", "Rdate" },
                values: new object[,]
                {
                    { 1, "LEAG10", "League Scheduler 1.0", 4.99m, new DateTime(2021, 4, 9, 13, 53, 36, 269, DateTimeKind.Local).AddTicks(2240) },
                    { 2, "LEAGD10", "League Scheduler Deluxe 1.0", 7.99m, new DateTime(2021, 4, 9, 13, 53, 36, 270, DateTimeKind.Local).AddTicks(6916) },
                    { 3, "DRAFT10", "Draft Manager 10", 4.99m, new DateTime(2021, 4, 9, 13, 53, 36, 270, DateTimeKind.Local).AddTicks(7024) }
                });

            migrationBuilder.InsertData(
                table: "Technicians",
                columns: new[] { "TechniciansId", "Email", "Phone", "TName" },
                values: new object[,]
                {
                    { 1, "thihoangtram.tran@georgebrown.ca", "(041) 672-6767", "Wynne Tran" },
                    { 2, "kiani.forough@georgebrown.ca", "(041) 672-6868", "Forough Kiani" },
                    { 3, "matias.herter@georgebrown.ca", "(041) 672-8888", "Matias Herter" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomersId", "Address", "City", "CountryId", "Email", "FirstName", "LastName", "PhoneNumber", "PostalCode", "State" },
                values: new object[] { 1, "200 King", "Toronto", 1, "thihoangtram.tran@georgebrown.ca", "Kaitlyn", "Anthoni", "4167221285", "M6J 0B3", "Ontario" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomersId", "Address", "City", "CountryId", "Email", "FirstName", "LastName", "PhoneNumber", "PostalCode", "State" },
                values: new object[] { 2, "286 King", "Atlanta", 3, "", "Ania ", "Irvin", "4167221285", "M6J 111", "Quesbec" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomersId", "Address", "City", "CountryId", "Email", "FirstName", "LastName", "PhoneNumber", "PostalCode", "State" },
                values: new object[] { 3, "286 Richmond Hill", "Kingdom", 5, "abc@gmail.com", "Kendall ", "Maya", "4167123456", "M3r 7Y6", "Ottawa" });

            migrationBuilder.InsertData(
                table: "Incidents",
                columns: new[] { "IncidentsId", "CustomersId", "DateAdded", "DateClosed", "Description", "ProductsId", "TechniciansId", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 4, 9, 13, 53, 36, 272, DateTimeKind.Local).AddTicks(498), new DateTime(2021, 4, 9, 13, 53, 36, 272, DateTimeKind.Local).AddTicks(979), "Got 100 for this assignment", 1, 1, "Congratulation !" },
                    { 2, 2, new DateTime(2021, 4, 9, 13, 53, 36, 272, DateTimeKind.Local).AddTicks(2343), null, "Some errors happen !", 2, 2, "Could not install" },
                    { 3, 3, new DateTime(2021, 4, 9, 13, 53, 36, 272, DateTimeKind.Local).AddTicks(2372), null, "Some errors happen !", 3, null, "Could not install" }
                });

            migrationBuilder.InsertData(
                table: "Registrations",
                columns: new[] { "RegistrationsId", "CustomersId", "ProductsId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CountryId",
                table: "Customers",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_CustomersId",
                table: "Incidents",
                column: "CustomersId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_ProductsId",
                table: "Incidents",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_TechniciansId",
                table: "Incidents",
                column: "TechniciansId");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_CustomersId",
                table: "Registrations",
                column: "CustomersId");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_ProductsId",
                table: "Registrations",
                column: "ProductsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Incidents");

            migrationBuilder.DropTable(
                name: "Registrations");

            migrationBuilder.DropTable(
                name: "Technicians");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
