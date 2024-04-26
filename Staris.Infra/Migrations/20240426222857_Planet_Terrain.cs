using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Staris.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Planet_Terrain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Terrain",
                table: "Planets",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Terrain",
                table: "Planets");
        }
    }
}
