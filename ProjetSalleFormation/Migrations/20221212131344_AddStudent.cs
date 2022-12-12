using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetSalleFormation.Migrations
{
    public partial class AddStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FormationGroupId",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Paiement",
                table: "User",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectGroupId",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_FormationGroupId",
                table: "User",
                column: "FormationGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_User_ProjectGroupId",
                table: "User",
                column: "ProjectGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_FormationGroup_FormationGroupId",
                table: "User",
                column: "FormationGroupId",
                principalTable: "FormationGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_ProjectGroup_ProjectGroupId",
                table: "User",
                column: "ProjectGroupId",
                principalTable: "ProjectGroup",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_FormationGroup_FormationGroupId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_ProjectGroup_ProjectGroupId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_FormationGroupId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_ProjectGroupId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "FormationGroupId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Paiement",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ProjectGroupId",
                table: "User");
        }
    }
}
