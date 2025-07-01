using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventFeedbackSystem.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class IndexAndUniqUserEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateTime",
                value: new DateTime(2025, 6, 30, 22, 28, 44, 811, DateTimeKind.Utc).AddTicks(4452));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DateTime",
                value: new DateTime(2025, 7, 2, 22, 28, 44, 811, DateTimeKind.Utc).AddTicks(4463));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DateTime",
                value: new DateTime(2025, 7, 3, 22, 28, 44, 811, DateTimeKind.Utc).AddTicks(4466));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4L,
                column: "DateTime",
                value: new DateTime(2025, 7, 4, 22, 28, 44, 811, DateTimeKind.Utc).AddTicks(4467));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 5L,
                column: "DateTime",
                value: new DateTime(2025, 7, 5, 22, 28, 44, 811, DateTimeKind.Utc).AddTicks(4468));

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

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
        }
    }
}
