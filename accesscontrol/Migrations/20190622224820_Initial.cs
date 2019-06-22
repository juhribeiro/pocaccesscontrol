using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace accesscontrol.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "accesscontrol");

            migrationBuilder.CreateTable(
                name: "Applications",
                schema: "accesscontrol",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateUser = table.Column<int>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastChangeUser = table.Column<int>(nullable: true),
                    LastChangeDate = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Code = table.Column<string>(maxLength: 50, nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "accesscontrol",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateUser = table.Column<int>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastChangeUser = table.Column<int>(nullable: true),
                    LastChangeDate = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Code = table.Column<string>(maxLength: 50, nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "accesscontrol",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateUser = table.Column<int>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastChangeUser = table.Column<int>(nullable: true),
                    LastChangeDate = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 150, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    DocumentNumber = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    CellPhoneNumber = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    NumberLoginErros = table.Column<int>(nullable: true),
                    NumberGenerate = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                schema: "accesscontrol",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateUser = table.Column<int>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastChangeUser = table.Column<int>(nullable: true),
                    LastChangeDate = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Code = table.Column<string>(maxLength: 50, nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ApplicationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groups_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalSchema: "accesscontrol",
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserApplications",
                schema: "accesscontrol",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    ApplicationId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateUser = table.Column<int>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastChangeUser = table.Column<int>(nullable: true),
                    LastChangeDate = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserApplications", x => new { x.UserId, x.ApplicationId });
                    table.UniqueConstraint("AK_UserApplications_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserApplications_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalSchema: "accesscontrol",
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserApplications_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "accesscontrol",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleGroups",
                schema: "accesscontrol",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false),
                    GroupId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateUser = table.Column<int>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastChangeUser = table.Column<int>(nullable: true),
                    LastChangeDate = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleGroups", x => new { x.RoleId, x.GroupId });
                    table.UniqueConstraint("AK_RoleGroups_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleGroups_Groups_GroupId",
                        column: x => x.GroupId,
                        principalSchema: "accesscontrol",
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleGroups_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "accesscontrol",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserGroups",
                schema: "accesscontrol",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    GroupId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateUser = table.Column<int>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastChangeUser = table.Column<int>(nullable: true),
                    LastChangeDate = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroups", x => new { x.UserId, x.GroupId });
                    table.UniqueConstraint("AK_UserGroups_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserGroups_Groups_GroupId",
                        column: x => x.GroupId,
                        principalSchema: "accesscontrol",
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGroups_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "accesscontrol",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_Code",
                schema: "accesscontrol",
                table: "Applications",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_ApplicationId",
                schema: "accesscontrol",
                table: "Groups",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_Code",
                schema: "accesscontrol",
                table: "Groups",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoleGroups_GroupId",
                schema: "accesscontrol",
                table: "RoleGroups",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Code",
                schema: "accesscontrol",
                table: "Roles",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserApplications_ApplicationId",
                schema: "accesscontrol",
                table: "UserApplications",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroups_GroupId",
                schema: "accesscontrol",
                table: "UserGroups",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                schema: "accesscontrol",
                table: "Users",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleGroups",
                schema: "accesscontrol");

            migrationBuilder.DropTable(
                name: "UserApplications",
                schema: "accesscontrol");

            migrationBuilder.DropTable(
                name: "UserGroups",
                schema: "accesscontrol");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "accesscontrol");

            migrationBuilder.DropTable(
                name: "Groups",
                schema: "accesscontrol");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "accesscontrol");

            migrationBuilder.DropTable(
                name: "Applications",
                schema: "accesscontrol");
        }
    }
}
