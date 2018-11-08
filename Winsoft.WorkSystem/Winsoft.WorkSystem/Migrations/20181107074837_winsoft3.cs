using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Winsoft.WorkSystem.Migrations
{
    public partial class winsoft3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admin_AdminScope_AdminScopeId",
                table: "Admin");

            migrationBuilder.DropIndex(
                name: "IX_Admin_AdminScopeId",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "AdminScopeId",
                table: "Admin");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admin_AdminScope_AdminScopeIdentifier",
                table: "Admin");

            migrationBuilder.DropIndex(
                name: "IX_Admin_AdminScopeIdentifier",
                table: "Admin");

            migrationBuilder.AddColumn<int>(
                name: "AdminScopeId",
                table: "Admin",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Admin_AdminScopeId",
                table: "Admin",
                column: "AdminScopeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Admin_AdminScope_AdminScopeId",
                table: "Admin",
                column: "AdminScopeId",
                principalTable: "AdminScope",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
