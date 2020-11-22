using Microsoft.EntityFrameworkCore.Migrations;

namespace AUDANEPAD_Integrated.Migrations
{
    public partial class LookUp54 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PartnerFunding",
                table: "WP_OutputActivities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PartnerFundingDescr",
                table: "WP_OutputActivities",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PartnerFunding",
                table: "WP_OutputActivities");

            migrationBuilder.DropColumn(
                name: "PartnerFundingDescr",
                table: "WP_OutputActivities");
        }
    }
}
