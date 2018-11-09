using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Winsoft.WorkSystem.Migrations
{
    public partial class winsoft5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateTime = table.Column<string>(maxLength: 50, nullable: false),
                    EstimateTime = table.Column<string>(maxLength: 50, nullable: false),
                    FinishTime = table.Column<string>(maxLength: 50, nullable: false),
                    JoinUser = table.Column<string>(maxLength: 255, nullable: false),
                    ProjectDesc = table.Column<string>(maxLength: 50, nullable: false),
                    ProjectName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Project");
        }
    }
}
