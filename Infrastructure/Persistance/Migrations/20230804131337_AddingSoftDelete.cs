using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddingSoftDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, "f4663938-ad5b-4a3d-8068-fe2610568e19" });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "f4663938-ad5b-4a3d-8068-fe2610568e19");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Items",
                newName: "ImagePath");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedOn",
                table: "Items",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Items",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Items",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "DeletedBy", "DeletedOn", "ModifiedOn" },
                values: new object[] { null, null, null, null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "HashedPassword", "IsEmailConfirmed", "LastName", "UserName" },
                values: new object[] { "5d020992-ea6c-482c-85e2-16f68c09be1b", "admin@gmail.com", "ibrahim", "AQAAAAEAACcQAAAAELFw7FOqmPFQZeGKxsD7LtwUg76xJFpgAKGZ4DdsGRlddKnXj/Yn2dCTilThoSrKXQ==", true, "Moawad", "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, "5d020992-ea6c-482c-85e2-16f68c09be1b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, "5d020992-ea6c-482c-85e2-16f68c09be1b" });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "5d020992-ea6c-482c-85e2-16f68c09be1b");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "Items",
                newName: "ImageUrl");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedOn",
                table: "Items",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Items",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "HashedPassword", "IsEmailConfirmed", "LastName", "UserName" },
                values: new object[] { "f4663938-ad5b-4a3d-8068-fe2610568e19", "admin@gmail.com", "ibrahim", "AQAAAAEAACcQAAAAEEJnzZreh9CNRbsKHrSRHIjlk7F9W9d6C0u46jI3Sn2DvHKGEDXo+7yfNjjOjrsePQ==", true, "Moawad", "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, "f4663938-ad5b-4a3d-8068-fe2610568e19" });
        }
    }
}
