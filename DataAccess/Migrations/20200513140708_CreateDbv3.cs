using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class CreateDbv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecourseId",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecourseId",
                table: "Adverts",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Recourse",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecourseDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recourse", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adverts_Recourse_RecourseId",
                table: "Adverts");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Recourse_RecourseId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Recourse");

            migrationBuilder.DropIndex(
                name: "IX_Users_RecourseId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Adverts_RecourseId",
                table: "Adverts");

            migrationBuilder.DropColumn(
                name: "RecourseId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RecourseId",
                table: "Adverts");
        }
    }
}
