using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AUDANEPAD_Integrated.Migrations
{
    public partial class LookUp5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LkUp_CostCatelogue",
                columns: table => new
                {
                    Cost_Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Cost_Code = table.Column<string>(nullable: true),
                    Cost_Category = table.Column<string>(nullable: true),
                    Cost_Description = table.Column<string>(nullable: true),
                    Unit_Of_Measure = table.Column<string>(nullable: true),
                    Unit_Cost = table.Column<float>(nullable: false),
                    Cost_Status = table.Column<bool>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LkUp_CostCatelogue", x => x.Cost_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LkUp_CostCatelogue");
        }
    }
}
