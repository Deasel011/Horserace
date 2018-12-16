using Microsoft.EntityFrameworkCore.Migrations;

namespace HorseRaceApiCore.Migrations
{
    public partial class myFirstMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Horses_Games_GameId",
                table: "Horses");

            migrationBuilder.AlterColumn<int>(
                name: "GameId",
                table: "Horses",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Horses_Games_GameId",
                table: "Horses",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Horses_Games_GameId",
                table: "Horses");

            migrationBuilder.AlterColumn<int>(
                name: "GameId",
                table: "Horses",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Horses_Games_GameId",
                table: "Horses",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
