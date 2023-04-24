using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BullyBook_ECS.Migrations
{
    public partial class ptdbssh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_products_CoverTypeId",
                table: "products",
                column: "CoverTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_products_coverTypes_CoverTypeId",
                table: "products",
                column: "CoverTypeId",
                principalTable: "coverTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_coverTypes_CoverTypeId",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_CoverTypeId",
                table: "products");
        }
    }
}
