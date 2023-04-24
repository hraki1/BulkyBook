using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BullyBook_ECS.Migrations
{
    public partial class fhhf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderHeaders_AspNetUsers_ApplicationUserId1",
                table: "orderHeaders");

            migrationBuilder.DropIndex(
                name: "IX_orderHeaders_ApplicationUserId1",
                table: "orderHeaders");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "orderHeaders");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "orderHeaders",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_orderHeaders_ApplicationUserId",
                table: "orderHeaders",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_orderHeaders_AspNetUsers_ApplicationUserId",
                table: "orderHeaders",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderHeaders_AspNetUsers_ApplicationUserId",
                table: "orderHeaders");

            migrationBuilder.DropIndex(
                name: "IX_orderHeaders_ApplicationUserId",
                table: "orderHeaders");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "orderHeaders",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "orderHeaders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_orderHeaders_ApplicationUserId1",
                table: "orderHeaders",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_orderHeaders_AspNetUsers_ApplicationUserId1",
                table: "orderHeaders",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
