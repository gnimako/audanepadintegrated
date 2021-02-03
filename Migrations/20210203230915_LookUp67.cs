using Microsoft.EntityFrameworkCore.Migrations;

namespace AUDANEPAD_Integrated.Migrations
{
    public partial class LookUp67 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OutputActivity_Id",
                table: "WP_Procurement",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CommunicationLink",
                table: "WP_OutputActivities",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MobilityLink",
                table: "WP_OutputActivities",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ProcurementLink",
                table: "WP_OutputActivities",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "OutputActivity_Id",
                table: "WP_Mobility",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OutputActivity_Id",
                table: "WP_Communication",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OutputActivity_Id",
                table: "WP_Procurement");

            migrationBuilder.DropColumn(
                name: "CommunicationLink",
                table: "WP_OutputActivities");

            migrationBuilder.DropColumn(
                name: "MobilityLink",
                table: "WP_OutputActivities");

            migrationBuilder.DropColumn(
                name: "ProcurementLink",
                table: "WP_OutputActivities");

            migrationBuilder.DropColumn(
                name: "OutputActivity_Id",
                table: "WP_Mobility");

            migrationBuilder.DropColumn(
                name: "OutputActivity_Id",
                table: "WP_Communication");
        }
    }
}
