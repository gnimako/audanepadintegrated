using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AUDANEPAD_Integrated.Migrations
{
    public partial class LookUp20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Struc_Director",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(nullable: false),
                    EmployeePK = table.Column<int>(nullable: false),
                    Staff_Number = table.Column<string>(nullable: true),
                    Directorate_Id = table.Column<int>(nullable: false),
                    Status_Id = table.Column<int>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Struc_Director", x => x.Transaction_Id);
                });

            migrationBuilder.CreateTable(
                name: "Struc_DirectorOIC",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(nullable: false),
                    EmployeePK = table.Column<int>(nullable: false),
                    Staff_Number = table.Column<string>(nullable: true),
                    Directorate_Id = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Struc_DirectorOIC", x => x.Transaction_Id);
                });

            migrationBuilder.CreateTable(
                name: "Struc_DivHead",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(nullable: false),
                    EmployeePK = table.Column<int>(nullable: false),
                    Staff_Number = table.Column<string>(nullable: true),
                    Directorate_Id = table.Column<int>(nullable: false),
                    Division_Id = table.Column<int>(nullable: false),
                    Status_Id = table.Column<int>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Struc_DivHead", x => x.Transaction_Id);
                });

            migrationBuilder.CreateTable(
                name: "Struc_DivHeadOIC",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(nullable: false),
                    ParentTransaction_Id = table.Column<string>(nullable: true),
                    EmployeePK = table.Column<int>(nullable: false),
                    Staff_Number = table.Column<string>(nullable: true),
                    Directorate_Id = table.Column<int>(nullable: false),
                    Division_Id = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Struc_DivHeadOIC", x => x.Transaction_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Struc_Director");

            migrationBuilder.DropTable(
                name: "Struc_DirectorOIC");

            migrationBuilder.DropTable(
                name: "Struc_DivHead");

            migrationBuilder.DropTable(
                name: "Struc_DivHeadOIC");
        }
    }
}
