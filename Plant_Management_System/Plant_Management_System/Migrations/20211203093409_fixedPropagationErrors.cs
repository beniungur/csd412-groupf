using Microsoft.EntityFrameworkCore.Migrations;

namespace Plant_Management_System.Migrations
{
    public partial class fixedPropagationErrors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentPlantId",
                table: "Propagation");

            migrationBuilder.AddColumn<int>(
                name: "ParentPlantPlantId",
                table: "Propagation",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Propagation_ParentPlantPlantId",
                table: "Propagation",
                column: "ParentPlantPlantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Propagation_Plant_ParentPlantPlantId",
                table: "Propagation",
                column: "ParentPlantPlantId",
                principalTable: "Plant",
                principalColumn: "PlantId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Propagation_Plant_ParentPlantPlantId",
                table: "Propagation");

            migrationBuilder.DropIndex(
                name: "IX_Propagation_ParentPlantPlantId",
                table: "Propagation");

            migrationBuilder.DropColumn(
                name: "ParentPlantPlantId",
                table: "Propagation");

            migrationBuilder.AddColumn<int>(
                name: "ParentPlantId",
                table: "Propagation",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
