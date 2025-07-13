using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventFeedbackSystem.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class migseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "DateTime", "Description", "IsDeleted", "Location", "Title" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 6, 30, 22, 28, 44, 811, DateTimeKind.Utc).AddTicks(4452), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", false, "Tehran", "Event 1" },
                    { 2L, new DateTime(2025, 7, 2, 22, 28, 44, 811, DateTimeKind.Utc).AddTicks(4463), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", false, "Tehran", "Event 2" },
                    { 3L, new DateTime(2025, 7, 3, 22, 28, 44, 811, DateTimeKind.Utc).AddTicks(4466), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", false, "Tehran", "Event 3" },
                    { 4L, new DateTime(2025, 7, 4, 22, 28, 44, 811, DateTimeKind.Utc).AddTicks(4467), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", false, "Tehran", "Event 4" },
                    { 5L, new DateTime(2025, 7, 5, 22, 28, 44, 811, DateTimeKind.Utc).AddTicks(4468), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", false, "Tehran", "Event 5" }
                });
        }
    }
}
