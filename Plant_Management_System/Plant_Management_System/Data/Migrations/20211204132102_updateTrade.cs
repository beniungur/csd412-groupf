using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Plant_Management_System.Data.Migrations
{
    public partial class updateTrade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TradeEvent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerId = table.Column<string>(nullable: true),
                    PlantToTradePlantId = table.Column<int>(nullable: true),
                    TradeToId = table.Column<string>(nullable: true),
                    PlantToReceivePlantId = table.Column<int>(nullable: true),
                    TradeDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradeEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TradeEvent_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TradeEvent_Plant_PlantToReceivePlantId",
                        column: x => x.PlantToReceivePlantId,
                        principalTable: "Plant",
                        principalColumn: "PlantId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TradeEvent_Plant_PlantToTradePlantId",
                        column: x => x.PlantToTradePlantId,
                        principalTable: "Plant",
                        principalColumn: "PlantId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TradeEvent_AspNetUsers_TradeToId",
                        column: x => x.TradeToId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TradeEvent_OwnerId",
                table: "TradeEvent",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_TradeEvent_PlantToReceivePlantId",
                table: "TradeEvent",
                column: "PlantToReceivePlantId");

            migrationBuilder.CreateIndex(
                name: "IX_TradeEvent_PlantToTradePlantId",
                table: "TradeEvent",
                column: "PlantToTradePlantId");

            migrationBuilder.CreateIndex(
                name: "IX_TradeEvent_TradeToId",
                table: "TradeEvent",
                column: "TradeToId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TradeEvent");
        }
    }
}
