using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AUDANEPAD_Integrated.Migrations
{
    public partial class LookUp57 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WP_BarCodeIdents",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(nullable: false),
                    Institutional_Id = table.Column<int>(nullable: false),
                    Directorate_Id = table.Column<int>(nullable: false),
                    Division_Id = table.Column<int>(nullable: false),
                    FiscalYear_Id = table.Column<int>(nullable: false),
                    Period_Id = table.Column<int>(nullable: false),
                    BarCode_Id = table.Column<string>(nullable: true),
                    PeriodStartDate = table.Column<DateTime>(nullable: false),
                    PeriodEndDate = table.Column<DateTime>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WP_BarCodeIdents", x => x.Transaction_Id);
                });

            migrationBuilder.CreateTable(
                name: "WP_Communication",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(nullable: false),
                    WPMainRecord_id = table.Column<string>(nullable: true),
                    Project_Id = table.Column<int>(nullable: false),
                    FiscalYear_Id = table.Column<int>(nullable: false),
                    Period_Id = table.Column<int>(nullable: false),
                    WPOutput_Id = table.Column<string>(nullable: true),
                    WPComms_Description = table.Column<string>(nullable: true),
                    WPCommsChannel_Id = table.Column<int>(nullable: false),
                    WPCommsStartDate = table.Column<DateTime>(nullable: false),
                    WPCommsEndDate = table.Column<DateTime>(nullable: false),
                    WPCommsCost = table.Column<double>(nullable: false),
                    WPComms_AdditionalNotes = table.Column<string>(nullable: true),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WP_Communication", x => x.Transaction_Id);
                });

            migrationBuilder.CreateTable(
                name: "WP_PRCBudgetLimits",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(nullable: false),
                    Institutional_Id = table.Column<int>(nullable: false),
                    Directorate_Id = table.Column<int>(nullable: false),
                    FiscalYear_Id = table.Column<int>(nullable: false),
                    Period_Id = table.Column<int>(nullable: false),
                    PeriodStartDate = table.Column<DateTime>(nullable: false),
                    PeriodEndDate = table.Column<DateTime>(nullable: false),
                    MS_Limit = table.Column<double>(nullable: false),
                    DP_Limit = table.Column<double>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WP_PRCBudgetLimits", x => x.Transaction_Id);
                });

            migrationBuilder.CreateTable(
                name: "WP_Procurement",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(nullable: false),
                    WPMainRecord_id = table.Column<string>(nullable: true),
                    Project_Id = table.Column<int>(nullable: false),
                    FiscalYear_Id = table.Column<int>(nullable: false),
                    Period_Id = table.Column<int>(nullable: false),
                    WPOutput_Id = table.Column<string>(nullable: true),
                    WPProcurement_Description = table.Column<string>(nullable: true),
                    WPProcurementType_Id = table.Column<int>(nullable: false),
                    WPProcurementLeadTime_Id = table.Column<int>(nullable: false),
                    WPProcurementStartDate = table.Column<DateTime>(nullable: false),
                    WPProcurementEndDate = table.Column<DateTime>(nullable: false),
                    WPProcurementCost = table.Column<double>(nullable: false),
                    WPProcurement_AdditionalNotes = table.Column<string>(nullable: true),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WP_Procurement", x => x.Transaction_Id);
                });

            migrationBuilder.CreateTable(
                name: "WP_RiskProfile",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(nullable: false),
                    WPMainRecord_id = table.Column<string>(nullable: true),
                    Project_Id = table.Column<int>(nullable: false),
                    FiscalYear_Id = table.Column<int>(nullable: false),
                    Period_Id = table.Column<int>(nullable: false),
                    WPOutput_Id = table.Column<string>(nullable: true),
                    WPRisk_Description = table.Column<string>(nullable: true),
                    WPRiskImpactLevel_Id = table.Column<int>(nullable: false),
                    WPRiskProbability_Id = table.Column<int>(nullable: false),
                    WPFrequencyOfReporting_Id = table.Column<int>(nullable: false),
                    WPRiskCost = table.Column<double>(nullable: false),
                    WPRisk_AdditionalNotes = table.Column<string>(nullable: true),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WP_RiskProfile", x => x.Transaction_Id);
                });

            migrationBuilder.CreateTable(
                name: "WP_RiskProfileCountries",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(nullable: false),
                    WPMainRecord_id = table.Column<string>(nullable: true),
                    Project_Id = table.Column<int>(nullable: false),
                    FiscalYear_Id = table.Column<int>(nullable: false),
                    Period_Id = table.Column<int>(nullable: false),
                    WPOutput_Id = table.Column<string>(nullable: true),
                    WPRisk_id = table.Column<string>(nullable: true),
                    Country_Id = table.Column<int>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WP_RiskProfileCountries", x => x.Transaction_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WP_BarCodeIdents");

            migrationBuilder.DropTable(
                name: "WP_Communication");

            migrationBuilder.DropTable(
                name: "WP_PRCBudgetLimits");

            migrationBuilder.DropTable(
                name: "WP_Procurement");

            migrationBuilder.DropTable(
                name: "WP_RiskProfile");

            migrationBuilder.DropTable(
                name: "WP_RiskProfileCountries");
        }
    }
}
