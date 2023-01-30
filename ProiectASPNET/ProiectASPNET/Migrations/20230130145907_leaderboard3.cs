using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectASPNET.Migrations
{
    /// <inheritdoc />
    public partial class leaderboard3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuotesOfTheMonth_Leaderboards_LeaderboardId",
                table: "QuotesOfTheMonth");

            migrationBuilder.DropIndex(
                name: "IX_QuotesOfTheMonth_LeaderboardId",
                table: "QuotesOfTheMonth");

            migrationBuilder.DropColumn(
                name: "LeaderboardId",
                table: "QuotesOfTheMonth");

            migrationBuilder.AddColumn<Guid>(
                name: "QuoteOfTheMonthId",
                table: "Leaderboards",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Leaderboards_QuoteOfTheMonthId",
                table: "Leaderboards",
                column: "QuoteOfTheMonthId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Leaderboards_QuotesOfTheMonth_QuoteOfTheMonthId",
                table: "Leaderboards",
                column: "QuoteOfTheMonthId",
                principalTable: "QuotesOfTheMonth",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leaderboards_QuotesOfTheMonth_QuoteOfTheMonthId",
                table: "Leaderboards");

            migrationBuilder.DropIndex(
                name: "IX_Leaderboards_QuoteOfTheMonthId",
                table: "Leaderboards");

            migrationBuilder.DropColumn(
                name: "QuoteOfTheMonthId",
                table: "Leaderboards");

            migrationBuilder.AddColumn<Guid>(
                name: "LeaderboardId",
                table: "QuotesOfTheMonth",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_QuotesOfTheMonth_LeaderboardId",
                table: "QuotesOfTheMonth",
                column: "LeaderboardId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_QuotesOfTheMonth_Leaderboards_LeaderboardId",
                table: "QuotesOfTheMonth",
                column: "LeaderboardId",
                principalTable: "Leaderboards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
