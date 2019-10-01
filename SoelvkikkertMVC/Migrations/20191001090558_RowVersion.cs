using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SoelvkikkertMVC.Migrations
{
    public partial class RowVersion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Payment Interval",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Interval = table.Column<TimeSpan>(nullable: false),
                    Discount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment Interval", x => x.ID);
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
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
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
                    SubscribtionStart = table.Column<DateTime>(nullable: false),
                    SubscribtionEnd = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriberProduct", x => new { x.SubscriberID, x.ProductID });
                    table.ForeignKey(
                        name: "FK_SubscriberProduct_Payment Interval_PaymentIntervalID",
                        column: x => x.PaymentIntervalID,
                        principalTable: "Payment Interval",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                name: "Product");

            migrationBuilder.DropTable(
                name: "ProductPaymentInterval");

            migrationBuilder.DropTable(
                name: "SubscriberProduct");

            migrationBuilder.DropTable(
                name: "Subscriber");

            migrationBuilder.DropTable(
                name: "Payment Interval");
        }
    }
}
