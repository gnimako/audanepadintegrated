using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AUDANEPAD_Integrated.Migrations
{
    public partial class LookUp33 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "System_Audit",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(nullable: false),
                    Employee_Id = table.Column<int>(nullable: false),
                    AuditStatement = table.Column<string>(nullable: true),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_System_Audit", x => x.Transaction_Id);
                });

            migrationBuilder.CreateTable(
                name: "WP_ApprovalStatus",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(nullable: false),
                    WPMainRecord_id = table.Column<string>(nullable: true),
                    Project_Id = table.Column<int>(nullable: false),
                    FiscalYear_Id = table.Column<int>(nullable: false),
                    Period_Id = table.Column<int>(nullable: false),
                    Employee_Id = table.Column<int>(nullable: false),
                    WPStatusStatement = table.Column<string>(nullable: true),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WP_ApprovalStatus", x => x.Transaction_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "System_Audit");

            migrationBuilder.DropTable(
                name: "WP_ApprovalStatus");
        }
    }
}
