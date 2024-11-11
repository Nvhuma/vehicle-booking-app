using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class SeedEmployeeData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "16a710fc-d60a-4a99-9cd6-e3ab25b819cc", null, "Admin", "ADMIN" },
                    { "2caee593-45f7-4243-9f3e-4e62114e82c6", null, "Executive", "EXECUTIVE" },
                    { "36a07f22-d922-4b17-afc4-ece81c8e6f26", null, "SuperUser", "SUPERUSER" },
                    { "493b95e7-01fa-492b-88c4-850b8aacc780", null, "User", "USER" },
                    { "6c75d445-3401-4b10-99f6-f39021465d0f", null, "Employee", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "EmployeeId", "IsAvailable", "Name", "ServiceSpecialty", "ServiceTypeId", "ServiceTypes" },
                values: new object[] { 4, true, "John Doe", "General Mechanic", null, "[\"oil change\",\"tire rotation\"]" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "16a710fc-d60a-4a99-9cd6-e3ab25b819cc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2caee593-45f7-4243-9f3e-4e62114e82c6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36a07f22-d922-4b17-afc4-ece81c8e6f26");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "493b95e7-01fa-492b-88c4-850b8aacc780");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c75d445-3401-4b10-99f6-f39021465d0f");

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 4);

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
    }
}
