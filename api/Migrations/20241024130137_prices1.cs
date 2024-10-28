using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class prices1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4647865e-d042-41e3-9891-acda783cd198");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "52f6270c-6ed8-4e5c-aa3d-345d678a93e6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7c0170be-9c15-4cc2-9596-e1b554717f76");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7d4ed4f-aada-4d17-9fb6-cb0aba442b20");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd19e85d-b501-4b04-b277-e1f6f71af74d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2bd3e6d4-bad6-4ed8-8420-60c79a178850", null, "Admin", "ADMIN" },
                    { "3de4d097-9c07-4384-9366-f7e4a8106cc9", null, "SuperUser", "SUPERUSER" },
                    { "e7c88889-9d4a-4717-9098-2a3115b4452d", null, "Executive", "EXECUTIVE" },
                    { "ecf94189-8921-4aee-9034-68fa5daa47c9", null, "Employee", "EMPLOYEE" },
                    { "f8678066-f553-4c06-b13f-83b58530d1ef", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2bd3e6d4-bad6-4ed8-8420-60c79a178850");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3de4d097-9c07-4384-9366-f7e4a8106cc9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e7c88889-9d4a-4717-9098-2a3115b4452d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ecf94189-8921-4aee-9034-68fa5daa47c9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8678066-f553-4c06-b13f-83b58530d1ef");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4647865e-d042-41e3-9891-acda783cd198", null, "Admin", "ADMIN" },
                    { "52f6270c-6ed8-4e5c-aa3d-345d678a93e6", null, "User", "USER" },
                    { "7c0170be-9c15-4cc2-9596-e1b554717f76", null, "Employee", "EMPLOYEE" },
                    { "a7d4ed4f-aada-4d17-9fb6-cb0aba442b20", null, "Executive", "EXECUTIVE" },
                    { "cd19e85d-b501-4b04-b277-e1f6f71af74d", null, "SuperUser", "SUPERUSER" }
                });
        }
    }
}
