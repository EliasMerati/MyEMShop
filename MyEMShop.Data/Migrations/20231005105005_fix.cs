using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyEMShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "RegisterDate",
                value: new DateTime(2023, 10, 5, 14, 20, 4, 720, DateTimeKind.Local).AddTicks(3289));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "RegisterDate",
                value: new DateTime(2023, 9, 9, 13, 1, 46, 233, DateTimeKind.Local).AddTicks(5218));
        }
    }
}
