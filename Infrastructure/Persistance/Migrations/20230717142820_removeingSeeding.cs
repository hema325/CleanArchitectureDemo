using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class removeingSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "689fb34f-08f0-4d2e-a1a6-5981e539a65d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7f305255-ccd6-4bd9-94df-a2379dffc019");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetRoles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetRoles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "689fb34f-08f0-4d2e-a1a6-5981e539a65d", "c28ddbfb-5e3a-4c79-9ee0-c775957d3790", "ApplicationRole", "Admin", "ADMIN" },
                    { "7f305255-ccd6-4bd9-94df-a2379dffc019", "8ea82e8d-bd2a-4e9f-bb14-d3377a545cad", "ApplicationRole", "User", "USER" }
                });
        }
    }
}
