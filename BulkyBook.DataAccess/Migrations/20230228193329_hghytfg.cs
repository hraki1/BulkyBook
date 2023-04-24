using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BullyBook_ECS.Migrations
{
    public partial class hghytfg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShoppingDate",
                table: "orderHeaders",
                newName: "ShippingDate");

            migrationBuilder.RenameColumn(
                name: "PaymentIntendId",
                table: "orderHeaders",
                newName: "PaymentIntentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShippingDate",
                table: "orderHeaders",
                newName: "ShoppingDate");

            migrationBuilder.RenameColumn(
                name: "PaymentIntentId",
                table: "orderHeaders",
                newName: "PaymentIntendId");
        }
    }
}
