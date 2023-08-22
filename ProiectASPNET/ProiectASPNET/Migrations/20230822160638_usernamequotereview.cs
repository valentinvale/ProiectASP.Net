using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectASPNET.Migrations
{
    /// <inheritdoc />
    public partial class usernamequotereview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Reviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Quotes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Quotes");
        }
    }
}
