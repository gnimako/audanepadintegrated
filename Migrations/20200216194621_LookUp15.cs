using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AUDANEPAD_Integrated.Migrations
{
    public partial class LookUp15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Struc_Directorate",
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
                    table.PrimaryKey("PK_Struc_Directorate", x => x.Record_Id);
                });

            migrationBuilder.CreateTable(
                name: "Struc_Division",
                columns: table => new
                {
                    Record_Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Directorate_Id = table.Column<int>(maxLength: 255, nullable: false),
                    Record_Name = table.Column<string>(nullable: true),
                    Record_Status = table.Column<bool>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Struc_Division", x => x.Record_Id);
                });

            migrationBuilder.CreateTable(
                name: "Trans_StrucDirectorate",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(nullable: false),
                    Record_Id = table.Column<int>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trans_StrucDirectorate", x => x.Transaction_Id);
                });

            migrationBuilder.CreateTable(
                name: "Trans_StrucDivision",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(nullable: false),
                    TransDirectorate_Id = table.Column<string>(nullable: true),
                    Division_Id = table.Column<int>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trans_StrucDivision", x => x.Transaction_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Struc_Directorate");

            migrationBuilder.DropTable(
                name: "Struc_Division");

            migrationBuilder.DropTable(
                name: "Trans_StrucDirectorate");

            migrationBuilder.DropTable(
                name: "Trans_StrucDivision");
        }
    }
}
