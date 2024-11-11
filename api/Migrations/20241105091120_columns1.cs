using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class columns1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2abcb290-1782-41c9-baa3-15f5bdb31b0f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9ede0e68-8cc4-4afd-a51a-c29dc50e5332");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a29f6d5b-7694-47e6-8c38-9eedfaaacd38");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bcf5a598-2db1-4e73-854b-be94343e5e47");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff69ba82-5b03-4b39-9bdf-c1dad29f9d6f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "409215f6-df51-4a74-8e54-cebc76dda926", null, "Executive", "EXECUTIVE" },
                    { "5ba3b92a-7c11-405f-be4b-590ed812cd6b", null, "SuperUser", "SUPERUSER" },
                    { "68c4e844-708d-4484-ab37-57c4b63b97d0", null, "User", "USER" },
                    { "cf8ec253-2a42-4ae3-9be9-83349a5bc516", null, "Admin", "ADMIN" },
                    { "dd7aab77-7fbc-4846-9c1b-94a2e15c0e5b", null, "Employee", "EMPLOYEE" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "409215f6-df51-4a74-8e54-cebc76dda926");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ba3b92a-7c11-405f-be4b-590ed812cd6b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68c4e844-708d-4484-ab37-57c4b63b97d0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf8ec253-2a42-4ae3-9be9-83349a5bc516");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd7aab77-7fbc-4846-9c1b-94a2e15c0e5b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2abcb290-1782-41c9-baa3-15f5bdb31b0f", null, "Admin", "ADMIN" },
                    { "9ede0e68-8cc4-4afd-a51a-c29dc50e5332", null, "Employee", "EMPLOYEE" },
                    { "a29f6d5b-7694-47e6-8c38-9eedfaaacd38", null, "Executive", "EXECUTIVE" },
                    { "bcf5a598-2db1-4e73-854b-be94343e5e47", null, "User", "USER" },
                    { "ff69ba82-5b03-4b39-9bdf-c1dad29f9d6f", null, "SuperUser", "SUPERUSER" }
                });
        }
    }
}
