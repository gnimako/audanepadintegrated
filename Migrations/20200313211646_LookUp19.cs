using Microsoft.EntityFrameworkCore.Migrations;

namespace AUDANEPAD_Integrated.Migrations
{
    public partial class LookUp19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrimaryDirectorate",
                table: "Struc_DivStaffMapping");

            migrationBuilder.AddColumn<bool>(
                name: "PrimaryDivision",
                table: "Struc_DivStaffMapping",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrimaryDivision",
                table: "Struc_DivStaffMapping");

            migrationBuilder.AddColumn<bool>(
                name: "PrimaryDirectorate",
                table: "Struc_DivStaffMapping",
                type: "boolean",
                nullable: true);
        }
    }
}
