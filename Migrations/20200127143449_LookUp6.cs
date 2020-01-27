using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AUDANEPAD_Integrated.Migrations
{
    public partial class LookUp6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trans_CostCatelogue",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(nullable: false),
                    Cost_Id = table.Column<int>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trans_CostCatelogue", x => x.Transaction_Id);
                });

            migrationBuilder.CreateTable(
                name: "Trans_DSAType",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(nullable: false),
                    DSA_Id = table.Column<int>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trans_DSAType", x => x.Transaction_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trans_CostCatelogue");

            migrationBuilder.DropTable(
                name: "Trans_DSAType");
        }
    }
}
