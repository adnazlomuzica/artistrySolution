using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace artistry_Data.Migrations
{
    public partial class SeventeenthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccessionNumber",
                table: "Artworks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Artworks",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ArtistId",
                table: "Artworks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ArtworkTypeId",
                table: "Artworks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CatalogueEntry",
                table: "Artworks",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Artworks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "Artworks",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaterialId",
                table: "Artworks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Artworks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Provenance",
                table: "Artworks",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StyleId",
                table: "Artworks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Artworks_ArtistId",
                table: "Artworks",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Artworks_ArtworkTypeId",
                table: "Artworks",
                column: "ArtworkTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Artworks_CountryId",
                table: "Artworks",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Artworks_MaterialId",
                table: "Artworks",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Artworks_StyleId",
                table: "Artworks",
                column: "StyleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Artworks_Artists_ArtistId",
                table: "Artworks",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Artworks_ArtworkTypes_ArtworkTypeId",
                table: "Artworks",
                column: "ArtworkTypeId",
                principalTable: "ArtworkTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Artworks_Countries_CountryId",
                table: "Artworks",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Artworks_Materials_MaterialId",
                table: "Artworks",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Artworks_Styles_StyleId",
                table: "Artworks",
                column: "StyleId",
                principalTable: "Styles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artworks_Artists_ArtistId",
                table: "Artworks");

            migrationBuilder.DropForeignKey(
                name: "FK_Artworks_ArtworkTypes_ArtworkTypeId",
                table: "Artworks");

            migrationBuilder.DropForeignKey(
                name: "FK_Artworks_Countries_CountryId",
                table: "Artworks");

            migrationBuilder.DropForeignKey(
                name: "FK_Artworks_Materials_MaterialId",
                table: "Artworks");

            migrationBuilder.DropForeignKey(
                name: "FK_Artworks_Styles_StyleId",
                table: "Artworks");

            migrationBuilder.DropIndex(
                name: "IX_Artworks_ArtistId",
                table: "Artworks");

            migrationBuilder.DropIndex(
                name: "IX_Artworks_ArtworkTypeId",
                table: "Artworks");

            migrationBuilder.DropIndex(
                name: "IX_Artworks_CountryId",
                table: "Artworks");

            migrationBuilder.DropIndex(
                name: "IX_Artworks_MaterialId",
                table: "Artworks");

            migrationBuilder.DropIndex(
                name: "IX_Artworks_StyleId",
                table: "Artworks");

            migrationBuilder.DropColumn(
                name: "AccessionNumber",
                table: "Artworks");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Artworks");

            migrationBuilder.DropColumn(
                name: "ArtistId",
                table: "Artworks");

            migrationBuilder.DropColumn(
                name: "ArtworkTypeId",
                table: "Artworks");

            migrationBuilder.DropColumn(
                name: "CatalogueEntry",
                table: "Artworks");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Artworks");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Artworks");

            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "Artworks");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Artworks");

            migrationBuilder.DropColumn(
                name: "Provenance",
                table: "Artworks");

            migrationBuilder.DropColumn(
                name: "StyleId",
                table: "Artworks");
        }
    }
}
