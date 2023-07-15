using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class xx : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "200ac449-752b-4028-a614-a0caac5b6a14");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d0b56d4-79bd-4b26-a281-d074810e7c8a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "42a63167-f943-47cb-b2c2-ba129aabb613", "ca034983-fa3b-43c1-a15c-56f03d3b174d", "ApplicationRole", "Admin", null },
                    { "f875a9be-2220-4ede-b227-7a5108ac6eae", "00d36098-78d1-4997-aca7-96341a8a4ab7", "ApplicationRole", "User", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "42a63167-f943-47cb-b2c2-ba129aabb613");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f875a9be-2220-4ede-b227-7a5108ac6eae");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "200ac449-752b-4028-a614-a0caac5b6a14", "5aba54de-0e57-49ee-8f88-15d0727a7e90", "ApplicationRole", "Admin", null },
                    { "8d0b56d4-79bd-4b26-a281-d074810e7c8a", "0fad3414-3f2d-4830-9bf3-e6a60a331ebb", "ApplicationRole", "User", null }
                });
        }
    }
}
