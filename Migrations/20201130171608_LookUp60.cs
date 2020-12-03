using Microsoft.EntityFrameworkCore.Migrations;

namespace AUDANEPAD_Integrated.Migrations
{
    public partial class LookUp60 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShortName",
                table: "Strategy_Priority",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShortName",
                table: "Strategy_MTP",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortName",
                table: "Strategy_Priority");

            migrationBuilder.DropColumn(
                name: "ShortName",
                table: "Strategy_MTP");
        }
    }
}
