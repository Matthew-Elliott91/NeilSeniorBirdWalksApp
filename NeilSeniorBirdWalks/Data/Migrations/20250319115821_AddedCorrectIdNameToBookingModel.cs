using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NeilSeniorBirdWalks.Migrations
{
    /// <inheritdoc />
    public partial class AddedCorrectIdNameToBookingModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_TourSchedules_TourScheduleID",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "TourScheduleID",
                table: "Bookings",
                newName: "TourScheduleId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_TourScheduleID",
                table: "Bookings",
                newName: "IX_Bookings_TourScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_TourSchedules_TourScheduleId",
                table: "Bookings",
                column: "TourScheduleId",
                principalTable: "TourSchedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_TourSchedules_TourScheduleId",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "TourScheduleId",
                table: "Bookings",
                newName: "TourScheduleID");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_TourScheduleId",
                table: "Bookings",
                newName: "IX_Bookings_TourScheduleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_TourSchedules_TourScheduleID",
                table: "Bookings",
                column: "TourScheduleID",
                principalTable: "TourSchedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
