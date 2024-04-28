using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Staris.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Adjusting_DataTypes_Planet_Character : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SurfaceWater",
                table: "Planets",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<decimal>(
                name: "Gravity",
                table: "Planets",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "BirthYearPeriod",
                table: "Characters",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SurfaceWater",
                table: "Planets",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "numeric");

            migrationBuilder.AlterColumn<int>(
                name: "Gravity",
                table: "Planets",
                type: "integer",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<string>(
                name: "BirthYearPeriod",
                table: "Characters",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "numeric");
        }
    }
}
