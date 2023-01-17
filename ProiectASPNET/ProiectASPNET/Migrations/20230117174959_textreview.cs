using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectASPNET.Migrations
{
    /// <inheritdoc />
    public partial class textreview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReviewText",
                table: "Reviews",
                newName: "Text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Reviews",
                newName: "ReviewText");
        }
    }
}
