using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace artistry_Data.Migrations
{
    public partial class TwentiethSecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MuseumId",
                table: "News",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_News_MuseumId",
                table: "News",
                column: "MuseumId");

            migrationBuilder.AddForeignKey(
                name: "FK_News_Museums_MuseumId",
                table: "News",
                column: "MuseumId",
                principalTable: "Museums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_Museums_MuseumId",
                table: "News");

            migrationBuilder.DropIndex(
                name: "IX_News_MuseumId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "MuseumId",
                table: "News");
        }
    }
}
