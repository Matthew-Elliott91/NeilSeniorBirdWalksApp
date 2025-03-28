using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NeilSeniorBirdWalks.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedTourModel2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 28, 14, 5, 33, 911, DateTimeKind.Utc).AddTicks(3818));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 28, 14, 5, 33, 911, DateTimeKind.Utc).AddTicks(3821));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 28, 14, 5, 33, 911, DateTimeKind.Utc).AddTicks(3824));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 28, 14, 2, 57, 723, DateTimeKind.Utc).AddTicks(122));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 28, 14, 2, 57, 723, DateTimeKind.Utc).AddTicks(127));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 3, 28, 14, 2, 57, 723, DateTimeKind.Utc).AddTicks(129));
        }
    }
}
