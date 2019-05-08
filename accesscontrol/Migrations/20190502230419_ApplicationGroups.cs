using Microsoft.EntityFrameworkCore.Migrations;

namespace accesscontrol.Migrations
{
    public partial class ApplicationGroups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CPF",
                schema: "accesscontrol",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationId",
                schema: "accesscontrol",
                table: "Groups",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_ApplicationId",
                schema: "accesscontrol",
                table: "Groups",
                column: "ApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Applications_ApplicationId",
                schema: "accesscontrol",
                table: "Groups",
                column: "ApplicationId",
                principalSchema: "accesscontrol",
                principalTable: "Applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Applications_ApplicationId",
                schema: "accesscontrol",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_ApplicationId",
                schema: "accesscontrol",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "ApplicationId",
                schema: "accesscontrol",
                table: "Groups");

            migrationBuilder.AddColumn<string>(
                name: "CPF",
                schema: "accesscontrol",
                table: "Users",
                nullable: true);
        }
    }
}
