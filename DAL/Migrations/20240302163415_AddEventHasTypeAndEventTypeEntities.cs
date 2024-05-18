using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace crm_minimal.Migrations
{
    /// <inheritdoc />
    public partial class AddEventHasTypeAndEventTypeEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdEvent",
                table: "Events",
                newName: "Id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Events",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "EventTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventHasTypes",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "integer", nullable: false),
                    TypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventHasTypes", x => new { x.EventId, x.TypeId });
                    table.ForeignKey(
                        name: "FK_EventHasTypes_EventTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "EventTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventHasTypes_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventHasTypes_TypeId",
                table: "EventHasTypes",
                column: "TypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventHasTypes");

            migrationBuilder.DropTable(
                name: "EventTypes");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Events",
                newName: "IdEvent");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Events",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }
    }
}
