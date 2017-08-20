using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Rapporti.Migrations
{
    public partial class Migration006 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rapporti_AspNetUsers_SoggettoUtenteId",
                table: "Rapporti");

            migrationBuilder.DropForeignKey(
                name: "FK_Rapporti_AspNetUsers_UtenteId",
                table: "Rapporti");

            migrationBuilder.DropIndex(
                name: "IX_Rapporti_SoggettoUtenteId",
                table: "Rapporti");

            migrationBuilder.DropIndex(
                name: "IX_Rapporti_UtenteId",
                table: "Rapporti");

            migrationBuilder.DropColumn(
                name: "SoggettoUtenteId",
                table: "Rapporti");

            migrationBuilder.DropColumn(
                name: "UtenteId",
                table: "Rapporti");

            migrationBuilder.CreateTable(
                name: "Destinatari",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RapportoId = table.Column<int>(nullable: false),
                    UtenteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinatari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Destinatari_Rapporti_RapportoId",
                        column: x => x.RapportoId,
                        principalTable: "Rapporti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Destinatari_AspNetUsers_UtenteId",
                        column: x => x.UtenteId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Destinatari_RapportoId",
                table: "Destinatari",
                column: "RapportoId");

            migrationBuilder.CreateIndex(
                name: "IX_Destinatari_UtenteId",
                table: "Destinatari",
                column: "UtenteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Destinatari");

            migrationBuilder.AddColumn<int>(
                name: "SoggettoUtenteId",
                table: "Rapporti",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UtenteId",
                table: "Rapporti",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rapporti_SoggettoUtenteId",
                table: "Rapporti",
                column: "SoggettoUtenteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rapporti_UtenteId",
                table: "Rapporti",
                column: "UtenteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rapporti_AspNetUsers_SoggettoUtenteId",
                table: "Rapporti",
                column: "SoggettoUtenteId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rapporti_AspNetUsers_UtenteId",
                table: "Rapporti",
                column: "UtenteId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
