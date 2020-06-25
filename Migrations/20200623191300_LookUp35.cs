using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AUDANEPAD_Integrated.Migrations
{
    public partial class LookUp35 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Strategy_OutputIndicators",
                columns: table => new
                {
                    Record_Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Record_Name = table.Column<string>(nullable: true),
                    Record_Status = table.Column<bool>(nullable: true),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Strategy_OutputIndicators", x => x.Record_Id);
                });

            migrationBuilder.CreateTable(
                name: "Strategy_OutputIndicatorsPriorityMapping",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(nullable: false),
                    OutputIndicator_Id = table.Column<int>(nullable: false),
                    Priority_Id = table.Column<int>(nullable: false),
                    KeyPerformanceArea_Id = table.Column<int>(nullable: false),
                    Record_Status = table.Column<bool>(nullable: true),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Strategy_OutputIndicatorsPriorityMapping", x => x.Transaction_Id);
                });

            migrationBuilder.CreateTable(
                name: "Trans_StrategyOutputIndicators",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(nullable: false),
                    Record_Id = table.Column<int>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trans_StrategyOutputIndicators", x => x.Transaction_Id);
                });

            migrationBuilder.CreateTable(
                name: "WP_CountryScope",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(nullable: false),
                    WPMainRecord_id = table.Column<string>(nullable: true),
                    Project_Id = table.Column<int>(nullable: false),
                    FiscalYear_Id = table.Column<int>(nullable: false),
                    Period_Id = table.Column<int>(nullable: false),
                    Country_Id = table.Column<int>(nullable: false),
                    Employee_Id = table.Column<int>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WP_CountryScope", x => x.Transaction_Id);
                });

            migrationBuilder.CreateTable(
                name: "WP_OutputIndicators",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(nullable: false),
                    WPMainRecord_id = table.Column<string>(nullable: true),
                    Project_Id = table.Column<int>(nullable: false),
                    FiscalYear_Id = table.Column<int>(nullable: false),
                    Period_Id = table.Column<int>(nullable: false),
                    IndicatorCategory = table.Column<string>(nullable: true),
                    IndicatorType = table.Column<string>(nullable: true),
                    OutputIndicator_Id = table.Column<int>(nullable: false),
                    Priority_Id = table.Column<int>(nullable: false),
                    KeyPerformanceArea_Id = table.Column<int>(nullable: false),
                    ProjectBasedIndicatorStatement = table.Column<string>(nullable: true),
                    BaselineQuantitative = table.Column<int>(nullable: false),
                    BaselineQuanlitative = table.Column<string>(nullable: true),
                    TargetQuantitative = table.Column<int>(nullable: false),
                    TargetQuanlitative = table.Column<string>(nullable: true),
                    Employee_Id = table.Column<int>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WP_OutputIndicators", x => x.Transaction_Id);
                });

            migrationBuilder.CreateTable(
                name: "WP_Outputs",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(nullable: false),
                    WPMainRecord_id = table.Column<string>(nullable: true),
                    Project_Id = table.Column<int>(nullable: false),
                    FiscalYear_Id = table.Column<int>(nullable: false),
                    Period_Id = table.Column<int>(nullable: false),
                    Output = table.Column<string>(nullable: true),
                    Employee_Id = table.Column<int>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WP_Outputs", x => x.Transaction_Id);
                });

            migrationBuilder.CreateTable(
                name: "WP_RegionScope",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(nullable: false),
                    WPMainRecord_id = table.Column<string>(nullable: true),
                    Project_Id = table.Column<int>(nullable: false),
                    FiscalYear_Id = table.Column<int>(nullable: false),
                    Period_Id = table.Column<int>(nullable: false),
                    Region_Id = table.Column<int>(nullable: false),
                    Employee_Id = table.Column<int>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WP_RegionScope", x => x.Transaction_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Strategy_OutputIndicators");

            migrationBuilder.DropTable(
                name: "Strategy_OutputIndicatorsPriorityMapping");

            migrationBuilder.DropTable(
                name: "Trans_StrategyOutputIndicators");

            migrationBuilder.DropTable(
                name: "WP_CountryScope");

            migrationBuilder.DropTable(
                name: "WP_OutputIndicators");

            migrationBuilder.DropTable(
                name: "WP_Outputs");

            migrationBuilder.DropTable(
                name: "WP_RegionScope");
        }
    }
}
