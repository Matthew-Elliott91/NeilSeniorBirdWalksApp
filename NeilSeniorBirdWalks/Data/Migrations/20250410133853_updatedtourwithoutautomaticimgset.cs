using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NeilSeniorBirdWalks.Migrations
{
    /// <inheritdoc />
    public partial class updatedtourwithoutautomaticimgset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 4, 10, 13, 38, 52, 840, DateTimeKind.Utc).AddTicks(9513));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 4, 10, 13, 38, 52, 840, DateTimeKind.Utc).AddTicks(9516));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 4, 10, 13, 38, 52, 840, DateTimeKind.Utc).AddTicks(9518));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 4, 10, 13, 7, 30, 106, DateTimeKind.Utc).AddTicks(3972));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 4, 10, 13, 7, 30, 106, DateTimeKind.Utc).AddTicks(3976));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 4, 10, 13, 7, 30, 106, DateTimeKind.Utc).AddTicks(3979));
        }
    }
}
