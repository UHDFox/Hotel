using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VisitorId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_RoomId",
                table: "Orders",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_VisitorId",
                table: "Orders",
                column: "VisitorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Rooms_RoomId",
                table: "Orders",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Visitors_VisitorId",
                table: "Orders",
                column: "VisitorId",
                principalTable: "Visitors",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Rooms_RoomId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Visitors_VisitorId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_RoomId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_VisitorId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "VisitorId",
                table: "Orders");
        }
    }
}
