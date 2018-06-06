using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace artistry_Data.Migrations
{
    public partial class FourteenthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "TicketTypes",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "CurrencyId",
                table: "TicketTypes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TicketTypes_CurrencyId",
                table: "TicketTypes",
                column: "CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketTypes_Currencies_CurrencyId",
                table: "TicketTypes",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketTypes_Currencies_CurrencyId",
                table: "TicketTypes");

            migrationBuilder.DropIndex(
                name: "IX_TicketTypes_CurrencyId",
                table: "TicketTypes");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "TicketTypes");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "TicketTypes",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
