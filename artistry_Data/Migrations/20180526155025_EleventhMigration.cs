using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace artistry_Data.Migrations
{
    public partial class EleventhMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Artworks_ArtworksId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_ArtworksId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "ArtworksId",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Images",
                newName: "Caption");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ArtworkId",
                table: "Images",
                column: "ArtworkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Artworks_ArtworkId",
                table: "Images",
                column: "ArtworkId",
                principalTable: "Artworks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Artworks_ArtworkId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_ArtworkId",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "Caption",
                table: "Images",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "ArtworksId",
                table: "Images",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_ArtworksId",
                table: "Images",
                column: "ArtworksId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Artworks_ArtworksId",
                table: "Images",
                column: "ArtworksId",
                principalTable: "Artworks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
