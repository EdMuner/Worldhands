using Microsoft.EntityFrameworkCore.Migrations;

namespace Worldhands.Web.Migrations
{
    public partial class changeDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Visitors",
                newName: "PhoneNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Visitors",
                newName: "Address");
        }
    }
}
