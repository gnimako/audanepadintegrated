using Microsoft.EntityFrameworkCore.Migrations;

namespace AUDANEPAD_Integrated.Migrations
{
    public partial class LookUp64 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WPRiskChampion_Id",
                table: "WP_RiskProfile",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WPRiskOwner_Id",
                table: "WP_RiskProfile",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "WPRisk_MitigationMeasures",
                table: "WP_RiskProfile",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WPRiskChampion_Id",
                table: "WP_RiskProfile");

            migrationBuilder.DropColumn(
                name: "WPRiskOwner_Id",
                table: "WP_RiskProfile");

            migrationBuilder.DropColumn(
                name: "WPRisk_MitigationMeasures",
                table: "WP_RiskProfile");
        }
    }
}
