using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AUDANEPAD_Integrated.Migrations
{
    public partial class LookUp39 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WP_Dispatch");

            migrationBuilder.CreateTable(
                name: "WP_DispatchCycle",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(nullable: false),
                    FiscalYear_Id = table.Column<int>(nullable: false),
                    Period_Id = table.Column<int>(nullable: false),
                    Dispatch_Status = table.Column<bool>(nullable: true),
                    Employee_Id = table.Column<int>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WP_DispatchCycle", x => x.Transaction_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WP_DispatchCycle");

            migrationBuilder.CreateTable(
                name: "WP_Dispatch",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(type: "text", nullable: false),
                    Dispatch_Status = table.Column<bool>(type: "boolean", nullable: true),
                    Employee_Id = table.Column<int>(type: "integer", nullable: false),
                    FiscalYear_Id = table.Column<int>(type: "integer", nullable: false),
                    Period_Id = table.Column<int>(type: "integer", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WP_Dispatch", x => x.Transaction_Id);
                });
        }
    }
}
