using Microsoft.EntityFrameworkCore.Migrations;

namespace AUDANEPAD_Integrated.Migrations
{
    public partial class LookUp81 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WPSAP_PO",
                table: "WP_Procurement",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WPSAP_PR",
                table: "WP_Procurement",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WPSAP_WBS",
                table: "WP_Outputs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WPSAP_PO",
                table: "WP_Procurement");

            migrationBuilder.DropColumn(
                name: "WPSAP_PR",
                table: "WP_Procurement");

            migrationBuilder.DropColumn(
                name: "WPSAP_WBS",
                table: "WP_Outputs");
        }
    }
}
