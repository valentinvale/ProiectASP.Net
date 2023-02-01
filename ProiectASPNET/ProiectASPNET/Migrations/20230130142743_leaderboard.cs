using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectASPNET.Migrations
{
    /// <inheritdoc />
    public partial class leaderboard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Leaderboards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuoteOfTheMonthId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leaderboards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leaderboards_QuotesOfTheMonth_QuoteOfTheMonthId",
                        column: x => x.QuoteOfTheMonthId,
                        principalTable: "QuotesOfTheMonth",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuotesOfTheMonth",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuoteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Month = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Impressions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuotesOfTheMonth", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuotesOfTheMonth_Quotes_QuoteId",
                        column: x => x.QuoteId,
                        principalTable: "Quotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuotesOfTheMonth_LeaderboardId",
                table: "QuotesOfTheMonth",
                column: "LeaderboardId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuotesOfTheMonth_QuoteId",
                table: "QuotesOfTheMonth",
                column: "QuoteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuotesOfTheMonth");

            migrationBuilder.DropTable(
                name: "Leaderboards");
        }
    }
}
