using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EventFeedbackSystem.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class addfeedback : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    EventId = table.Column<long>(type: "bigint", nullable: false),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    Comment = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_UserId",
                table: "Feedbacks",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feedbacks");

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
        }
    }
}
