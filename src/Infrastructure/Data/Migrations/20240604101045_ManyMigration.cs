using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Microsoft.eShopWeb.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ManyMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventEventLocations_EventLocation_EventLocationsId",
                table: "EventEventLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_EventEventLocations_Event_EventsId",
                table: "EventEventLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_EventEventTypes_EventTypes_EventTypesId",
                table: "EventEventTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_EventEventTypes_Event_EventsId",
                table: "EventEventTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventEventTypes",
                table: "EventEventTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventEventLocations",
                table: "EventEventLocations");

            migrationBuilder.RenameTable(
                name: "EventEventTypes",
                newName: "EventEventType");

            migrationBuilder.RenameTable(
                name: "EventEventLocations",
                newName: "EventEventLocation");

            migrationBuilder.RenameIndex(
                name: "IX_EventEventTypes_EventsId",
                table: "EventEventType",
                newName: "IX_EventEventType_EventsId");

            migrationBuilder.RenameIndex(
                name: "IX_EventEventLocations_EventsId",
                table: "EventEventLocation",
                newName: "IX_EventEventLocation_EventsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventEventType",
                table: "EventEventType",
                columns: new[] { "EventTypesId", "EventsId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventEventLocation",
                table: "EventEventLocation",
                columns: new[] { "EventLocationsId", "EventsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_EventEventLocation_EventLocation_EventLocationsId",
                table: "EventEventLocation",
                column: "EventLocationsId",
                principalTable: "EventLocation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventEventLocation_Event_EventsId",
                table: "EventEventLocation",
                column: "EventsId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventEventType_EventTypes_EventTypesId",
                table: "EventEventType",
                column: "EventTypesId",
                principalTable: "EventTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventEventType_Event_EventsId",
                table: "EventEventType",
                column: "EventsId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventEventLocation_EventLocation_EventLocationsId",
                table: "EventEventLocation");

            migrationBuilder.DropForeignKey(
                name: "FK_EventEventLocation_Event_EventsId",
                table: "EventEventLocation");

            migrationBuilder.DropForeignKey(
                name: "FK_EventEventType_EventTypes_EventTypesId",
                table: "EventEventType");

            migrationBuilder.DropForeignKey(
                name: "FK_EventEventType_Event_EventsId",
                table: "EventEventType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventEventType",
                table: "EventEventType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventEventLocation",
                table: "EventEventLocation");

            migrationBuilder.RenameTable(
                name: "EventEventType",
                newName: "EventEventTypes");

            migrationBuilder.RenameTable(
                name: "EventEventLocation",
                newName: "EventEventLocations");

            migrationBuilder.RenameIndex(
                name: "IX_EventEventType_EventsId",
                table: "EventEventTypes",
                newName: "IX_EventEventTypes_EventsId");

            migrationBuilder.RenameIndex(
                name: "IX_EventEventLocation_EventsId",
                table: "EventEventLocations",
                newName: "IX_EventEventLocations_EventsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventEventTypes",
                table: "EventEventTypes",
                columns: new[] { "EventTypesId", "EventsId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventEventLocations",
                table: "EventEventLocations",
                columns: new[] { "EventLocationsId", "EventsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_EventEventLocations_EventLocation_EventLocationsId",
                table: "EventEventLocations",
                column: "EventLocationsId",
                principalTable: "EventLocation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventEventLocations_Event_EventsId",
                table: "EventEventLocations",
                column: "EventsId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventEventTypes_EventTypes_EventTypesId",
                table: "EventEventTypes",
                column: "EventTypesId",
                principalTable: "EventTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventEventTypes_Event_EventsId",
                table: "EventEventTypes",
                column: "EventsId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
