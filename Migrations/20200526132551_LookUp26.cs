using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AUDANEPAD_Integrated.Migrations
{
    public partial class LookUp26 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LkUp_Period",
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
                    table.PrimaryKey("PK_LkUp_Period", x => x.Record_Id);
                });

            migrationBuilder.CreateTable(
                name: "Trans_Period",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(nullable: false),
                    Record_Id = table.Column<int>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trans_Period", x => x.Transaction_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LkUp_Period");

            migrationBuilder.DropTable(
                name: "Trans_Period");
        }
    }
}
