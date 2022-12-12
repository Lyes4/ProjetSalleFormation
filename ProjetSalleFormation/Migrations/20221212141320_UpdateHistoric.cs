using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetSalleFormation.Migrations
{
    public partial class UpdateHistoric : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "HistoricTeacher",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "HistoricTeacher");
        }
    }
}
