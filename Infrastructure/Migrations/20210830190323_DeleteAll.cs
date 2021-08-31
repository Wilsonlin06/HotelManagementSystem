using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class DeleteAll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "RoomTypes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoomTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RTDESC = table.Column<string>(type: "varchar(20)", nullable: true),
                    Rent = table.Column<decimal>(type: "money", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RTCODE = table.Column<int>(type: "int", nullable: true),
                    STATUS = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_RoomTypes_RTCODE",
                        column: x => x.RTCODE,
                        principalTable: "RoomTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ADDRESS = table.Column<string>(type: "varchar(100)", nullable: true),
                    ADVANCE = table.Column<decimal>(type: "money", nullable: true),
                    BookingDays = table.Column<int>(type: "int", nullable: true),
                    CNAME = table.Column<string>(type: "varchar(20)", nullable: true),
                    CHECKIN = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EMAIL = table.Column<string>(type: "varchar(40)", nullable: true),
                    PHONE = table.Column<string>(type: "varchar(20)", nullable: true),
                    ROOMNO = table.Column<int>(type: "int", nullable: true),
                    TotlePERSONS = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Rooms_ROOMNO",
                        column: x => x.ROOMNO,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AMOUNT = table.Column<decimal>(type: "money", nullable: true),
                    ROOMNO = table.Column<int>(type: "int", nullable: true),
                    SDESC = table.Column<string>(type: "varchar(50)", nullable: true),
                    ServiceDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Services_Rooms_ROOMNO",
                        column: x => x.ROOMNO,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ROOMNO",
                table: "Customers",
                column: "ROOMNO");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RTCODE",
                table: "Rooms",
                column: "RTCODE");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ROOMNO",
                table: "Services",
                column: "ROOMNO");
        }
    }
}
