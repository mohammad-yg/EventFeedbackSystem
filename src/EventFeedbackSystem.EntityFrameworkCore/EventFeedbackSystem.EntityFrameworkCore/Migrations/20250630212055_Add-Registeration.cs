using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EventFeedbackSystem.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class AddRegisteration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Registerations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    EventId = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registerations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Registerations_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registerations_Users_UserId",
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
                name: "IX_Registerations_EventId",
                table: "Registerations",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Registerations_UserId",
                table: "Registerations",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registerations");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateTime",
                value: new DateTime(2025, 6, 29, 4, 27, 12, 494, DateTimeKind.Utc).AddTicks(9742));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DateTime",
                value: new DateTime(2025, 7, 1, 4, 27, 12, 494, DateTimeKind.Utc).AddTicks(9750));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DateTime",
                value: new DateTime(2025, 7, 2, 4, 27, 12, 494, DateTimeKind.Utc).AddTicks(9752));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4L,
                column: "DateTime",
                value: new DateTime(2025, 7, 3, 4, 27, 12, 494, DateTimeKind.Utc).AddTicks(9753));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 5L,
                column: "DateTime",
                value: new DateTime(2025, 7, 4, 4, 27, 12, 494, DateTimeKind.Utc).AddTicks(9754));
        }
    }
}
