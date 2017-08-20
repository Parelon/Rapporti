using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rapporti.Migrations
{
    public partial class Migration005 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SoggettoUtenteId",
                table: "Rapporti");

            migrationBuilder.DropColumn(
                name: "UtenteId",
                table: "Rapporti");

            migrationBuilder.AddColumn<int>(
                name: "UtenteId",
                table: "Rapporti",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rapporti_UtenteId",
                table: "Rapporti",
                column: "UtenteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rapporti_AspNetUsers_UtenteId",
                table: "Rapporti",
                column: "UtenteId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rapporti_AspNetUsers_UtenteId",
                table: "Rapporti");

            migrationBuilder.DropIndex(
                name: "IX_Rapporti_UtenteId",
                table: "Rapporti");

            migrationBuilder.DropColumn(
                name: "UtenteId",
                table: "Rapporti");
        }
    }
}
