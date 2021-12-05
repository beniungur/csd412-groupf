using Microsoft.EntityFrameworkCore.Migrations;

namespace Plant_Management_System.Data.Migrations
{
    public partial class updatecont : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plant_AspNetUsers_OwnerIdId",
                table: "Plant");

            migrationBuilder.DropIndex(
                name: "IX_Plant_OwnerIdId",
                table: "Plant");

            migrationBuilder.DropColumn(
                name: "OwnerIdId",
                table: "Plant");

            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Plant",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Plant_OwnerId",
                table: "Plant",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plant_AspNetUsers_OwnerId",
                table: "Plant",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plant_AspNetUsers_OwnerId",
                table: "Plant");

            migrationBuilder.DropIndex(
                name: "IX_Plant_OwnerId",
                table: "Plant");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Plant");

            migrationBuilder.AddColumn<string>(
                name: "OwnerIdId",
                table: "Plant",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Plant_OwnerIdId",
                table: "Plant",
                column: "OwnerIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plant_AspNetUsers_OwnerIdId",
                table: "Plant",
                column: "OwnerIdId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
