using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Winsoft.WorkSystem.Migrations
{
    public partial class winsoft1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdminScopeIdentifier = table.Column<int>(maxLength: 11, nullable: false),
                    CreateTime = table.Column<string>(maxLength: 30, nullable: true),
                    Password = table.Column<string>(maxLength: 30, nullable: false),
                    RealName = table.Column<string>(maxLength: 50, nullable: false),
                    UpdateTime = table.Column<string>(maxLength: 30, nullable: true),
                    UserName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdminScope",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Identifier = table.Column<int>(maxLength: 11, nullable: false),
                    OneLevelScopeId = table.Column<int>(maxLength: 11, nullable: false),
                    OneLevelScopeName = table.Column<string>(maxLength: 50, nullable: false),
                    TwoLevelScopeId = table.Column<int>(maxLength: 11, nullable: false),
                    TwoLevelScopeName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminScope", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "AdminScope");
        }
    }
}
