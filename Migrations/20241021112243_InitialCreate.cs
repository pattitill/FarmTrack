using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmTrack.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Crops",
                columns: table => new
                {
                    CropId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CropName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    CropType = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    PlantingDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    GrowthDurationInDays = table.Column<int>(type: "INTEGER", nullable: false),
                    ExpectedHarvestDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    RequiresFertilizing = table.Column<bool>(type: "INTEGER", nullable: false),
                    FertilizingReminder = table.Column<DateTime>(type: "TEXT", nullable: true),
                    RequiresWatering = table.Column<bool>(type: "INTEGER", nullable: false),
                    WateringReminder = table.Column<DateTime>(type: "TEXT", nullable: true),
                    RequiresPestControl = table.Column<bool>(type: "INTEGER", nullable: false),
                    PestControlReminder = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crops", x => x.CropId);
                });

            migrationBuilder.CreateTable(
                name: "GrowthHistory",
                columns: table => new
                {
                    GrowthHistoryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RecordDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: false),
                    CropId = table.Column<int>(type: "INTEGER", nullable: false)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GrowthHistory");

            migrationBuilder.DropTable(
                name: "Crops");
        }
    }
}
