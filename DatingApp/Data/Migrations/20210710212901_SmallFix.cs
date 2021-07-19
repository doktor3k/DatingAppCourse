using Microsoft.EntityFrameworkCore.Migrations;

namespace DatingApp.Data.Migrations
{
    public partial class SmallFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateOfBrith",
                table: "Users",
                newName: "DateOfBirth");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                table: "Users",
                newName: "DateOfBrith");
        }
    }
}
