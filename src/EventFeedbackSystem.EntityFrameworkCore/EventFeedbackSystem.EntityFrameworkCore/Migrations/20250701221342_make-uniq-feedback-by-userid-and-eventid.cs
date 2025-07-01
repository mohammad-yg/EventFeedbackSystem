using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventFeedbackSystem.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class makeuniqfeedbackbyuseridandeventid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_EventId_UserId",
                table: "Feedbacks");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateTime",
                value: new DateTime(2025, 6, 30, 22, 13, 42, 50, DateTimeKind.Utc).AddTicks(9391));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DateTime",
                value: new DateTime(2025, 7, 2, 22, 13, 42, 50, DateTimeKind.Utc).AddTicks(9399));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DateTime",
                value: new DateTime(2025, 7, 3, 22, 13, 42, 50, DateTimeKind.Utc).AddTicks(9403));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4L,
                column: "DateTime",
                value: new DateTime(2025, 7, 4, 22, 13, 42, 50, DateTimeKind.Utc).AddTicks(9405));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 5L,
                column: "DateTime",
                value: new DateTime(2025, 7, 5, 22, 13, 42, 50, DateTimeKind.Utc).AddTicks(9408));

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_EventId_UserId",
                table: "Feedbacks",
                columns: new[] { "EventId", "UserId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_EventId_UserId",
                table: "Feedbacks");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateTime",
                value: new DateTime(2025, 6, 30, 21, 16, 38, 946, DateTimeKind.Utc).AddTicks(7946));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DateTime",
                value: new DateTime(2025, 7, 2, 21, 16, 38, 946, DateTimeKind.Utc).AddTicks(7955));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DateTime",
                value: new DateTime(2025, 7, 3, 21, 16, 38, 946, DateTimeKind.Utc).AddTicks(7958));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4L,
                column: "DateTime",
                value: new DateTime(2025, 7, 4, 21, 16, 38, 946, DateTimeKind.Utc).AddTicks(7959));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 5L,
                column: "DateTime",
                value: new DateTime(2025, 7, 5, 21, 16, 38, 946, DateTimeKind.Utc).AddTicks(7960));

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_EventId_UserId",
                table: "Feedbacks",
                columns: new[] { "EventId", "UserId" });
        }
    }
}
