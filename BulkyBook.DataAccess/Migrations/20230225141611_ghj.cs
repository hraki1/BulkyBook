using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BullyBook_ECS.Migrations
{
    public partial class ghj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_shoppingCarts_products_ProductId",
                table: "shoppingCarts");

            migrationBuilder.DropColumn(
                name: "ProdcutId",
                table: "shoppingCarts");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "shoppingCarts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_shoppingCarts_products_ProductId",
                table: "shoppingCarts",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_shoppingCarts_products_ProductId",
                table: "shoppingCarts");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "shoppingCarts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ProdcutId",
                table: "shoppingCarts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_shoppingCarts_products_ProductId",
                table: "shoppingCarts",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id");
        }
    }
}
