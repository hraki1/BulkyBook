using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BullyBook_ECS.Migrations
{
    public partial class addcounttoorderdetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "orderDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "orderDetail");
        }
    }
}
