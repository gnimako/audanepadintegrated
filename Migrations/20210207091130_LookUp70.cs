using Microsoft.EntityFrameworkCore.Migrations;

namespace AUDANEPAD_Integrated.Migrations
{
    public partial class LookUp70 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WPMainRecord_id",
                table: "WP_ProcurementWorkLoadAssignment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WPMainRecord_id",
                table: "WP_ProcurementProcess",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WPMainRecord_id",
                table: "WP_ProcurementWorkLoadAssignment");

            migrationBuilder.DropColumn(
                name: "WPMainRecord_id",
                table: "WP_ProcurementProcess");
        }
    }
}
