using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootballDirectory.Migrations
{
    /// <inheritdoc />
    public partial class Removestadiumnavproperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Team_Stadium_StadiumID1",
                table: "Team");

            migrationBuilder.DropIndex(
                name: "IX_Team_StadiumID1",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "StadiumID1",
                table: "Team");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StadiumID1",
                table: "Team",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Team_StadiumID1",
                table: "Team",
                column: "StadiumID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Team_Stadium_StadiumID1",
                table: "Team",
                column: "StadiumID1",
                principalTable: "Stadium",
                principalColumn: "StadiumID");
        }
    }
}
