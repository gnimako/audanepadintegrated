using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AUDANEPAD_Integrated.Migrations
{
    public partial class LookUp52 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LkUp_MobilityLimits",
                columns: table => new
                {
                    Record_Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MonthlyLimit = table.Column<int>(nullable: false),
                    Record_Status = table.Column<bool>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LkUp_MobilityLimits", x => x.Record_Id);
                });

            migrationBuilder.CreateTable(
                name: "Trans_MobilityLimits",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(nullable: false),
                    Record_Id = table.Column<int>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trans_MobilityLimits", x => x.Transaction_Id);
                });

            migrationBuilder.CreateTable(
                name: "WP_Mobility",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(nullable: false),
                    WPMainRecord_id = table.Column<string>(nullable: true),
                    Project_Id = table.Column<int>(nullable: false),
                    FiscalYear_Id = table.Column<int>(nullable: false),
                    Period_Id = table.Column<int>(nullable: false),
                    WPOutput_Id = table.Column<string>(nullable: true),
                    WPOutputActivity_Id = table.Column<string>(nullable: true),
                    WPMobility_Description = table.Column<string>(nullable: true),
                    Country_Id = table.Column<int>(nullable: false),
                    MobilityStartDate = table.Column<DateTime>(nullable: false),
                    MobilityEndDate = table.Column<DateTime>(nullable: false),
                    MobilityCost = table.Column<double>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WP_Mobility", x => x.Transaction_Id);
                });

            migrationBuilder.CreateTable(
                name: "WP_MobilityExternalTeam",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(nullable: false),
                    WPMainRecord_id = table.Column<string>(nullable: true),
                    Project_Id = table.Column<int>(nullable: false),
                    FiscalYear_Id = table.Column<int>(nullable: false),
                    Period_Id = table.Column<int>(nullable: false),
                    WPOutput_Id = table.Column<string>(nullable: true),
                    WPOutputActivity_Id = table.Column<string>(nullable: true),
                    WPMobility_id = table.Column<string>(nullable: true),
                    ExternalParticipant_Id = table.Column<int>(nullable: false),
                    ExternalParticipant_Description = table.Column<string>(nullable: true),
                    ExternalParticipant_Number = table.Column<int>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WP_MobilityExternalTeam", x => x.Transaction_Id);
                });

            migrationBuilder.CreateTable(
                name: "WP_MobilityInternalTeam",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(nullable: false),
                    WPMainRecord_id = table.Column<string>(nullable: true),
                    WPMobility_id = table.Column<string>(nullable: true),
                    Project_Id = table.Column<int>(nullable: false),
                    FiscalYear_Id = table.Column<int>(nullable: false),
                    Period_Id = table.Column<int>(nullable: false),
                    WPOutput_Id = table.Column<string>(nullable: true),
                    WPOutputActivity_Id = table.Column<string>(nullable: true),
                    Employee_Id = table.Column<int>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WP_MobilityInternalTeam", x => x.Transaction_Id);
                });

            migrationBuilder.CreateTable(
                name: "WP_MobilityLimit",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(nullable: false),
                    WPCycle_id = table.Column<string>(nullable: true),
                    Project_Id = table.Column<int>(nullable: false),
                    FiscalYear_Id = table.Column<int>(nullable: false),
                    Period_Id = table.Column<int>(nullable: false),
                    PeriodStartDate = table.Column<DateTime>(nullable: false),
                    PeriodEndDate = table.Column<DateTime>(nullable: false),
                    MonthlyLimit = table.Column<int>(nullable: false),
                    Employee_Id = table.Column<int>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WP_MobilityLimit", x => x.Transaction_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LkUp_MobilityLimits");

            migrationBuilder.DropTable(
                name: "Trans_MobilityLimits");

            migrationBuilder.DropTable(
                name: "WP_Mobility");

            migrationBuilder.DropTable(
                name: "WP_MobilityExternalTeam");

            migrationBuilder.DropTable(
                name: "WP_MobilityInternalTeam");

            migrationBuilder.DropTable(
                name: "WP_MobilityLimit");
        }
    }
}
