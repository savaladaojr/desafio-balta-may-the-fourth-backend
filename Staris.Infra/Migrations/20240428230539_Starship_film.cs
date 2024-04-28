using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Staris.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Starship_film : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StarshipFilms",
                columns: table => new
                {
                    StartshipId = table.Column<int>(type: "INTEGER", nullable: false),
                    FilmId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StarshipFilms", x => new { x.FilmId, x.StartshipId });
                    table.ForeignKey(
                        name: "FK_StarshipFilms_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StarshipFilms_Starships_StartshipId",
                        column: x => x.StartshipId,
                        principalTable: "Starships",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StarshipFilms_StartshipId",
                table: "StarshipFilms",
                column: "StartshipId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StarshipFilms");
        }
    }
}
