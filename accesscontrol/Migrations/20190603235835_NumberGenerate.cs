using Microsoft.EntityFrameworkCore.Migrations;

namespace accesscontrol.Migrations
{
    public partial class NumberGenerate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberGenerate",
                schema: "accesscontrol",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberGenerate",
                schema: "accesscontrol",
                table: "Users");
        }
    }
}
