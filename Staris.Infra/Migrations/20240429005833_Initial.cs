using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Staris.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Episode = table.Column<int>(type: "integer", nullable: false),
                    OpeningCrawl = table.Column<string>(type: "text", nullable: false),
                    Director = table.Column<string>(type: "text", nullable: false),
                    Producer = table.Column<string>(type: "text", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Planets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    RotationPeriod = table.Column<int>(type: "integer", nullable: false),
                    OrbitalPeriod = table.Column<int>(type: "integer", nullable: false),
                    Diameter = table.Column<int>(type: "integer", nullable: false),
                    Climate = table.Column<string>(type: "text", nullable: false),
                    Gravity = table.Column<decimal>(type: "numeric", nullable: false),
                    Terrain = table.Column<string>(type: "text", nullable: false),
                    SurfaceWater = table.Column<decimal>(type: "numeric", nullable: false),
                    Population = table.Column<long>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Model = table.Column<string>(type: "text", nullable: false),
                    Manufacturer = table.Column<string>(type: "text", nullable: false),
                    Cost = table.Column<decimal>(type: "real", nullable: false),
                    Lenght = table.Column<decimal>(type: "real", nullable: false),
                    MaxSpeed = table.Column<decimal>(type: "real", nullable: false),
                    Crew = table.Column<int>(type: "integer", nullable: false),
                    Passengers = table.Column<int>(type: "integer", nullable: false),
                    CargoCapacity = table.Column<decimal>(type: "real", nullable: false),
                    Consumables = table.Column<int>(type: "integer", nullable: false),
                    Class = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    BirthYear = table.Column<decimal>(type: "text", nullable: false),
                    BirthYearPeriod = table.Column<string>(type: "numeric", nullable: false),
                    Gender = table.Column<short>(type: "integer", nullable: false),
                    Mass = table.Column<string>(type: "text", nullable: false),
                    Height = table.Column<string>(type: "text", nullable: false),
                    EyeColor = table.Column<string>(type: "text", nullable: false),
                    SkinColor = table.Column<string>(type: "text", nullable: false),
                    HairColor = table.Column<string>(type: "text", nullable: false),
                    HomeWorldId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "fk_Planets_Characters",
                        column: x => x.HomeWorldId,
                        principalTable: "Planets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanetFilm",
                columns: table => new
                {
                    PlanetId = table.Column<int>(type: "INTEGER", nullable: false),
                    FilmId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanetFilm", x => new { x.PlanetId, x.FilmId });
                    table.ForeignKey(
                        name: "fk_films_planets",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_planets_films",
                        column: x => x.PlanetId,
                        principalTable: "Planets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Starships",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "INTEGER", nullable: false),
                    HyperdriveRating = table.Column<decimal>(type: "real", nullable: false),
                    MaximumMegalights = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Starships", x => x.VehicleId);
                    table.ForeignKey(
                        name: "fk_Vechicles_Starships",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VeichleFilms",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "INTEGER", nullable: false),
                    FilmId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VeichleFilms", x => new { x.FilmId, x.VehicleId });
                    table.ForeignKey(
                        name: "FK_VeichleFilms_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VeichleFilms_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterFilms",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "INTEGER", nullable: false),
                    FilmId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterFilms", x => new { x.CharacterId, x.FilmId });
                    table.ForeignKey(
                        name: "fk_characters_films",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_films_characters",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanetCharacters",
                columns: table => new
                {
                    PlanetId = table.Column<int>(type: "INTEGER", nullable: false),
                    CharacterId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanetCharacters", x => new { x.CharacterId, x.PlanetId });
                    table.ForeignKey(
                        name: "fk_Characters_PlanetCharacters",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_Planerts_PlanetCharacters",
                        column: x => x.PlanetId,
                        principalTable: "Planets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_CharacterFilms_FilmId",
                table: "CharacterFilms",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_HomeWorldId",
                table: "Characters",
                column: "HomeWorldId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanetCharacters_PlanetId",
                table: "PlanetCharacters",
                column: "PlanetId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanetFilm_FilmId",
                table: "PlanetFilm",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_StarshipFilms_StartshipId",
                table: "StarshipFilms",
                column: "StartshipId");

            migrationBuilder.CreateIndex(
                name: "IX_VeichleFilms_VehicleId",
                table: "VeichleFilms",
                column: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterFilms");

            migrationBuilder.DropTable(
                name: "PlanetCharacters");

            migrationBuilder.DropTable(
                name: "PlanetFilm");

            migrationBuilder.DropTable(
                name: "StarshipFilms");

            migrationBuilder.DropTable(
                name: "VeichleFilms");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Starships");

            migrationBuilder.DropTable(
                name: "Films");

            migrationBuilder.DropTable(
                name: "Planets");

            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
