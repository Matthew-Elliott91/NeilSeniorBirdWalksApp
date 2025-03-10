using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NeilSeniorBirdWalks.Migrations
{
    /// <inheritdoc />
    public partial class AddedTourSeasonModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tours_Seasons_SeasonId",
                table: "Tours");

            migrationBuilder.DropIndex(
                name: "IX_Tours_LocationId_SeasonId",
                table: "Tours");

            migrationBuilder.DropIndex(
                name: "IX_Tours_SeasonId",
                table: "Tours");

            migrationBuilder.DropColumn(
                name: "SeasonId",
                table: "Tours");

            migrationBuilder.CreateTable(
                name: "TourSeasons",
                columns: table => new
                {
                    TourId = table.Column<int>(type: "int", nullable: false),
                    SeasonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourSeasons", x => new { x.TourId, x.SeasonId });
                    table.ForeignKey(
                        name: "FK_TourSeasons_Seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Seasons",
                        principalColumn: "SeasonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TourSeasons_Tours_TourId",
                        column: x => x.TourId,
                        principalTable: "Tours",
                        principalColumn: "TourId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tours_LocationId",
                table: "Tours",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_TourSeasons_SeasonId",
                table: "TourSeasons",
                column: "SeasonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TourSeasons");

            migrationBuilder.DropIndex(
                name: "IX_Tours_LocationId",
                table: "Tours");

            migrationBuilder.AddColumn<int>(
                name: "SeasonId",
                table: "Tours",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tours_LocationId_SeasonId",
                table: "Tours",
                columns: new[] { "LocationId", "SeasonId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tours_SeasonId",
                table: "Tours",
                column: "SeasonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tours_Seasons_SeasonId",
                table: "Tours",
                column: "SeasonId",
                principalTable: "Seasons",
                principalColumn: "SeasonId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
