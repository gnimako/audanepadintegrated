using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AUDANEPAD_Integrated.Migrations
{
    public partial class LookUp62 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "WPContractStartDate",
                table: "WP_Procurement",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "WPProcurement_SourceOfFundsDescr",
                table: "WP_Procurement",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "WPTORSubmissionDate",
                table: "WP_Procurement",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WPContractStartDate",
                table: "WP_Procurement");

            migrationBuilder.DropColumn(
                name: "WPProcurement_SourceOfFundsDescr",
                table: "WP_Procurement");

            migrationBuilder.DropColumn(
                name: "WPTORSubmissionDate",
                table: "WP_Procurement");
        }
    }
}
