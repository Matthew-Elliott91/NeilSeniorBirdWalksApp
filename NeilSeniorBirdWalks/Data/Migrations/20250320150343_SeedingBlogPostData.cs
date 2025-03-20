using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NeilSeniorBirdWalks.Migrations
{
    /// <inheritdoc />
    public partial class SeedingBlogPostData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BlogPosts",
                columns: new[] { "Id", "AdditionalImageUrls", "CreatedDate", "FeaturedImageUrl", "Slug", "Title" },
                values: new object[,]
                {
                    { 1, "[\"/Images/ToursHeaderImg.jpg\"]", new DateTime(2025, 3, 20, 15, 3, 43, 701, DateTimeKind.Utc).AddTicks(9559), "/Images/ToursHeaderImg.jpg", "first-blog-post", "First Blog Post" },
                    { 2, "[\"/Images/ToursHeaderImg.jpg\"]", new DateTime(2025, 3, 20, 15, 3, 43, 701, DateTimeKind.Utc).AddTicks(9563), "/Images/ToursHeaderImg.jpg", "second-blog-post", "Second Blog Post" },
                    { 3, "[\"/Images/ToursHeaderImg.jpg\"]", new DateTime(2025, 3, 20, 15, 3, 43, 701, DateTimeKind.Utc).AddTicks(9565), "/Images/ToursHeaderImg.jpg", "third-blog-post", "Third Blog Post" }
                });

            migrationBuilder.InsertData(
                table: "ContentSection",
                columns: new[] { "Id", "BlogPostId", "ImageUrl", "Text" },
                values: new object[,]
                {
                    { 1, 1, "/Images/ToursHeaderImg.jpg", "This is the first paragraph of the first blog post." },
                    { 2, 1, "/Images/ToursHeaderImg.jpg", "This is the second paragraph of the first blog post." },
                    { 3, 2, "/Images/ToursHeaderImg.jpg", "This is the first paragraph of the second blog post." },
                    { 4, 2, "/Images/ToursHeaderImg.jpg", "This is the second paragraph of the second blog post." },
                    { 5, 3, "/Images/ToursHeaderImg.jpg", "This is the first paragraph of the third blog post." },
                    { 6, 3, "/Images/ToursHeaderImg.jpg", "This is the second paragraph of the third blog post." }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ContentSection",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ContentSection",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ContentSection",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ContentSection",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ContentSection",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ContentSection",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
