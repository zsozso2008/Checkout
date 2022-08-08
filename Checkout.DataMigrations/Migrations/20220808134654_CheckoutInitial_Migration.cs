using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Checkout.DataMigrations.Migrations
{
    public partial class CheckoutInitial_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Baschet",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Customer = table.Column<string>(nullable: true),
                    PaysVAT = table.Column<bool>(nullable: false),
                    TotalNet = table.Column<double>(nullable: false),
                    TotalGross = table.Column<double>(nullable: false),
                    Closed = table.Column<bool>(nullable: false),
                    Payed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baschet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Item = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    BasketId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Article_Baschet_BasketId",
                        column: x => x.BasketId,
                        principalTable: "Baschet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Article_BasketId",
                table: "Article",
                column: "BasketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Article");

            migrationBuilder.DropTable(
                name: "Baschet");
        }
    }
}
