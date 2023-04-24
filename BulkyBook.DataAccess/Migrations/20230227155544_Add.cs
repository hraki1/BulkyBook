using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BullyBook_ECS.Migrations
{
    public partial class Add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderDetail_orderHeaders_OrderHeaderId",
                table: "orderDetail");

            migrationBuilder.DropIndex(
                name: "IX_orderDetail_OrderHeaderId",
                table: "orderDetail");

            migrationBuilder.DropColumn(
                name: "OrderHeaderId",
                table: "orderDetail");

            migrationBuilder.CreateIndex(
                name: "IX_orderDetail_OrderId",
                table: "orderDetail",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_orderDetail_orderHeaders_OrderId",
                table: "orderDetail",
                column: "OrderId",
                principalTable: "orderHeaders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderDetail_orderHeaders_OrderId",
                table: "orderDetail");

            migrationBuilder.DropIndex(
                name: "IX_orderDetail_OrderId",
                table: "orderDetail");

            migrationBuilder.AddColumn<int>(
                name: "OrderHeaderId",
                table: "orderDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_orderDetail_OrderHeaderId",
                table: "orderDetail",
                column: "OrderHeaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_orderDetail_orderHeaders_OrderHeaderId",
                table: "orderDetail",
                column: "OrderHeaderId",
                principalTable: "orderHeaders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
