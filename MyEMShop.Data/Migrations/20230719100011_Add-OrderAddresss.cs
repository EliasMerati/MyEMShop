using Microsoft.EntityFrameworkCore.Migrations;

namespace MyEMShop.Data.Migrations
{
    public partial class AddOrderAddresss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OrderCity",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrderOstan",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrderPhoneNumber",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrderPostalCode",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderCity",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderOstan",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderPhoneNumber",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderPostalCode",
                table: "Orders");
        }
    }
}
