using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AUDANEPAD_Integrated.Migrations
{
    public partial class LookUp9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LkUp_ProcurementType",
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
                    table.PrimaryKey("PK_LkUp_ProcurementType", x => x.Record_Id);
                });

            migrationBuilder.CreateTable(
                name: "LkUp_RiskCategory",
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
                    table.PrimaryKey("PK_LkUp_RiskCategory", x => x.Record_Id);
                });

            migrationBuilder.CreateTable(
                name: "LkUp_RiskImpact",
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
                    table.PrimaryKey("PK_LkUp_RiskImpact", x => x.Record_Id);
                });

            migrationBuilder.CreateTable(
                name: "LkUp_RiskProbability",
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
                    table.PrimaryKey("PK_LkUp_RiskProbability", x => x.Record_Id);
                });

            migrationBuilder.CreateTable(
                name: "LkUp_RiskRTimeframe",
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
                    table.PrimaryKey("PK_LkUp_RiskRTimeframe", x => x.Record_Id);
                });

            migrationBuilder.CreateTable(
                name: "Trans_ProcurementType",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(nullable: false),
                    Record_Id = table.Column<int>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trans_ProcurementType", x => x.Transaction_Id);
                });

            migrationBuilder.CreateTable(
                name: "Trans_RiskCategory",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(nullable: false),
                    Record_Id = table.Column<int>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trans_RiskCategory", x => x.Transaction_Id);
                });

            migrationBuilder.CreateTable(
                name: "Trans_RiskImpact",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(nullable: false),
                    Record_Id = table.Column<int>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trans_RiskImpact", x => x.Transaction_Id);
                });

            migrationBuilder.CreateTable(
                name: "Trans_RiskProbability",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(nullable: false),
                    Record_Id = table.Column<int>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trans_RiskProbability", x => x.Transaction_Id);
                });

            migrationBuilder.CreateTable(
                name: "Trans_RiskRTimeframe",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(nullable: false),
                    Record_Id = table.Column<int>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trans_RiskRTimeframe", x => x.Transaction_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LkUp_ProcurementType");

            migrationBuilder.DropTable(
                name: "LkUp_RiskCategory");

            migrationBuilder.DropTable(
                name: "LkUp_RiskImpact");

            migrationBuilder.DropTable(
                name: "LkUp_RiskProbability");

            migrationBuilder.DropTable(
                name: "LkUp_RiskRTimeframe");

            migrationBuilder.DropTable(
                name: "Trans_ProcurementType");

            migrationBuilder.DropTable(
                name: "Trans_RiskCategory");

            migrationBuilder.DropTable(
                name: "Trans_RiskImpact");

            migrationBuilder.DropTable(
                name: "Trans_RiskProbability");

            migrationBuilder.DropTable(
                name: "Trans_RiskRTimeframe");
        }
    }
}
