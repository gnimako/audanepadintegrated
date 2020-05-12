using Microsoft.EntityFrameworkCore.Migrations;

namespace AUDANEPAD_Integrated.Migrations
{
    public partial class LookUp22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OIC_Status",
                table: "Struc_DivHeadOIC",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OIC_Status",
                table: "Struc_DirectorOIC",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Struc_Director",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OIC_Status",
                table: "Struc_DivHeadOIC");

            migrationBuilder.DropColumn(
                name: "OIC_Status",
                table: "Struc_DirectorOIC");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Struc_Director");
        }
    }
}
