using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace artistry_Data.Migrations
{
    public partial class NinteenthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MuseumId",
                table: "Artworks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Artworks_MuseumId",
                table: "Artworks",
                column: "MuseumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Artworks_Museums_MuseumId",
                table: "Artworks",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artworks_Museums_MuseumId",
                table: "Artworks");

            migrationBuilder.DropIndex(
                name: "IX_Artworks_MuseumId",
                table: "Artworks");

            migrationBuilder.DropColumn(
                name: "MuseumId",
                table: "Artworks");
        }
    }
}
