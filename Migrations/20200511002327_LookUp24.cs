using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AUDANEPAD_Integrated.Migrations
{
    public partial class LookUp24 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LkUp_Programme",
                columns: table => new
                {
                    Record_Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Record_Name = table.Column<string>(maxLength: 255, nullable: false),
                    Directorate_Id = table.Column<int>(nullable: false),
                    Division_Id = table.Column<int>(nullable: false),
                    DocPath = table.Column<string>(nullable: true),
                    Record_Status = table.Column<bool>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LkUp_Programme", x => x.Record_Id);
                });

            migrationBuilder.CreateTable(
                name: "LkUp_Project",
                columns: table => new
                {
                    Record_Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Record_Name = table.Column<string>(maxLength: 255, nullable: false),
                    Programme_Id = table.Column<int>(nullable: false),
                    Directorate_Id = table.Column<int>(nullable: false),
                    Division_Id = table.Column<int>(nullable: false),
                    DocPath = table.Column<string>(nullable: true),
                    Record_Status = table.Column<bool>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LkUp_Project", x => x.Record_Id);
                });

            migrationBuilder.CreateTable(
                name: "Trans_Programme",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(nullable: false),
                    MainProgramme_Id = table.Column<int>(nullable: false),
                    Directorate_Id = table.Column<int>(nullable: false),
                    Division_Id = table.Column<int>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trans_Programme", x => x.Transaction_Id);
                });

            migrationBuilder.CreateTable(
                name: "Trans_Project",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(nullable: false),
                    TransProgramme_Id = table.Column<string>(nullable: true),
                    MainProject_Id = table.Column<int>(nullable: false),
                    MainProgramme_Id = table.Column<int>(nullable: false),
                    Directorate_Id = table.Column<int>(nullable: false),
                    Division_Id = table.Column<int>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trans_Project", x => x.Transaction_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LkUp_Programme");

            migrationBuilder.DropTable(
                name: "LkUp_Project");

            migrationBuilder.DropTable(
                name: "Trans_Programme");

            migrationBuilder.DropTable(
                name: "Trans_Project");
        }
    }
}
