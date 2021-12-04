using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Plant_Management_System.Data.Migrations
{
    public partial class addplntproevent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: true);

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
                    Availability = table.Column<int>(nullable: false),
                    LastRepotted = table.Column<DateTime>(nullable: false),
                    CareLogId = table.Column<int>(nullable: false),
                    OwnerIdId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plant", x => x.PlantId);
                    table.ForeignKey(
                        name: "FK_Plant_AspNetUsers_OwnerIdId",
                        column: x => x.OwnerIdId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PropagationEvent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerId = table.Column<string>(nullable: true),
                    ParentPlantPlantId = table.Column<int>(nullable: true),
                    PropDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropagationEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropagationEvent_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PropagationEvent_Plant_ParentPlantPlantId",
                        column: x => x.ParentPlantPlantId,
                        principalTable: "Plant",
                        principalColumn: "PlantId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plant_OwnerIdId",
                table: "Plant",
                column: "OwnerIdId");

            migrationBuilder.CreateIndex(
                name: "IX_PropagationEvent_OwnerId",
                table: "PropagationEvent",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_PropagationEvent_ParentPlantPlantId",
                table: "PropagationEvent",
                column: "ParentPlantPlantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropagationEvent");

            migrationBuilder.DropTable(
                name: "Plant");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");
        }
    }
}
