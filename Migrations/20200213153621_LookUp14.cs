using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AUDANEPAD_Integrated.Migrations
{
    public partial class LookUp14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Strategy_KeyPerformanceArea",
                columns: table => new
                {
                    Record_Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StrategicPriority_Id = table.Column<int>(maxLength: 255, nullable: false),
                    Record_Name = table.Column<string>(nullable: true),
                    Record_Status = table.Column<bool>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Strategy_KeyPerformanceArea", x => x.Record_Id);
                });

            migrationBuilder.CreateTable(
                name: "Trans_StrategyKeyPerformanceArea",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(nullable: false),
                    TransStrategicPriority_Id = table.Column<string>(nullable: true),
                    StrategicKeyPerformanceArea_Id = table.Column<int>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trans_StrategyKeyPerformanceArea", x => x.Transaction_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Strategy_KeyPerformanceArea");

            migrationBuilder.DropTable(
                name: "Trans_StrategyKeyPerformanceArea");
        }
    }
}
