using Microsoft.EntityFrameworkCore.Migrations;

namespace AutumnStore.Data.Migrations
{
    public partial class updateUserModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserAddress2",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Zip",
                table: "User",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "User");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "User");

            migrationBuilder.DropColumn(
                name: "State",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserAddress2",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Zip",
                table: "User");
        }
    }
}
