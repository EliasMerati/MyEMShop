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
                values: new object[] { 12, 1, "مدیریت محصولات " });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "PermissionId", "ParentId", "PermissionTitle" },
                values: new object[] { 13, 12, "افزودن محصول" });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "RP_Id", "PermissionId", "RoleId" },
                values: new object[] { 12, 12, 1 });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "RP_Id", "PermissionId", "RoleId" },
                values: new object[] { 13, 13, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "RP_Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "RP_Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 12);
        }
    }
}
