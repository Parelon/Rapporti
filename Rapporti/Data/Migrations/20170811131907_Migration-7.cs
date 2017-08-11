using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rapporti.Data.Migrations
{
    public partial class Migration7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gruppi_Compiti_CompitoId",
                table: "Gruppi");

            migrationBuilder.DropIndex(
                name: "IX_Gruppi_CompitoId",
                table: "Gruppi");

            migrationBuilder.DropColumn(
                name: "CompitoId",
                table: "Gruppi");

            migrationBuilder.AddColumn<int>(
                name: "GruppoId",
                table: "Compiti",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Compiti_GruppoId",
                table: "Compiti",
                column: "GruppoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Compiti_Gruppi_GruppoId",
                table: "Compiti",
                column: "GruppoId",
                principalTable: "Gruppi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compiti_Gruppi_GruppoId",
                table: "Compiti");

            migrationBuilder.DropIndex(
                name: "IX_Compiti_GruppoId",
                table: "Compiti");

            migrationBuilder.DropColumn(
                name: "GruppoId",
                table: "Compiti");

            migrationBuilder.AddColumn<int>(
                name: "CompitoId",
                table: "Gruppi",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Gruppi_CompitoId",
                table: "Gruppi",
                column: "CompitoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gruppi_Compiti_CompitoId",
                table: "Gruppi",
                column: "CompitoId",
                principalTable: "Compiti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
