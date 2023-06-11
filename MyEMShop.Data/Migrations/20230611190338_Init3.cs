using Microsoft.EntityFrameworkCore.Migrations;

namespace MyEMShop.Data.Migrations
{
    public partial class Init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 10,
                column: "ParentId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 11,
                column: "ParentId",
                value: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 10,
                column: "ParentId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 11,
                column: "ParentId",
                value: 1);
        }
    }
}
