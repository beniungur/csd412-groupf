using Microsoft.EntityFrameworkCore.Migrations;

namespace Plant_Management_System.Migrations
{
    public partial class wishlistmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "WishList",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WishList_UserId",
                table: "WishList",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_WishList_AspNetUsers_UserId",
                table: "WishList",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WishList_AspNetUsers_UserId",
                table: "WishList");

            migrationBuilder.DropIndex(
                name: "IX_WishList_UserId",
                table: "WishList");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "WishList");
        }
    }
}
