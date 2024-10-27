using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmTrack.Migrations
{
    /// <inheritdoc />
    public partial class UpdateReminderModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reminders_Crops_CropId",
                table: "Reminders");

            migrationBuilder.DropIndex(
                name: "IX_Reminders_CropId",
                table: "Reminders");

            migrationBuilder.DropColumn(
                name: "CropId",
                table: "Reminders");

            migrationBuilder.AddColumn<string>(
                name: "CropName",
                table: "Reminders",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CropName",
                table: "Reminders");

            migrationBuilder.AddColumn<int>(
                name: "CropId",
                table: "Reminders",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reminders_CropId",
                table: "Reminders",
                column: "CropId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reminders_Crops_CropId",
                table: "Reminders",
                column: "CropId",
                principalTable: "Crops",
                principalColumn: "CropId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
