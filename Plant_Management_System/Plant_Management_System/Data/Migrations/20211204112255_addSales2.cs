using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Plant_Management_System.Data.Migrations
{
    public partial class addSales2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SaleEvent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlantForSalePlantId = table.Column<int>(nullable: true),
                    ListPrice = table.Column<double>(nullable: false),
                    Listing = table.Column<int>(nullable: false),
                    DateListed = table.Column<DateTime>(nullable: false),
                    DateSold = table.Column<DateTime>(nullable: false),
                    BuyerId = table.Column<string>(nullable: true),
                    OwnerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleEvent_AspNetUsers_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SaleEvent_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SaleEvent_Plant_PlantForSalePlantId",
                        column: x => x.PlantForSalePlantId,
                        principalTable: "Plant",
                        principalColumn: "PlantId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SaleEvent_BuyerId",
                table: "SaleEvent",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleEvent_OwnerId",
                table: "SaleEvent",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleEvent_PlantForSalePlantId",
                table: "SaleEvent",
                column: "PlantForSalePlantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SaleEvent");
        }
    }
}
