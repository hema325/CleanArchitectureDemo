using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fixingRolesSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "689fb34f-08f0-4d2e-a1a6-5981e539a65d", "c28ddbfb-5e3a-4c79-9ee0-c775957d3790", "ApplicationRole", "Admin", "ADMIN" },
                    { "7f305255-ccd6-4bd9-94df-a2379dffc019", "8ea82e8d-bd2a-4e9f-bb14-d3377a545cad", "ApplicationRole", "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "689fb34f-08f0-4d2e-a1a6-5981e539a65d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7f305255-ccd6-4bd9-94df-a2379dffc019");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "42a63167-f943-47cb-b2c2-ba129aabb613", "ca034983-fa3b-43c1-a15c-56f03d3b174d", "ApplicationRole", "Admin", null },
                    { "f875a9be-2220-4ede-b227-7a5108ac6eae", "00d36098-78d1-4997-aca7-96341a8a4ab7", "ApplicationRole", "User", null }
                });
        }
    }
}
