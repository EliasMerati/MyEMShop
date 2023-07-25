using Microsoft.EntityFrameworkCore.Migrations;

namespace MyEMShop.Data.Migrations
{
    public partial class Permissions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "PermissionId", "ParentId", "PermissionTitle" },
                values: new object[,]
                {
                    { 14, 12, "ویرایش محصول" },
                    { 15, 12, "حذف محصول" },
                    { 16, 1, "مدیریت گروه ها" },
                    { 23, 1, "مدیریت سفارشات" },
                    { 28, 1, "مدیریت تخفیف ها" },
                    { 32, 1, "مدیریت مالیات " }
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "PermissionId", "ParentId", "PermissionTitle" },
                values: new object[,]
                {
                    { 25, 23, "آماده ارسال" },
                    { 33, 32, "افزودن مالیات " },
                    { 17, 16, "افزودن گروه" },
                    { 18, 16, "ویرایش گروه" },
                    { 19, 16, "حذف گروه" },
                    { 20, 16, "افزودن زیرگروه" },
                    { 21, 16, "ویرایش زیرگروه" },
                    { 22, 16, "حذف زیرگروه" },
                    { 24, 23, "در حال پردازش" },
                    { 34, 32, "ویرایش مالیات " },
                    { 26, 23, "ارسال شده" },
                    { 27, 23, "لغو شده" },
                    { 31, 28, "ویرایش تخفیف " },
                    { 29, 28, "لیست تخفیف ها" },
                    { 30, 28, "افزودن تخفیف " }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "RP_Id", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 28, 28, 1 },
                    { 14, 14, 1 },
                    { 16, 16, 1 },
                    { 15, 15, 1 },
                    { 23, 23, 1 },
                    { 32, 32, 1 }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "RP_Id", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 17, 17, 1 },
                    { 18, 18, 1 },
                    { 19, 19, 1 },
                    { 20, 20, 1 },
                    { 21, 21, 1 },
                    { 22, 22, 1 },
                    { 24, 24, 1 },
                    { 25, 25, 1 },
                    { 26, 26, 1 },
                    { 27, 27, 1 },
                    { 29, 29, 1 },
                    { 30, 30, 1 },
                    { 31, 31, 1 },
                    { 33, 33, 1 },
                    { 34, 34, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "RP_Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "RP_Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "RP_Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "RP_Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "RP_Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "RP_Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "RP_Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "RP_Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "RP_Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "RP_Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "RP_Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "RP_Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "RP_Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "RP_Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "RP_Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "RP_Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "RP_Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "RP_Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "RP_Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "RP_Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "RP_Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "PermissionId",
                keyValue: 32);
        }
    }
}
