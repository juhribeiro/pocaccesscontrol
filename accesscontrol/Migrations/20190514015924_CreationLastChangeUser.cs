using Microsoft.EntityFrameworkCore.Migrations;

namespace accesscontrol.Migrations
{
    public partial class CreationLastChangeUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreateUser",
                schema: "accesscontrol",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastChangeUser",
                schema: "accesscontrol",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                schema: "accesscontrol",
                table: "Roles",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CreateUser",
                schema: "accesscontrol",
                table: "Roles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastChangeUser",
                schema: "accesscontrol",
                table: "Roles",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                schema: "accesscontrol",
                table: "Groups",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CreateUser",
                schema: "accesscontrol",
                table: "Groups",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastChangeUser",
                schema: "accesscontrol",
                table: "Groups",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                schema: "accesscontrol",
                table: "Applications",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CreateUser",
                schema: "accesscontrol",
                table: "Applications",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastChangeUser",
                schema: "accesscontrol",
                table: "Applications",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateUser",
                schema: "accesscontrol",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastChangeUser",
                schema: "accesscontrol",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Active",
                schema: "accesscontrol",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "CreateUser",
                schema: "accesscontrol",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "LastChangeUser",
                schema: "accesscontrol",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "Active",
                schema: "accesscontrol",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "CreateUser",
                schema: "accesscontrol",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "LastChangeUser",
                schema: "accesscontrol",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "Active",
                schema: "accesscontrol",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "CreateUser",
                schema: "accesscontrol",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "LastChangeUser",
                schema: "accesscontrol",
                table: "Applications");
        }
    }
}
