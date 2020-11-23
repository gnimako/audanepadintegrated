using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AUDANEPAD_Integrated.Migrations
{
    public partial class LookUp55 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WP_OutcomeIndicators",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(nullable: false),
                    WPMainRecord_id = table.Column<string>(nullable: true),
                    WPOutcome_Id = table.Column<string>(nullable: true),
                    Project_Id = table.Column<int>(nullable: false),
                    FiscalYear_Id = table.Column<int>(nullable: false),
                    Period_Id = table.Column<int>(nullable: false),
                    IndicatorCategory = table.Column<string>(nullable: true),
                    IndicatorType = table.Column<string>(nullable: true),
                    OutcomeIndicator_Id = table.Column<int>(nullable: false),
                    Priority_Id = table.Column<int>(nullable: false),
                    KeyPerformanceArea_Id = table.Column<int>(nullable: false),
                    ProjectBasedIndicatorStatement = table.Column<string>(nullable: true),
                    BaselineQuantitative = table.Column<double>(nullable: false),
                    BaselineQuanlitative = table.Column<string>(nullable: true),
                    TargetQuantitative = table.Column<double>(nullable: false),
                    TargetQuanlitative = table.Column<string>(nullable: true),
                    Employee_Id = table.Column<int>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WP_OutcomeIndicators", x => x.Transaction_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WP_OutcomeIndicators");
        }
    }
}
