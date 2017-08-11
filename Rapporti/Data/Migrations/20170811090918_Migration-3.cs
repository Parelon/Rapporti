using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Rapporti.Data.Migrations
{
    public partial class Migration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompitoId",
                table: "Gruppo",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Compito",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    utenteId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compito", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Compito_AspNetUsers_utenteId",
                        column: x => x.utenteId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gruppo_CompitoId",
                table: "Gruppo",
                column: "CompitoId");

            migrationBuilder.CreateIndex(
                name: "IX_Compito_utenteId",
                table: "Compito",
                column: "utenteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gruppo_Compito_CompitoId",
                table: "Gruppo",
                column: "CompitoId",
                principalTable: "Compito",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gruppo_Compito_CompitoId",
                table: "Gruppo");

            migrationBuilder.DropTable(
                name: "Compito");

            migrationBuilder.DropIndex(
                name: "IX_Gruppo_CompitoId",
                table: "Gruppo");

            migrationBuilder.DropColumn(
                name: "CompitoId",
                table: "Gruppo");
        }
    }
}
