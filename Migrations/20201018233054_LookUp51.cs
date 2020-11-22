using Microsoft.EntityFrameworkCore.Migrations;

namespace AUDANEPAD_Integrated.Migrations
{
    public partial class LookUp51 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Indicator_Type_Id",
                table: "Trans_StrucDirDivIndicators",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Indicator_Type_Id",
                table: "Struc_DirDivIndicators",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Indicator_Type_Id",
                table: "Trans_StrucDirDivIndicators");

            migrationBuilder.DropColumn(
                name: "Indicator_Type_Id",
                table: "Struc_DirDivIndicators");
        }
    }
}
