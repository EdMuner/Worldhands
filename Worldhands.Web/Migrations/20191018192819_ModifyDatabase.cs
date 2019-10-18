using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Worldhands.Web.Migrations
{
    public partial class ModifyDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visitors_User_UserId",
                table: "Visitors");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_Visitors_UserId",
                table: "Visitors");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Visitors");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Visitors",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Document",
                table: "Visitors",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Visitors",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Visitors",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Visitors");

            migrationBuilder.DropColumn(
                name: "Document",
                table: "Visitors");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Visitors");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Visitors");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Visitors",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Address = table.Column<string>(maxLength: 100, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Document = table.Column<string>(maxLength: 20, nullable: false),
                    Email = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Visitors_UserId",
                table: "Visitors",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Visitors_User_UserId",
                table: "Visitors",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
