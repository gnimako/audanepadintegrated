using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AUDANEPAD_Integrated.Migrations
{
    public partial class LookUp29 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Strategy_MTP",
                columns: table => new
                {
                    Record_Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Record_Name = table.Column<string>(maxLength: 255, nullable: false),
                    Record_Status = table.Column<bool>(nullable: true),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Strategy_MTP", x => x.Record_Id);
                });

            migrationBuilder.CreateTable(
                name: "Strategy_MTPPriorityMapping",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(nullable: false),
                    MTP_Id = table.Column<int>(nullable: false),
                    Priority_Id = table.Column<int>(nullable: false),
                    Record_Status = table.Column<bool>(nullable: true),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Strategy_MTPPriorityMapping", x => x.Transaction_Id);
                });

            migrationBuilder.CreateTable(
                name: "Trans_StrategyMTP",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(nullable: false),
                    Record_Id = table.Column<int>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trans_StrategyMTP", x => x.Transaction_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Strategy_MTP");

            migrationBuilder.DropTable(
                name: "Strategy_MTPPriorityMapping");

            migrationBuilder.DropTable(
                name: "Trans_StrategyMTP");
        }
    }
}
