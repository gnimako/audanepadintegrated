using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AUDANEPAD_Integrated.Migrations
{
    public partial class LookUp41 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WP_OutputActivities",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(nullable: false),
                    WPMainRecord_id = table.Column<string>(nullable: true),
                    WPOutput_Id = table.Column<string>(nullable: true),
                    Project_Id = table.Column<int>(nullable: false),
                    FiscalYear_Id = table.Column<int>(nullable: false),
                    Period_Id = table.Column<int>(nullable: false),
                    ActivityType_Id = table.Column<int>(nullable: false),
                    ActivityDescription = table.Column<string>(nullable: true),
                    ActivityCost = table.Column<double>(nullable: false),
                    ActivityStartDate = table.Column<DateTime>(nullable: false),
                    ActivityEndDate = table.Column<DateTime>(nullable: false),
                    ImplementationType_Id = table.Column<int>(nullable: false),
                    BaselineFinancial = table.Column<double>(nullable: false),
                    BaselineTechnical = table.Column<double>(nullable: false),
                    Employee_Id = table.Column<int>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WP_OutputActivities", x => x.Transaction_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WP_OutputActivities");
        }
    }
}
