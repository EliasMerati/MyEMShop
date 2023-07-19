using Microsoft.EntityFrameworkCore.Migrations;

namespace MyEMShop.Data.Migrations
{
    public partial class AddOrderAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OrderAddress",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductTitle",
                table: "Products",
                column: "ProductTitle");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductTitle",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OrderAddress",
                table: "Orders");
        }
    }
}
