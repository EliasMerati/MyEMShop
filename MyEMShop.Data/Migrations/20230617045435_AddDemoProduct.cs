using Microsoft.EntityFrameworkCore.Migrations;

namespace MyEMShop.Data.Migrations
{
    public partial class AddDemoProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductDemo",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductDemo",
                table: "Products");
        }
    }
}
