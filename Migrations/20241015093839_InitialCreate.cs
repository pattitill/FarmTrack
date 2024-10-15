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
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crops", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RealCrops",
                columns: table => new
                {
                    RealCropId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PlantingDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ExpectedHarvestDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    HarvestDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    QuantityHarvested = table.Column<int>(type: "INTEGER", nullable: true),
                    CropId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealCrops", x => x.RealCropId);
                    table.ForeignKey(
                        name: "FK_RealCrops_Crops_CropId",
                        column: x => x.CropId,
                        principalTable: "Crops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RealCrops_CropId",
                table: "RealCrops",
                column: "CropId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RealCrops");

            migrationBuilder.DropTable(
                name: "Crops");
        }
    }
}
