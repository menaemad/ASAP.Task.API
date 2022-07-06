using Microsoft.EntityFrameworkCore.Migrations;

namespace ASAPSystem.Assignment.Data.Migrations
{
    public partial class updateaddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "County",
                table: "Addresses",
                newName: "Country");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Addresses",
                newName: "County");
        }
    }
}
