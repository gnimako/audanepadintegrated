using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AUDANEPAD_Integrated.Migrations
{
    public partial class LookUp27 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WP_Dispatch",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(nullable: false),
                    FiscalYear_Id = table.Column<int>(nullable: false),
                    Period_Id = table.Column<int>(nullable: false),
                    Dispatch_Status = table.Column<bool>(nullable: true),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WP_Dispatch", x => x.Transaction_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WP_Dispatch");
        }
    }
}
