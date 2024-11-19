using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class SeedingPrices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "CardNumber",
                table: "CardDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CardHolder",
                table: "CardDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CVV",
                table: "CardDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ServiceType",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AdditionalNotes",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IdentityNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CitizenshipStatus",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "67090a36-c2b3-442a-bc09-a4cb33f25a67", null, "User", "USER" },
                    { "c970cc8b-8396-4373-a16c-096e79675d4f", null, "Executive", "EXECUTIVE" },
                    { "d5265308-cde2-4b09-974e-59cd5d843ba1", null, "Employee", "EMPLOYEE" },
                    { "ddf24b72-6283-4a1d-a94c-95d9208ee900", null, "Admin", "ADMIN" },
                    { "ee9b7f85-52cc-4c82-9cd0-7f5a4182c37a", null, "SuperUser", "SUPERUSER" }
                });

            migrationBuilder.UpdateData(
                table: "ServiceTypes",
                keyColumn: "ServiceTypeId",
                keyValue: 2,
                column: "Name",
                value: "Tyre Rotation");

            migrationBuilder.InsertData(
                table: "ServiceTypes",
                columns: new[] { "ServiceTypeId", "Description", "Name" },
                values: new object[,]
                {
                    { 4, null, " Minor Service" },
                    { 5, null, "Major Service" },
                    { 6, null, "Windscreen Change" }
                });

            migrationBuilder.InsertData(
                table: "ServicePrices",
                columns: new[] { "Id", "Price", "ServiceTypeId", "VehicleModelId" },
                values: new object[,]
                {
                    { 7, 49.99m, 6, 4 },
                    { 8, 11199.99m, 5, 4 },
                    { 9, 1199.99m, 4, 9 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "67090a36-c2b3-442a-bc09-a4cb33f25a67");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c970cc8b-8396-4373-a16c-096e79675d4f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5265308-cde2-4b09-974e-59cd5d843ba1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ddf24b72-6283-4a1d-a94c-95d9208ee900");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee9b7f85-52cc-4c82-9cd0-7f5a4182c37a");

            migrationBuilder.DeleteData(
                table: "ServicePrices",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ServicePrices",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ServicePrices",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "ServiceTypeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "ServiceTypeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "ServiceTypeId",
                keyValue: 6);

            migrationBuilder.AlterColumn<string>(
                name: "CardNumber",
                table: "CardDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CardHolder",
                table: "CardDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CVV",
                table: "CardDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ServiceType",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AdditionalNotes",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "IdentityNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CitizenshipStatus",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

            migrationBuilder.UpdateData(
                table: "ServiceTypes",
                keyColumn: "ServiceTypeId",
                keyValue: 2,
                column: "Name",
                value: "Tire Rotation");
        }
    }
}
