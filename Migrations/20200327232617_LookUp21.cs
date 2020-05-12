using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AUDANEPAD_Integrated.Migrations
{
    public partial class LookUp21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Struc_DivHead",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Struc_DivHead",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Struc_Director",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Struc_Director",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Struc_DivHead");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Struc_DivHead");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Struc_Director");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Struc_Director");
        }
    }
}
