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
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    TemperatureThreshold = table.Column<double>(type: "REAL", nullable: false),
                    Month = table.Column<int>(type: "INTEGER", nullable: false),
                    Duration = table.Column<int>(type: "INTEGER", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", maxLength: 8, nullable: false),
                    Planting = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ExpectedHarvestDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ActualHarvestDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Amount = table.Column<double>(type: "REAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crops", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Crops");
        }
    }
}
