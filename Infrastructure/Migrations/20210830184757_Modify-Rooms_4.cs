using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class ModifyRooms_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Services_ROOMNO",
                table: "Services",
                column: "ROOMNO");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Rooms_ROOMNO",
                table: "Services",
                column: "ROOMNO",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Rooms_ROOMNO",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_ROOMNO",
                table: "Services");
        }
    }
}
