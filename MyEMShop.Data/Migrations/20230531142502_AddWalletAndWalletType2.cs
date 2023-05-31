using Microsoft.EntityFrameworkCore.Migrations;

namespace MyEMShop.Data.Migrations
{
    public partial class AddWalletAndWalletType2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "WalletTypes",
                keyColumn: "TypeId",
                keyValue: 1,
                column: "TypeTitle",
                value: "واریز");

            migrationBuilder.UpdateData(
                table: "WalletTypes",
                keyColumn: "TypeId",
                keyValue: 2,
                column: "TypeTitle",
                value: "برداشت");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "WalletTypes",
                keyColumn: "TypeId",
                keyValue: 1,
                column: "TypeTitle",
                value: "بستانکار");

            migrationBuilder.UpdateData(
                table: "WalletTypes",
                keyColumn: "TypeId",
                keyValue: 2,
                column: "TypeTitle",
                value: "بدهکار");
        }
    }
}
