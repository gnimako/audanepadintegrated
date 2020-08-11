using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AUDANEPAD_Integrated.Migrations
{
    public partial class LookUp40 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "LinkToSAPExecution",
                table: "WP_MainRecord",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "LinkToSAPExecution",
                table: "WP_DispatchCycle",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LkUp_IndicatorType",
                columns: table => new
                {
                    Record_Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Record_Name = table.Column<string>(maxLength: 255, nullable: false),
                    Record_Status = table.Column<bool>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LkUp_IndicatorType", x => x.Record_Id);
                });

            migrationBuilder.CreateTable(
                name: "Trans_IndicatorType",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(nullable: false),
                    Record_Id = table.Column<int>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trans_IndicatorType", x => x.Transaction_Id);
                });

            migrationBuilder.CreateTable(
                name: "WP_OutputBudget",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(nullable: false),
                    WPMainRecord_id = table.Column<string>(nullable: true),
                    Project_Id = table.Column<int>(nullable: false),
                    FiscalYear_Id = table.Column<int>(nullable: false),
                    Period_Id = table.Column<int>(nullable: false),
                    WPOutput_Id = table.Column<string>(nullable: true),
                    Output_BudgetAmount = table.Column<double>(nullable: false),
                    WPSAPLink_Id = table.Column<string>(nullable: true),
                    UtilizationPercentage = table.Column<double>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WP_OutputBudget", x => x.Transaction_Id);
                });

            migrationBuilder.CreateTable(
                name: "WP_SAPLink",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(nullable: false),
                    WPDispatchCycle_Id = table.Column<string>(nullable: true),
                    Directorate_Id = table.Column<int>(nullable: false),
                    SAP_WBS = table.Column<string>(nullable: true),
                    SAP_Description = table.Column<string>(nullable: true),
                    SAP_BudgetAmount = table.Column<double>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WP_SAPLink", x => x.Transaction_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LkUp_IndicatorType");

            migrationBuilder.DropTable(
                name: "Trans_IndicatorType");

            migrationBuilder.DropTable(
                name: "WP_OutputBudget");

            migrationBuilder.DropTable(
                name: "WP_SAPLink");

            migrationBuilder.DropColumn(
                name: "LinkToSAPExecution",
                table: "WP_MainRecord");

            migrationBuilder.DropColumn(
                name: "LinkToSAPExecution",
                table: "WP_DispatchCycle");
        }
    }
}
