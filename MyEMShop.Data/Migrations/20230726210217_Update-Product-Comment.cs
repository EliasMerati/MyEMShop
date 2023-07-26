using Microsoft.EntityFrameworkCore.Migrations;

namespace MyEMShop.Data.Migrations
{
    public partial class UpdateProductComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdminRead",
                table: "ProductComments");

            migrationBuilder.AddColumn<int>(
                name: "AdminRead",
                table: "ProductComments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminRead",
                table: "ProductComments");

            migrationBuilder.AddColumn<bool>(
                name: "IsAdminRead",
                table: "ProductComments",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
