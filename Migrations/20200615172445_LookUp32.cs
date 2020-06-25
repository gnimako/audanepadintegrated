using Microsoft.EntityFrameworkCore.Migrations;

namespace AUDANEPAD_Integrated.Migrations
{
    public partial class LookUp32 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FiscalYear_Id",
                table: "WP_MTP",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Period_Id",
                table: "WP_MTP",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Project_Id",
                table: "WP_MTP",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FiscalYear_Id",
                table: "WP_MTP");

            migrationBuilder.DropColumn(
                name: "Period_Id",
                table: "WP_MTP");

            migrationBuilder.DropColumn(
                name: "Project_Id",
                table: "WP_MTP");
        }
    }
}
