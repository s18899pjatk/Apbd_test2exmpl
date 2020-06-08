using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace test2exmpl.Migrations
{
    public partial class AddTableAndSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Confectionery",
                columns: table => new
                {
                    IdConfectionery = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    PricePerItem = table.Column<float>(nullable: false),
                    Type = table.Column<string>(maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Confectionery", x => x.IdConfectionery);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    IdClient = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Surname = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.IdClient);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    idEmployee = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Surname = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.idEmployee);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    idOrder = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataAccepted = table.Column<DateTime>(nullable: false),
                    DataFinished = table.Column<DateTime>(nullable: true),
                    Notes = table.Column<string>(maxLength: 255, nullable: false),
                    idClient = table.Column<int>(nullable: false),
                    idEmployee = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.idOrder);
                    table.ForeignKey(
                        name: "FK_Order_Customer_idClient",
                        column: x => x.idClient,
                        principalTable: "Customer",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Employee_idEmployee",
                        column: x => x.idEmployee,
                        principalTable: "Employee",
                        principalColumn: "idEmployee",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Confectionery_Order",
                columns: table => new
                {
                    IdConfection = table.Column<int>(nullable: false),
                    IdOrder = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Confectionery_Order", x => new { x.IdConfection, x.IdOrder });
                    table.ForeignKey(
                        name: "FK_Confectionery_Order_Confectionery_IdConfection",
                        column: x => x.IdConfection,
                        principalTable: "Confectionery",
                        principalColumn: "IdConfectionery",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Confectionery_Order_Order_IdOrder",
                        column: x => x.IdOrder,
                        principalTable: "Order",
                        principalColumn: "idOrder",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Confectionery",
                columns: new[] { "IdConfectionery", "Name", "PricePerItem", "Type" },
                values: new object[,]
                {
                    { 1, "Pink Unicorn", 3.5f, "Donut" },
                    { 2, "Corona", 4.3f, "Chockolate" },
                    { 3, "Napoleon", 8.2f, "Cake" }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "IdClient", "Name", "Surname" },
                values: new object[,]
                {
                    { 1, "Bobby", "Jack" },
                    { 2, "Jack", "Joe" },
                    { 3, "Rogan", "Paul" }
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "idEmployee", "Name", "Surname" },
                values: new object[,]
                {
                    { 1, "Jonny", "James" },
                    { 2, "Bukky", "Brown" },
                    { 3, "Adam", "James" },
                    { 4, "Sonny", "Ludvic" }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "idOrder", "DataAccepted", "DataFinished", "Notes", "idClient", "idEmployee" },
                values: new object[] { 1, new DateTime(2020, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Donuts please..", 1, 2 });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "idOrder", "DataAccepted", "DataFinished", "Notes", "idClient", "idEmployee" },
                values: new object[] { 3, new DateTime(2020, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Data..", 1, 2 });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "idOrder", "DataAccepted", "DataFinished", "Notes", "idClient", "idEmployee" },
                values: new object[] { 2, new DateTime(2020, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ffwww..", 2, 3 });

            migrationBuilder.InsertData(
                table: "Confectionery_Order",
                columns: new[] { "IdConfection", "IdOrder", "Notes", "Quantity" },
                values: new object[] { 2, 1, "blablabla...", 1 });

            migrationBuilder.InsertData(
                table: "Confectionery_Order",
                columns: new[] { "IdConfection", "IdOrder", "Notes", "Quantity" },
                values: new object[] { 1, 3, "blablabla...", 2 });

            migrationBuilder.InsertData(
                table: "Confectionery_Order",
                columns: new[] { "IdConfection", "IdOrder", "Notes", "Quantity" },
                values: new object[] { 3, 2, "blablabla...", 4 });

            migrationBuilder.CreateIndex(
                name: "IX_Confectionery_Order_IdOrder",
                table: "Confectionery_Order",
                column: "IdOrder");

            migrationBuilder.CreateIndex(
                name: "IX_Order_idClient",
                table: "Order",
                column: "idClient");

            migrationBuilder.CreateIndex(
                name: "IX_Order_idEmployee",
                table: "Order",
                column: "idEmployee");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Confectionery_Order");

            migrationBuilder.DropTable(
                name: "Confectionery");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
