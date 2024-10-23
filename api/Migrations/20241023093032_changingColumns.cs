using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class changingColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_AspNetUsers_AppUserId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Employee_EmployeeId1",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_AppUserId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_EmployeeId1",
                table: "Bookings");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "559fda8f-b36c-4d01-94e7-c812fb4f81dd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "637b411f-3be0-4e14-8d48-b00764d0da10");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b031811-864e-42cf-8646-6dc031056845");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb9df9c6-b42a-421d-8e9b-bd20052695df");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e23e2290-8d21-4b3c-881e-3acbdf022902");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "EmployeeId1",
                table: "Bookings");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1a1d24cd-c973-469f-9876-0ab8a85632ed", null, "Admin", "ADMIN" },
                    { "833289d8-c470-49d6-b6d8-d0ac8699c16c", null, "SuperUser", "SUPERUSER" },
                    { "bd2f321a-a0a8-4204-b5b7-28de041ab0af", null, "Executive", "EXECUTIVE" },
                    { "d87d4fc8-7df6-4949-b276-74bcee05b065", null, "User", "USER" },
                    { "e2103293-270b-4986-a7e1-503b1f3b5afd", null, "Employee", "EMPLOYEE" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a1d24cd-c973-469f-9876-0ab8a85632ed");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "833289d8-c470-49d6-b6d8-d0ac8699c16c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd2f321a-a0a8-4204-b5b7-28de041ab0af");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d87d4fc8-7df6-4949-b276-74bcee05b065");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2103293-270b-4986-a7e1-503b1f3b5afd");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Bookings",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId1",
                table: "Bookings",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "559fda8f-b36c-4d01-94e7-c812fb4f81dd", null, "Admin", "ADMIN" },
                    { "637b411f-3be0-4e14-8d48-b00764d0da10", null, "Employee", "EMPLOYEE" },
                    { "9b031811-864e-42cf-8646-6dc031056845", null, "User", "USER" },
                    { "cb9df9c6-b42a-421d-8e9b-bd20052695df", null, "Executive", "EXECUTIVE" },
                    { "e23e2290-8d21-4b3c-881e-3acbdf022902", null, "SuperUser", "SUPERUSER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_AppUserId",
                table: "Bookings",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_EmployeeId1",
                table: "Bookings",
                column: "EmployeeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_AspNetUsers_AppUserId",
                table: "Bookings",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Employee_EmployeeId1",
                table: "Bookings",
                column: "EmployeeId1",
                principalTable: "Employee",
                principalColumn: "EmployeeId");
        }
    }
}
