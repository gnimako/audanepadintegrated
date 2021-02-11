using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AUDANEPAD_Integrated.Migrations
{
    public partial class LookUp71 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WP_Tasks",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(nullable: false),
                    WPCategoryMain = table.Column<string>(nullable: true),
                    WPReference_Id = table.Column<string>(nullable: true),
                    WPCategorySub1 = table.Column<string>(nullable: true),
                    WPCategorySub2 = table.Column<string>(nullable: true),
                    WPCategorySub3 = table.Column<string>(nullable: true),
                    WPCategorySub4 = table.Column<string>(nullable: true),
                    WPCategorySub5 = table.Column<string>(nullable: true),
                    WPTaskDescription = table.Column<string>(nullable: true),
                    WPTaskStatus = table.Column<string>(nullable: true),
                    WPRequesterEmployee_Id = table.Column<int>(nullable: false),
                    WPRepondentEmployee_Id = table.Column<int>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WP_Tasks", x => x.Transaction_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WP_Tasks");
        }
    }
}
