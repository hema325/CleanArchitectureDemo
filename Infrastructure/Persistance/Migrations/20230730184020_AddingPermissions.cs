using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddingPermissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, "a388bfd7-640e-4755-89e7-496614f992bf" });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "a388bfd7-640e-4755-89e7-496614f992bf");

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RolePermissions",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    PermissionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissions", x => new { x.RoleId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_RolePermissions_Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePermissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "ReadOnly" },
                    { 2, "ReadWrite" },
                    { 3, "ReadWriteUpdate" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "HashedPassword", "IsEmailConfirmed", "LastName", "UserName" },
                values: new object[] { "d29419a4-5139-4461-81a3-65fa59abb5f2", "admin@gmail.com", "ibrahim", "AQAAAAEAACcQAAAAEPREDEHWYhlx+kuqngkGM+QF3R7e6VqTCx/cFWr4/l1q4ItCjKl2ttZVpJTFw0xPGQ==", true, "Moawad", "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 3, 1 },
                    { 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, "d29419a4-5139-4461-81a3-65fa59abb5f2" });

            migrationBuilder.CreateIndex(
                name: "IX_Permission_Name",
                table: "Permission",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_PermissionId",
                table: "RolePermissions",
                column: "PermissionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RolePermissions");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, "d29419a4-5139-4461-81a3-65fa59abb5f2" });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "d29419a4-5139-4461-81a3-65fa59abb5f2");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "HashedPassword", "IsEmailConfirmed", "LastName", "UserName" },
                values: new object[] { "a388bfd7-640e-4755-89e7-496614f992bf", "admin@gmail.com", "ibrahim", "AQAAAAEAACcQAAAAELV1pcazE3g56MGVcguYQx8+XtVwIY6VwOshu2f+gpenWN9fZwCPxcWTHVGvzhuhYg==", true, "Moawad", "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, "a388bfd7-640e-4755-89e7-496614f992bf" });
        }
    }
}
