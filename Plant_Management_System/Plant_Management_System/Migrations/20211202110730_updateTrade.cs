using Microsoft.EntityFrameworkCore.Migrations;

namespace Plant_Management_System.Migrations
{
    public partial class updateTrade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Trade");

            migrationBuilder.DropColumn(
                name: "PlantId",
                table: "Trade");

            migrationBuilder.AddColumn<int>(
                name: "TradePlantPlantId",
                table: "Trade",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TradeToUserId",
                table: "Trade",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trade_TradePlantPlantId",
                table: "Trade",
                column: "TradePlantPlantId");

            migrationBuilder.CreateIndex(
                name: "IX_Trade_TradeToUserId",
                table: "Trade",
                column: "TradeToUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trade_Plant_TradePlantPlantId",
                table: "Trade",
                column: "TradePlantPlantId",
                principalTable: "Plant",
                principalColumn: "PlantId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trade_User_TradeToUserId",
                table: "Trade",
                column: "TradeToUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trade_Plant_TradePlantPlantId",
                table: "Trade");

            migrationBuilder.DropForeignKey(
                name: "FK_Trade_User_TradeToUserId",
                table: "Trade");

            migrationBuilder.DropIndex(
                name: "IX_Trade_TradePlantPlantId",
                table: "Trade");

            migrationBuilder.DropIndex(
                name: "IX_Trade_TradeToUserId",
                table: "Trade");

            migrationBuilder.DropColumn(
                name: "TradePlantPlantId",
                table: "Trade");

            migrationBuilder.DropColumn(
                name: "TradeToUserId",
                table: "Trade");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Trade",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlantId",
                table: "Trade",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
