using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AUDANEPAD_Integrated.Migrations
{
    public partial class LookUp30 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WP_AUDAPriority",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(nullable: false),
                    WPMainRecord_id = table.Column<string>(nullable: true),
                    MTP_Id = table.Column<int>(nullable: false),
                    Priority_Id = table.Column<int>(nullable: false),
                    Employee_Id = table.Column<int>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WP_AUDAPriority", x => x.Transaction_Id);
                });

            migrationBuilder.CreateTable(
                name: "WP_MainRecord",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(nullable: false),
                    Directorate_Id = table.Column<int>(nullable: false),
                    Division_Id = table.Column<int>(nullable: false),
                    Programme_Id = table.Column<int>(nullable: false),
                    Project_Id = table.Column<int>(nullable: false),
                    FiscalYear_Id = table.Column<int>(nullable: false),
                    Period_Id = table.Column<int>(nullable: false),
                    WP_Status = table.Column<string>(nullable: true),
                    WP_ApprovalStatus = table.Column<string>(nullable: true),
                    Employee_Id = table.Column<int>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WP_MainRecord", x => x.Transaction_Id);
                });

            migrationBuilder.CreateTable(
                name: "WP_MTP",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(nullable: false),
                    WPMainRecord_id = table.Column<string>(nullable: true),
                    MTP_Id = table.Column<int>(nullable: false),
                    Employee_Id = table.Column<int>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WP_MTP", x => x.Transaction_Id);
                });

            migrationBuilder.CreateTable(
                name: "WP_Outcomes",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(nullable: false),
                    WPMainRecord_id = table.Column<string>(nullable: true),
                    Outcome = table.Column<string>(nullable: true),
                    Employee_Id = table.Column<int>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WP_Outcomes", x => x.Transaction_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WP_AUDAPriority");

            migrationBuilder.DropTable(
                name: "WP_MainRecord");

            migrationBuilder.DropTable(
                name: "WP_MTP");

            migrationBuilder.DropTable(
                name: "WP_Outcomes");
        }
    }
}
