using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddingItemImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, "f169a472-b76e-4af3-92c5-7b21191db531" });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "f169a472-b76e-4af3-92c5-7b21191db531");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Items",
                type: "varchar(450)",
                unicode: false,
                maxLength: 450,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: null);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "HashedPassword", "IsEmailConfirmed", "LastName", "UserName" },
                values: new object[] { "f4663938-ad5b-4a3d-8068-fe2610568e19", "admin@gmail.com", "ibrahim", "AQAAAAEAACcQAAAAEEJnzZreh9CNRbsKHrSRHIjlk7F9W9d6C0u46jI3Sn2DvHKGEDXo+7yfNjjOjrsePQ==", true, "Moawad", "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, "f4663938-ad5b-4a3d-8068-fe2610568e19" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, "f4663938-ad5b-4a3d-8068-fe2610568e19" });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "f4663938-ad5b-4a3d-8068-fe2610568e19");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Items");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "HashedPassword", "IsEmailConfirmed", "LastName", "UserName" },
                values: new object[] { "f169a472-b76e-4af3-92c5-7b21191db531", "admin@gmail.com", "ibrahim", "AQAAAAEAACcQAAAAEOF+YsqljQSQ4N1zdvAUkWZne8yv5ZuLePgBLTAHQTZAerfRqQ68Aw3kQ2sMEsQz4g==", true, "Moawad", "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, "f169a472-b76e-4af3-92c5-7b21191db531" });
        }
    }
}
