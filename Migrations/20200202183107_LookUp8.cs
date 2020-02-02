using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AUDANEPAD_Integrated.Migrations
{
    public partial class LookUp8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LkUp_ExtParticipantType",
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
                    table.PrimaryKey("PK_LkUp_ExtParticipantType", x => x.Record_Id);
                });

            migrationBuilder.CreateTable(
                name: "LkUp_FiscalYear",
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
                    table.PrimaryKey("PK_LkUp_FiscalYear", x => x.Record_Id);
                });

            migrationBuilder.CreateTable(
                name: "LkUp_ImplementationType",
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
                    table.PrimaryKey("PK_LkUp_ImplementationType", x => x.Record_Id);
                });

            migrationBuilder.CreateTable(
                name: "LkUp_LeadershipStatus",
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
                    table.PrimaryKey("PK_LkUp_LeadershipStatus", x => x.Record_Id);
                });

            migrationBuilder.CreateTable(
                name: "LkUp_ParticipantType",
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
                    table.PrimaryKey("PK_LkUp_ParticipantType", x => x.Record_Id);
                });

            migrationBuilder.CreateTable(
                name: "Trans_ExtParticipantType",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(nullable: false),
                    Record_Id = table.Column<int>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trans_ExtParticipantType", x => x.Transaction_Id);
                });

            migrationBuilder.CreateTable(
                name: "Trans_FiscalYear",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(nullable: false),
                    Record_Id = table.Column<int>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trans_FiscalYear", x => x.Transaction_Id);
                });

            migrationBuilder.CreateTable(
                name: "Trans_ImplementationType",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(nullable: false),
                    Record_Id = table.Column<int>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trans_ImplementationType", x => x.Transaction_Id);
                });

            migrationBuilder.CreateTable(
                name: "Trans_LeadershipStatus",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(nullable: false),
                    Record_Id = table.Column<int>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trans_LeadershipStatus", x => x.Transaction_Id);
                });

            migrationBuilder.CreateTable(
                name: "Trans_ParticipantType",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(nullable: false),
                    Record_Id = table.Column<int>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trans_ParticipantType", x => x.Transaction_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LkUp_ExtParticipantType");

            migrationBuilder.DropTable(
                name: "LkUp_FiscalYear");

            migrationBuilder.DropTable(
                name: "LkUp_ImplementationType");

            migrationBuilder.DropTable(
                name: "LkUp_LeadershipStatus");

            migrationBuilder.DropTable(
                name: "LkUp_ParticipantType");

            migrationBuilder.DropTable(
                name: "Trans_ExtParticipantType");

            migrationBuilder.DropTable(
                name: "Trans_FiscalYear");

            migrationBuilder.DropTable(
                name: "Trans_ImplementationType");

            migrationBuilder.DropTable(
                name: "Trans_LeadershipStatus");

            migrationBuilder.DropTable(
                name: "Trans_ParticipantType");
        }
    }
}
