using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class ModifyRooms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Services_ROOMNO",
                table: "Services");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ROOMNO",
                table: "Services",
                column: "ROOMNO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Services_ROOMNO",
                table: "Services");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ROOMNO",
                table: "Services",
                column: "ROOMNO",
                unique: true,
                filter: "[ROOMNO] IS NOT NULL");
        }
    }
}
