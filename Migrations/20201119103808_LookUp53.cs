using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AUDANEPAD_Integrated.Migrations
{
    public partial class LookUp53 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PeriodEndDate",
                table: "WP_MobilityInternalTeam",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "PeriodStartDate",
                table: "WP_MobilityInternalTeam",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "PeriodEndDate",
                table: "WP_MobilityExternalTeam",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "PeriodStartDate",
                table: "WP_MobilityExternalTeam",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PeriodEndDate",
                table: "WP_MobilityInternalTeam");

            migrationBuilder.DropColumn(
                name: "PeriodStartDate",
                table: "WP_MobilityInternalTeam");

            migrationBuilder.DropColumn(
                name: "PeriodEndDate",
                table: "WP_MobilityExternalTeam");

            migrationBuilder.DropColumn(
                name: "PeriodStartDate",
                table: "WP_MobilityExternalTeam");
        }
    }
}
