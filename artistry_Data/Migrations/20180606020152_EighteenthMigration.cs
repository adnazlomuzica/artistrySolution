using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace artistry_Data.Migrations
{
    public partial class EighteenthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artworks_Countries_CountryId",
                table: "Artworks");

            migrationBuilder.AddForeignKey(
                name: "FK_Artworks_Countries_CountryId",
                table: "Artworks",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artworks_Countries_CountryId",
                table: "Artworks");

            migrationBuilder.AddForeignKey(
                name: "FK_Artworks_Countries_CountryId",
                table: "Artworks",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
