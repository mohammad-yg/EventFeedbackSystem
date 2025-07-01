using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventFeedbackSystem.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class AddSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "DateTime", "Description", "IsDeleted", "Location", "Title" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 6, 29, 4, 27, 12, 494, DateTimeKind.Utc).AddTicks(9742), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", false, "Tehran", "Event 1" },
                    { 2L, new DateTime(2025, 7, 1, 4, 27, 12, 494, DateTimeKind.Utc).AddTicks(9750), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", false, "Tehran", "Event 2" },
                    { 3L, new DateTime(2025, 7, 2, 4, 27, 12, 494, DateTimeKind.Utc).AddTicks(9752), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", false, "Tehran", "Event 3" },
                    { 4L, new DateTime(2025, 7, 3, 4, 27, 12, 494, DateTimeKind.Utc).AddTicks(9753), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", false, "Tehran", "Event 4" },
                    { 5L, new DateTime(2025, 7, 4, 4, 27, 12, 494, DateTimeKind.Utc).AddTicks(9754), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", false, "Tehran", "Event 5" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 5L);
        }
    }
}
