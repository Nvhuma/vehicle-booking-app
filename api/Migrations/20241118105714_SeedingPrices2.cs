using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class SeedingPrices2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ServicePrices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5068c0c3-6027-4136-b0c8-df210166782c", null, "User", "USER" },
                    { "8967d982-0037-4ee4-a108-47bc5ddda258", null, "Executive", "EXECUTIVE" },
                    { "a7117b61-50aa-4c13-8577-22cd325c8292", null, "SuperUser", "SUPERUSER" },
                    { "b8012b4e-15b8-411d-ab97-4c2f775901d5", null, "Employee", "EMPLOYEE" },
                    { "db88b273-de80-4c42-bd03-0c3b681eadc2", null, "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "ServicePrices",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Oil change");

            migrationBuilder.UpdateData(
                table: "ServicePrices",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Tyre Rotation");

            migrationBuilder.UpdateData(
                table: "ServicePrices",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Oil change");

            migrationBuilder.UpdateData(
                table: "ServicePrices",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Oil change");

            migrationBuilder.UpdateData(
                table: "ServicePrices",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Break Repair");

            migrationBuilder.UpdateData(
                table: "ServicePrices",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Break Repair");

            migrationBuilder.UpdateData(
                table: "ServicePrices",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Windscreen Change");

            migrationBuilder.UpdateData(
                table: "ServicePrices",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Major Service");

            migrationBuilder.UpdateData(
                table: "ServicePrices",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "Minor Service");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5068c0c3-6027-4136-b0c8-df210166782c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8967d982-0037-4ee4-a108-47bc5ddda258");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7117b61-50aa-4c13-8577-22cd325c8292");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8012b4e-15b8-411d-ab97-4c2f775901d5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db88b273-de80-4c42-bd03-0c3b681eadc2");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ServicePrices");

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
        }
    }
}
