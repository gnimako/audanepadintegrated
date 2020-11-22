using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AUDANEPAD_Integrated.Migrations
{
    public partial class LookUp50 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Struc_DirDivIndicators",
                columns: table => new
                {
                    Record_Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Directorate_Id = table.Column<int>(nullable: false),
                    Division_Id = table.Column<int>(nullable: false),
                    Record_Name = table.Column<string>(nullable: true),
                    Indicator_Type = table.Column<string>(nullable: true),
                    Record_Status = table.Column<bool>(nullable: true),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Struc_DirDivIndicators", x => x.Record_Id);
                });

            migrationBuilder.CreateTable(
                name: "Trans_StrucDirDivIndicators",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(nullable: false),
                    Record_Id = table.Column<int>(nullable: false),
                    Directorate_Id = table.Column<int>(nullable: false),
                    Division_Id = table.Column<int>(nullable: false),
                    Record_Name = table.Column<string>(nullable: true),
                    Indicator_Type = table.Column<string>(nullable: true),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trans_StrucDirDivIndicators", x => x.Transaction_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Struc_DirDivIndicators");

            migrationBuilder.DropTable(
                name: "Trans_StrucDirDivIndicators");
        }
    }
}
