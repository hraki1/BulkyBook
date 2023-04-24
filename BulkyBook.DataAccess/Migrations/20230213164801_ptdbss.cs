using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BullyBook_ECS.Migrations
{
    public partial class ptdbss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CoverTypeId",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverTypeId",
                table: "products");
        }
    }
}
