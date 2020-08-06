using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class InitialDbv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adverts_Recourse_RecourseId",
                table: "Adverts");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Recourse_RecourseId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RecourseId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Adverts_RecourseId",
                table: "Adverts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recourse",
                table: "Recourse");

            migrationBuilder.DropColumn(
                name: "RecourseId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RecourseId",
                table: "Adverts");

            migrationBuilder.RenameTable(
                name: "Recourse",
                newName: "Recourses");

            migrationBuilder.AddColumn<int>(
                name: "AdvertId",
                table: "Recourses",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Recourses",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recourses",
                table: "Recourses",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Recourses_AdvertId",
                table: "Recourses",
                column: "AdvertId");

            migrationBuilder.CreateIndex(
                name: "IX_Recourses_UserId",
                table: "Recourses",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recourses_Adverts_AdvertId",
                table: "Recourses",
                column: "AdvertId",
                principalTable: "Adverts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recourses_Users_UserId",
                table: "Recourses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recourses_Adverts_AdvertId",
                table: "Recourses");

            migrationBuilder.DropForeignKey(
                name: "FK_Recourses_Users_UserId",
                table: "Recourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recourses",
                table: "Recourses");

            migrationBuilder.DropIndex(
                name: "IX_Recourses_AdvertId",
                table: "Recourses");

            migrationBuilder.DropIndex(
                name: "IX_Recourses_UserId",
                table: "Recourses");

            migrationBuilder.DropColumn(
                name: "AdvertId",
                table: "Recourses");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Recourses");

            migrationBuilder.RenameTable(
                name: "Recourses",
                newName: "Recourse");

            migrationBuilder.AddColumn<int>(
                name: "RecourseId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecourseId",
                table: "Adverts",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recourse",
                table: "Recourse",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RecourseId",
                table: "Users",
                column: "RecourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Adverts_RecourseId",
                table: "Adverts",
                column: "RecourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adverts_Recourse_RecourseId",
                table: "Adverts",
                column: "RecourseId",
                principalTable: "Recourse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Recourse_RecourseId",
                table: "Users",
                column: "RecourseId",
                principalTable: "Recourse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
