using Microsoft.EntityFrameworkCore.Migrations;

namespace AUDANEPAD_Integrated.Migrations
{
    public partial class LookUp31 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FiscalYear_Id",
                table: "WP_Outcomes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Period_Id",
                table: "WP_Outcomes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Project_Id",
                table: "WP_Outcomes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FiscalYear_Id",
                table: "WP_AUDAPriority",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Period_Id",
                table: "WP_AUDAPriority",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Project_Id",
                table: "WP_AUDAPriority",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FiscalYear_Id",
                table: "WP_Outcomes");

            migrationBuilder.DropColumn(
                name: "Period_Id",
                table: "WP_Outcomes");

            migrationBuilder.DropColumn(
                name: "Project_Id",
                table: "WP_Outcomes");

            migrationBuilder.DropColumn(
                name: "FiscalYear_Id",
                table: "WP_AUDAPriority");

            migrationBuilder.DropColumn(
                name: "Period_Id",
                table: "WP_AUDAPriority");

            migrationBuilder.DropColumn(
                name: "Project_Id",
                table: "WP_AUDAPriority");
        }
    }
}
