using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rapporti.Migrations
{
    public partial class Migration012 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rapporti_Gruppi_GruppoId",
                table: "Rapporti");

            migrationBuilder.AlterColumn<int>(
                name: "GruppoId",
                table: "Rapporti",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rapporti_Gruppi_GruppoId",
                table: "Rapporti",
                column: "GruppoId",
                principalTable: "Gruppi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rapporti_Gruppi_GruppoId",
                table: "Rapporti");

            migrationBuilder.AlterColumn<int>(
                name: "GruppoId",
                table: "Rapporti",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Rapporti_Gruppi_GruppoId",
                table: "Rapporti",
                column: "GruppoId",
                principalTable: "Gruppi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
