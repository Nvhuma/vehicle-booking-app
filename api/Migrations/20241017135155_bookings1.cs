using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class bookings1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f761d1d-a1de-4243-8a9b-ca5459076d07");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3faffbc5-eb49-46e4-9fe6-c38841e8dee2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "43dea621-7fb8-4baa-a35c-a101823801b6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a409d490-7d8d-4f36-ae19-b937bb3f8a88");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea5eb7f3-21f3-4c3b-95b2-040ec21c10bb");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "05e9e889-c7e8-4df5-8d79-f1965edb98bd", null, "Executive", "EXECUTIVE" },
                    { "751869bc-1153-429e-b7e7-21fdd77bff1a", null, "User", "USER" },
                    { "98282b82-cee5-4651-af85-95e7eb1f7ab1", null, "Admin", "ADMIN" },
                    { "d6526b20-2f02-4694-b885-27639752bbe0", null, "Employee", "EMPLOYEE" },
                    { "e059dd2f-54fa-413b-ad06-f47fbe8fa12c", null, "SuperUser", "SUPERUSER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "05e9e889-c7e8-4df5-8d79-f1965edb98bd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "751869bc-1153-429e-b7e7-21fdd77bff1a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98282b82-cee5-4651-af85-95e7eb1f7ab1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d6526b20-2f02-4694-b885-27639752bbe0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e059dd2f-54fa-413b-ad06-f47fbe8fa12c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0f761d1d-a1de-4243-8a9b-ca5459076d07", null, "SuperUser", "SUPERUSER" },
                    { "3faffbc5-eb49-46e4-9fe6-c38841e8dee2", null, "User", "USER" },
                    { "43dea621-7fb8-4baa-a35c-a101823801b6", null, "Admin", "ADMIN" },
                    { "a409d490-7d8d-4f36-ae19-b937bb3f8a88", null, "Employee", "EMPLOYEE" },
                    { "ea5eb7f3-21f3-4c3b-95b2-040ec21c10bb", null, "Executive", "EXECUTIVE" }
                });
        }
    }
}
