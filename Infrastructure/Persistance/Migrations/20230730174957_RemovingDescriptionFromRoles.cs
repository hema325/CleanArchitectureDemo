using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemovingDescriptionFromRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, "b1646e53-3600-44d9-9a61-a8ab8d1c519e" });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "b1646e53-3600-44d9-9a61-a8ab8d1c519e");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Roles");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "HashedPassword", "IsEmailConfirmed", "LastName", "UserName" },
                values: new object[] { "a388bfd7-640e-4755-89e7-496614f992bf", "admin@gmail.com", "ibrahim", "AQAAAAEAACcQAAAAELV1pcazE3g56MGVcguYQx8+XtVwIY6VwOshu2f+gpenWN9fZwCPxcWTHVGvzhuhYg==", true, "Moawad", "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, "a388bfd7-640e-4755-89e7-496614f992bf" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, "a388bfd7-640e-4755-89e7-496614f992bf" });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "a388bfd7-640e-4755-89e7-496614f992bf");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Roles",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Person with admin role can do any thing on this api");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Person with User role can do specific things on this api");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "HashedPassword", "IsEmailConfirmed", "LastName", "UserName" },
                values: new object[] { "b1646e53-3600-44d9-9a61-a8ab8d1c519e", "admin@gmail.com", "ibrahim", "AQAAAAEAACcQAAAAENYWmZZmD+6uJdgc+9pgg6VUCQlr6XlPkC4GqtrRHCm1e153Ga2Wk6XOymopQsyLeA==", true, "Moawad", "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, "b1646e53-3600-44d9-9a61-a8ab8d1c519e" });
        }
    }
}
