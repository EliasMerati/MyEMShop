using Microsoft.EntityFrameworkCore.Migrations;

namespace MyEMShop.Data.Migrations
{
    public partial class AddWalletAndWalletType1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "WalletTypes",
                keyColumn: "TypeId",
                keyValue: 1,
                column: "TypeTitle",
                value: "بستانکار");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "WalletTypes",
                keyColumn: "TypeId",
                keyValue: 1,
                column: "TypeTitle",
                value: "یستانکار");
        }
    }
}
