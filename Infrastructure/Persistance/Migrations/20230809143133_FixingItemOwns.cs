using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixingItemOwns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, "226a3729-5953-48d1-a706-9867c3952d23" });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "226a3729-5953-48d1-a706-9867c3952d23");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "HashedPassword", "IsEmailConfirmed", "LastName", "UserName" },
                values: new object[] { "fcbe5f38-6a97-48d5-9b5b-d40af01765b5", "admin@gmail.com", "ibrahim", "AQAAAAEAACcQAAAAEB8VN8XFv7mkdqNdJMwPjjKFPA8Ux4qx4Zc58MeqgpxQdw6tJW4nfeB4P3Yi0MWh9Q==", true, "Moawad", "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, "fcbe5f38-6a97-48d5-9b5b-d40af01765b5" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, "fcbe5f38-6a97-48d5-9b5b-d40af01765b5" });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "fcbe5f38-6a97-48d5-9b5b-d40af01765b5");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "HashedPassword", "IsEmailConfirmed", "LastName", "UserName" },
                values: new object[] { "226a3729-5953-48d1-a706-9867c3952d23", "admin@gmail.com", "ibrahim", "AQAAAAEAACcQAAAAENeMSOa0HC+0lMGmtxKbglqsBbM5yQeP4hf48AL+D6bxdmTJOXyrC1CueaWOedLQZw==", true, "Moawad", "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, "226a3729-5953-48d1-a706-9867c3952d23" });
        }
    }
}
