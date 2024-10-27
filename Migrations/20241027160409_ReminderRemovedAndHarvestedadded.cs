using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmTrack.Migrations
{
    /// <inheritdoc />
    public partial class ReminderRemovedAndHarvestedadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GrowthHistory");

            migrationBuilder.DropColumn(
                name: "FertilizingReminder",
                table: "Crops");

            migrationBuilder.DropColumn(
                name: "PestControlReminder",
                table: "Crops");

            migrationBuilder.DropColumn(
                name: "RequiresFertilizing",
                table: "Crops");

            migrationBuilder.DropColumn(
                name: "RequiresPestControl",
                table: "Crops");

            migrationBuilder.DropColumn(
                name: "WateringReminder",
                table: "Crops");

            migrationBuilder.RenameColumn(
                name: "RequiresWatering",
                table: "Crops",
                newName: "Harvested");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Harvested",
                table: "Crops",
                newName: "RequiresWatering");

            migrationBuilder.AddColumn<DateTime>(
                name: "FertilizingReminder",
                table: "Crops",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PestControlReminder",
                table: "Crops",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RequiresFertilizing",
                table: "Crops",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RequiresPestControl",
                table: "Crops",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "WateringReminder",
                table: "Crops",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GrowthHistory",
                columns: table => new
                {
                    GrowthHistoryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CropId = table.Column<int>(type: "INTEGER", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: false),
                    RecordDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrowthHistory", x => x.GrowthHistoryId);
                    table.ForeignKey(
                        name: "FK_GrowthHistory_Crops_CropId",
                        column: x => x.CropId,
                        principalTable: "Crops",
                        principalColumn: "CropId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GrowthHistory_CropId",
                table: "GrowthHistory",
                column: "CropId");
        }
    }
}
