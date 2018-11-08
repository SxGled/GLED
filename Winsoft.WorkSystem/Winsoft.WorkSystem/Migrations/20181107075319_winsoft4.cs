using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Winsoft.WorkSystem.Migrations
{
    public partial class winsoft4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admin_AdminScope_AdminScopeIdentifier",
                table: "Admin");

            migrationBuilder.DropIndex(
                name: "IX_Admin_AdminScopeIdentifier",
                table: "Admin");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Admin_AdminScopeIdentifier",
                table: "Admin",
                column: "AdminScopeIdentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Admin_AdminScope_AdminScopeIdentifier",
                table: "Admin",
                column: "AdminScopeIdentifier",
                principalTable: "AdminScope",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
