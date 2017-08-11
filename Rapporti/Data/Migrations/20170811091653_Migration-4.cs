using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rapporti.Data.Migrations
{
    public partial class Migration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compito_AspNetUsers_utenteId",
                table: "Compito");

            migrationBuilder.DropForeignKey(
                name: "FK_Gruppo_Compito_CompitoId",
                table: "Gruppo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gruppo",
                table: "Gruppo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Compito",
                table: "Compito");

            migrationBuilder.RenameTable(
                name: "Gruppo",
                newName: "Gruppi");

            migrationBuilder.RenameTable(
                name: "Compito",
                newName: "Compiti");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Gruppi",
                newName: "Nome");

            migrationBuilder.RenameIndex(
                name: "IX_Gruppo_CompitoId",
                table: "Gruppi",
                newName: "IX_Gruppi_CompitoId");

            migrationBuilder.RenameColumn(
                name: "utenteId",
                table: "Compiti",
                newName: "UtenteId");

            migrationBuilder.RenameIndex(
                name: "IX_Compito_utenteId",
                table: "Compiti",
                newName: "IX_Compiti_UtenteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gruppi",
                table: "Gruppi",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Compiti",
                table: "Compiti",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Compiti_AspNetUsers_UtenteId",
                table: "Compiti",
                column: "UtenteId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Gruppi_Compiti_CompitoId",
                table: "Gruppi",
                column: "CompitoId",
                principalTable: "Compiti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compiti_AspNetUsers_UtenteId",
                table: "Compiti");

            migrationBuilder.DropForeignKey(
                name: "FK_Gruppi_Compiti_CompitoId",
                table: "Gruppi");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gruppi",
                table: "Gruppi");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Compiti",
                table: "Compiti");

            migrationBuilder.RenameTable(
                name: "Gruppi",
                newName: "Gruppo");

            migrationBuilder.RenameTable(
                name: "Compiti",
                newName: "Compito");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Gruppo",
                newName: "nome");

            migrationBuilder.RenameIndex(
                name: "IX_Gruppi_CompitoId",
                table: "Gruppo",
                newName: "IX_Gruppo_CompitoId");

            migrationBuilder.RenameColumn(
                name: "UtenteId",
                table: "Compito",
                newName: "utenteId");

            migrationBuilder.RenameIndex(
                name: "IX_Compiti_UtenteId",
                table: "Compito",
                newName: "IX_Compito_utenteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gruppo",
                table: "Gruppo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Compito",
                table: "Compito",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Compito_AspNetUsers_utenteId",
                table: "Compito",
                column: "utenteId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Gruppo_Compito_CompitoId",
                table: "Gruppo",
                column: "CompitoId",
                principalTable: "Compito",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
