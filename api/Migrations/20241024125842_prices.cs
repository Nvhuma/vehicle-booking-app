using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class prices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1dd3391e-fa08-4b5f-8d21-a2807b93c46e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f66be2c-fb2e-4fa2-8585-b60196dbb77f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "21b377e5-3f6b-4989-90b5-271cd02156d2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e8339bb-f2d7-4365-93f9-c1f14baff8e6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b4654d2-23d2-4f3b-af80-bb8c1d445175");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Bookings",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Bookings");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1dd3391e-fa08-4b5f-8d21-a2807b93c46e", null, "Admin", "ADMIN" },
                    { "1f66be2c-fb2e-4fa2-8585-b60196dbb77f", null, "Executive", "EXECUTIVE" },
                    { "21b377e5-3f6b-4989-90b5-271cd02156d2", null, "Employee", "EMPLOYEE" },
                    { "5e8339bb-f2d7-4365-93f9-c1f14baff8e6", null, "User", "USER" },
                    { "6b4654d2-23d2-4f3b-af80-bb8c1d445175", null, "SuperUser", "SUPERUSER" }
                });
        }
    }
}
