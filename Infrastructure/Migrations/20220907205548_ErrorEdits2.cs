using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class ErrorEdits2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_Genres_UsersId",
                table: "Favorites");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Genres_UsersId",
                table: "Purchases");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Genres_UsersId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Genres_UsersId",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_UsersId1",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_UserRoles_UsersId1",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "UsersId1",
                table: "UserRoles");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_Users_UsersId",
                table: "Favorites",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Users_UsersId",
                table: "Purchases",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Users_UsersId",
                table: "Reviews",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_UsersId",
                table: "UserRoles",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_Users_UsersId",
                table: "Favorites");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Users_UsersId",
                table: "Purchases");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Users_UsersId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_UsersId",
                table: "UserRoles");

            migrationBuilder.AddColumn<int>(
                name: "UsersId1",
                table: "UserRoles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UsersId1",
                table: "UserRoles",
                column: "UsersId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_Genres_UsersId",
                table: "Favorites",
                column: "UsersId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Genres_UsersId",
                table: "Purchases",
                column: "UsersId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Genres_UsersId",
                table: "Reviews",
                column: "UsersId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Genres_UsersId",
                table: "UserRoles",
                column: "UsersId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_UsersId1",
                table: "UserRoles",
                column: "UsersId1",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
