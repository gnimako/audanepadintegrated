using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AUDANEPAD_Integrated.Migrations
{
    public partial class LookUp17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Record_Status",
                table: "Strategy_KeyPerformanceArea",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AddColumn<string>(
                name: "TestEmail",
                table: "Employees",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Struc_DirStaffMapping",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(nullable: false),
                    EmployeePK = table.Column<int>(nullable: false),
                    IdentityUserId = table.Column<string>(nullable: true),
                    Staff_Number = table.Column<string>(maxLength: 50, nullable: false),
                    Directorate_Id = table.Column<int>(nullable: false),
                    Mapping_Status = table.Column<bool>(nullable: true),
                    PrimaryDirectorate = table.Column<bool>(nullable: true),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Struc_DirStaffMapping", x => x.Transaction_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Struc_DirStaffMapping");

            migrationBuilder.DropColumn(
                name: "TestEmail",
                table: "Employees");

            migrationBuilder.AlterColumn<bool>(
                name: "Record_Status",
                table: "Strategy_KeyPerformanceArea",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);
        }
    }
}
