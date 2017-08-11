using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rapporti.Data.Migrations
{
    public partial class Migration9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compiti_Gruppi_GruppoId",
                table: "Compiti");

            migrationBuilder.DropForeignKey(
                name: "FK_Compiti_AspNetUsers_UtenteId",
                table: "Compiti");

            migrationBuilder.DropIndex(
                name: "IX_Compiti_GruppoId",
                table: "Compiti");

            migrationBuilder.DropIndex(
                name: "IX_Compiti_UtenteId",
                table: "Compiti");

            migrationBuilder.AlterColumn<string>(
                name: "UtenteId",
                table: "Compiti",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GruppoId",
                table: "Compiti",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UtenteId",
                table: "Compiti",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GruppoId",
                table: "Compiti",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Compiti_GruppoId",
                table: "Compiti",
                column: "GruppoId");

            migrationBuilder.CreateIndex(
                name: "IX_Compiti_UtenteId",
                table: "Compiti",
                column: "UtenteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Compiti_Gruppi_GruppoId",
                table: "Compiti",
                column: "GruppoId",
                principalTable: "Gruppi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Compiti_AspNetUsers_UtenteId",
                table: "Compiti",
                column: "UtenteId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
