using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Plant_Management_System.Data.Migrations
{
    public partial class updateCL2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CareLogEvent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerId = table.Column<string>(nullable: true),
                    PlantNamePlantId = table.Column<int>(nullable: true),
                    CareDone = table.Column<int>(nullable: false),
                    DateOfCare = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CareLogEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CareLogEvent_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CareLogEvent_Plant_PlantNamePlantId",
                        column: x => x.PlantNamePlantId,
                        principalTable: "Plant",
                        principalColumn: "PlantId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CareLogEvent_OwnerId",
                table: "CareLogEvent",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_CareLogEvent_PlantNamePlantId",
                table: "CareLogEvent",
                column: "PlantNamePlantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CareLogEvent");
        }
    }
}
