using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Staris.Infra.Migrations
{
    /// <inheritdoc />
    public partial class changing_character_fields_to_string : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_Planets_Characters",
                table: "Characters");

            migrationBuilder.AlterColumn<int>(
                name: "HomeWorldId",
                table: "Characters",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "fk_Planets_Characters",
                table: "Characters",
                column: "HomeWorldId",
                principalTable: "Planets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_Planets_Characters",
                table: "Characters");

            migrationBuilder.AlterColumn<int>(
                name: "HomeWorldId",
                table: "Characters",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_Planets_Characters",
                table: "Characters",
                column: "HomeWorldId",
                principalTable: "Planets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
