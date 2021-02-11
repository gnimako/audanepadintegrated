using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AUDANEPAD_Integrated.Migrations
{
    public partial class LookUp75 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WPDirectorate_Id",
                table: "WP_Tasks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WPDivision_Id",
                table: "WP_Tasks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "WP_ProcurementProcessSteps",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(nullable: false),
                    WPMainRecord_id = table.Column<string>(nullable: true),
                    WPProcurement_Id = table.Column<string>(nullable: true),
                    Employee_Id = table.Column<int>(nullable: false),
                    WPStepNumber = table.Column<int>(nullable: false),
                    WPStepType_Id = table.Column<int>(nullable: false),
                    WPPlannedDate = table.Column<DateTime>(nullable: false),
                    WPActualDate = table.Column<DateTime>(nullable: false),
                    WPNotes = table.Column<string>(nullable: true),
                    WPStep_Status = table.Column<string>(nullable: true),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WP_ProcurementProcessSteps", x => x.Transaction_Id);
                });

            migrationBuilder.CreateTable(
                name: "WP_ProcurementTORDocs",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(nullable: false),
                    WPMainRecord_id = table.Column<string>(nullable: true),
                    WPProcurement_Id = table.Column<string>(nullable: true),
                    Employee_Id = table.Column<int>(nullable: false),
                    WPDocDesciptionTitle = table.Column<string>(maxLength: 300, nullable: false),
                    WPDocPath = table.Column<string>(nullable: true),
                    WPDoc_Status = table.Column<string>(nullable: true),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WP_ProcurementTORDocs", x => x.Transaction_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WP_ProcurementProcessSteps");

            migrationBuilder.DropTable(
                name: "WP_ProcurementTORDocs");

            migrationBuilder.DropColumn(
                name: "WPDirectorate_Id",
                table: "WP_Tasks");

            migrationBuilder.DropColumn(
                name: "WPDivision_Id",
                table: "WP_Tasks");
        }
    }
}
