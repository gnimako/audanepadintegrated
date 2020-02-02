using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AUDANEPAD_Integrated.Migrations
{
    public partial class LookUp7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LkUp_CommsChannel",
                columns: table => new
                {
                    CommsChannel_Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CommsChannel_Name = table.Column<string>(maxLength: 255, nullable: false),
                    CommsChannel_Status = table.Column<bool>(nullable: true),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LkUp_CommsChannel", x => x.CommsChannel_Id);
                });

            migrationBuilder.CreateTable(
                name: "LkUp_Country",
                columns: table => new
                {
                    Country_Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Country_Name = table.Column<string>(maxLength: 255, nullable: false),
                    Country_Status = table.Column<bool>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LkUp_Country", x => x.Country_Id);
                });

            migrationBuilder.CreateTable(
                name: "Trans_CommsChannel",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(nullable: false),
                    CommsChannel_Id = table.Column<int>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trans_CommsChannel", x => x.Transaction_Id);
                });

            migrationBuilder.CreateTable(
                name: "Trans_Country",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(nullable: false),
                    Country_Id = table.Column<int>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trans_Country", x => x.Transaction_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LkUp_CommsChannel");

            migrationBuilder.DropTable(
                name: "LkUp_Country");

            migrationBuilder.DropTable(
                name: "Trans_CommsChannel");

            migrationBuilder.DropTable(
                name: "Trans_Country");
        }
    }
}
