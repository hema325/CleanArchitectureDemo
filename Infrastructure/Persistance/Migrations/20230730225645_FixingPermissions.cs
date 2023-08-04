using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixingPermissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, "d29419a4-5139-4461-81a3-65fa59abb5f2" });

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "d29419a4-5139-4461-81a3-65fa59abb5f2");

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "HashedPassword", "IsEmailConfirmed", "LastName", "UserName" },
                values: new object[] { "f169a472-b76e-4af3-92c5-7b21191db531", "admin@gmail.com", "ibrahim", "AQAAAAEAACcQAAAAEOF+YsqljQSQ4N1zdvAUkWZne8yv5ZuLePgBLTAHQTZAerfRqQ68Aw3kQ2sMEsQz4g==", true, "Moawad", "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, "f169a472-b76e-4af3-92c5-7b21191db531" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, "f169a472-b76e-4af3-92c5-7b21191db531" });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "f169a472-b76e-4af3-92c5-7b21191db531");

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "ReadWriteUpdate" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "HashedPassword", "IsEmailConfirmed", "LastName", "UserName" },
                values: new object[] { "d29419a4-5139-4461-81a3-65fa59abb5f2", "admin@gmail.com", "ibrahim", "AQAAAAEAACcQAAAAEPREDEHWYhlx+kuqngkGM+QF3R7e6VqTCx/cFWr4/l1q4ItCjKl2ttZVpJTFw0xPGQ==", true, "Moawad", "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 3, 1 });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, "d29419a4-5139-4461-81a3-65fa59abb5f2" });
        }
    }
}
