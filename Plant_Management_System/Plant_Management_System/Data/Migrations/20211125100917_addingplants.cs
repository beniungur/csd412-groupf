using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Plant_Management_System.Data.Migrations
{
    public partial class addingplants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plant",
                columns: table => new
                {
                    PlantId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    WaterNeeds = table.Column<int>(nullable: false),
                    LightNeeds = table.Column<int>(nullable: false),
                    GrowthMedium = table.Column<int>(nullable: false),
                    PotType = table.Column<int>(nullable: false),
                    Rarity = table.Column<int>(nullable: false),
                    LastRepotted = table.Column<DateTime>(nullable: false),
                    Availability = table.Column<int>(nullable: false),
                    CareLogId = table.Column<int>(nullable: false),
                    OwnerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plant", x => x.PlantId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plant");
        }
    }
}
