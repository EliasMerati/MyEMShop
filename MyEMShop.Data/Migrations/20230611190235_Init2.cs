using Microsoft.EntityFrameworkCore.Migrations;

namespace MyEMShop.Data.Migrations
{
    public partial class Init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "PermissionId", "ParentId", "PermissionTitle" },
                values: new object[] { 10, 1, "لیست کاربران حذف شده " });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "PermissionId", "ParentId", "PermissionTitle" },
                values: new object[] { 11, 1, "بازگردانی کاربر " });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "RP_Id", "PermissionId", "RoleId" },
                values: new object[] { 10, 10, 1 });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "RP_Id", "PermissionId", "RoleId" },
                values: new object[] { 11, 11, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "RP_Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "RP_Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 11);
        }
    }
}
