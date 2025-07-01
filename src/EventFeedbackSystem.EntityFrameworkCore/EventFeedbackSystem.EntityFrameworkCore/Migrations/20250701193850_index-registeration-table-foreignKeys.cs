using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventFeedbackSystem.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class indexregisterationtableforeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Registerations_UserId",
                table: "Registerations");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateTime",
                value: new DateTime(2025, 6, 30, 19, 38, 48, 355, DateTimeKind.Utc).AddTicks(6712));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DateTime",
                value: new DateTime(2025, 7, 2, 19, 38, 48, 355, DateTimeKind.Utc).AddTicks(6723));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DateTime",
                value: new DateTime(2025, 7, 3, 19, 38, 48, 355, DateTimeKind.Utc).AddTicks(6726));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4L,
                column: "DateTime",
                value: new DateTime(2025, 7, 4, 19, 38, 48, 355, DateTimeKind.Utc).AddTicks(6727));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 5L,
                column: "DateTime",
                value: new DateTime(2025, 7, 5, 19, 38, 48, 355, DateTimeKind.Utc).AddTicks(6729));

            migrationBuilder.CreateIndex(
                name: "IX_Registerations_UserId_EventId",
                table: "Registerations",
                columns: new[] { "UserId", "EventId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Registerations_UserId_EventId",
                table: "Registerations");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateTime",
                value: new DateTime(2025, 6, 29, 21, 20, 54, 909, DateTimeKind.Utc).AddTicks(8086));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DateTime",
                value: new DateTime(2025, 7, 1, 21, 20, 54, 909, DateTimeKind.Utc).AddTicks(8095));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DateTime",
                value: new DateTime(2025, 7, 2, 21, 20, 54, 909, DateTimeKind.Utc).AddTicks(8097));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4L,
                column: "DateTime",
                value: new DateTime(2025, 7, 3, 21, 20, 54, 909, DateTimeKind.Utc).AddTicks(8099));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 5L,
                column: "DateTime",
                value: new DateTime(2025, 7, 4, 21, 20, 54, 909, DateTimeKind.Utc).AddTicks(8100));

            migrationBuilder.CreateIndex(
                name: "IX_Registerations_UserId",
                table: "Registerations",
                column: "UserId");
        }
    }
}
