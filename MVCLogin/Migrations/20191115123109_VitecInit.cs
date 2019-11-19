using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCLogin.Migrations
{
    public partial class VitecInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    Administrator = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PaymentInterval",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Interval = table.Column<TimeSpan>(nullable: false),
                    Discount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentInterval", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProductPaymentInterval",
                columns: table => new
                {
                    PaymentIntervalID = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPaymentInterval", x => new { x.PaymentIntervalID, x.ProductID });
                });

            migrationBuilder.CreateTable(
                name: "Subscriber",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriber", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SubscriberProduct",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false),
                    SubscriberID = table.Column<int>(nullable: false),
                    PaymentIntervalID = table.Column<int>(nullable: false),
                    SubscriptionStart = table.Column<DateTime>(nullable: false),
                    SubscriptionEnd = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriberProduct", x => new { x.SubscriberID, x.ProductID });
                    table.ForeignKey(
                        name: "FK_SubscriberProduct_PaymentInterval_PaymentIntervalID",
                        column: x => x.PaymentIntervalID,
                        principalTable: "PaymentInterval",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    SubscriberID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Product_Subscriber_SubscriberID",
                        column: x => x.SubscriberID,
                        principalTable: "Subscriber",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_SubscriberID",
                table: "Product",
                column: "SubscriberID");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriberProduct_PaymentIntervalID",
                table: "SubscriberProduct",
                column: "PaymentIntervalID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "ProductPaymentInterval");

            migrationBuilder.DropTable(
                name: "SubscriberProduct");

            migrationBuilder.DropTable(
                name: "Subscriber");

            migrationBuilder.DropTable(
                name: "PaymentInterval");
        }
    }
}
