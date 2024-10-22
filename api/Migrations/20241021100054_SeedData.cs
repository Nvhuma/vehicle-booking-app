using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TimeSlots_BookingId",
                table: "TimeSlots");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0cfb039e-ed3c-4ef7-b14a-15495dbb81c5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ac0ee27-3acf-4dd0-92ac-7bb746223873");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d281727-616c-421a-93fc-087e1f71ecca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "75e5828a-0475-46d1-9446-3766cd386d53");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6457915-37c7-4456-9184-1f1a912b473d");

            migrationBuilder.AlterColumn<int>(
                name: "BookingId",
                table: "TimeSlots",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "06e2a8f6-88a9-48b3-81ee-31ae67bceb43", null, "Admin", "ADMIN" },
                    { "17ede88f-b837-4356-b143-3fbd3017e427", null, "Executive", "EXECUTIVE" },
                    { "55c1d937-f588-47de-a0e6-533db6813094", null, "User", "USER" },
                    { "7128d79f-93cf-4e82-8046-cf281bfef3d9", null, "Employee", "EMPLOYEE" },
                    { "9e057244-75b1-4f8b-9995-00b09067785f", null, "SuperUser", "SUPERUSER" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Name" },
                values: new object[,]
                {
                    { 1, "Vusi Vusimusi" },
                    { 2, "Jane Smith" },
                    { 3, "Bob Johnson" }
                });

            migrationBuilder.InsertData(
                table: "TimeSlots",
                columns: new[] { "Id", "BookingId", "EmployeeId", "EndTime", "IsAvailable", "ServiceTypeId", "StartTime" },
                values: new object[,]
                {
                    { 1, null, 1, new DateTime(2023, 3, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), true, 1, new DateTime(2023, 3, 15, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, null, 2, new DateTime(2023, 3, 15, 11, 0, 0, 0, DateTimeKind.Unspecified), true, 2, new DateTime(2023, 3, 15, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, null, 3, new DateTime(2023, 3, 15, 12, 0, 0, 0, DateTimeKind.Unspecified), true, 3, new DateTime(2023, 3, 15, 11, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlots_BookingId",
                table: "TimeSlots",
                column: "BookingId",
                unique: true,
                filter: "[BookingId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TimeSlots_BookingId",
                table: "TimeSlots");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "06e2a8f6-88a9-48b3-81ee-31ae67bceb43");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "17ede88f-b837-4356-b143-3fbd3017e427");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "55c1d937-f588-47de-a0e6-533db6813094");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7128d79f-93cf-4e82-8046-cf281bfef3d9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e057244-75b1-4f8b-9995-00b09067785f");

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 3);

            migrationBuilder.AlterColumn<int>(
                name: "BookingId",
                table: "TimeSlots",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0cfb039e-ed3c-4ef7-b14a-15495dbb81c5", null, "Employee", "EMPLOYEE" },
                    { "1ac0ee27-3acf-4dd0-92ac-7bb746223873", null, "Executive", "EXECUTIVE" },
                    { "6d281727-616c-421a-93fc-087e1f71ecca", null, "User", "USER" },
                    { "75e5828a-0475-46d1-9446-3766cd386d53", null, "Admin", "ADMIN" },
                    { "e6457915-37c7-4456-9184-1f1a912b473d", null, "SuperUser", "SUPERUSER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlots_BookingId",
                table: "TimeSlots",
                column: "BookingId",
                unique: true);
        }
    }
}
