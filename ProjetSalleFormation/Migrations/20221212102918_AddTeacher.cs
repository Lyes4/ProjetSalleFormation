using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetSalleFormation.Migrations
{
    public partial class AddTeacher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DisciplineId",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Resume",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_DisciplineId",
                table: "User",
                column: "DisciplineId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Discipline_DisciplineId",
                table: "User",
                column: "DisciplineId",
                principalTable: "Discipline",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Discipline_DisciplineId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_DisciplineId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "DisciplineId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Resume",
                table: "User");
        }
    }
}
