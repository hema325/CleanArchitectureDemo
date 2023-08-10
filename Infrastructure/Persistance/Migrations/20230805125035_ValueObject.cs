using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ValueObject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, "5d020992-ea6c-482c-85e2-16f68c09be1b" });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "5d020992-ea6c-482c-85e2-16f68c09be1b");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "HashedPassword", "IsEmailConfirmed", "LastName", "UserName" },
                values: new object[] { "226a3729-5953-48d1-a706-9867c3952d23", "admin@gmail.com", "ibrahim", "AQAAAAEAACcQAAAAENeMSOa0HC+0lMGmtxKbglqsBbM5yQeP4hf48AL+D6bxdmTJOXyrC1CueaWOedLQZw==", true, "Moawad", "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, "226a3729-5953-48d1-a706-9867c3952d23" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "5d020992-ea6c-482c-85e2-16f68c09be1b", "admin@gmail.com", "ibrahim", "AQAAAAEAACcQAAAAELFw7FOqmPFQZeGKxsD7LtwUg76xJFpgAKGZ4DdsGRlddKnXj/Yn2dCTilThoSrKXQ==", true, "Moawad", "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, "5d020992-ea6c-482c-85e2-16f68c09be1b" });
        }
    }
}
