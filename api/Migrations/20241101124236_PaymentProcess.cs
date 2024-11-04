using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class PaymentProcess : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09bab0fd-4ad7-4886-8a84-ec14dc60dd4f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5150ec8c-e8e2-4892-8ae0-8d775264f5ff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1392c77-50b9-40d2-ad1d-5749050b7fe0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c84bfd0d-ae7b-4141-9696-da118b99a690");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e972fa5c-a3af-473c-9243-e9856dcc13ba");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "112f78b6-84c3-40ca-927e-c49ab0256e27", null, "Executive", "EXECUTIVE" },
                    { "2c657b9f-be40-4137-9b23-998364b0353e", null, "Admin", "ADMIN" },
                    { "a6ab14fb-841e-47a0-a4e9-48de63bedc5a", null, "Employee", "EMPLOYEE" },
                    { "abd98fdc-2e4e-4267-b04b-e703a2fba364", null, "User", "USER" },
                    { "d48d46a9-92aa-4f72-b7dd-5ac99c9aae44", null, "SuperUser", "SUPERUSER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "112f78b6-84c3-40ca-927e-c49ab0256e27");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c657b9f-be40-4137-9b23-998364b0353e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6ab14fb-841e-47a0-a4e9-48de63bedc5a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abd98fdc-2e4e-4267-b04b-e703a2fba364");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d48d46a9-92aa-4f72-b7dd-5ac99c9aae44");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "09bab0fd-4ad7-4886-8a84-ec14dc60dd4f", null, "Admin", "ADMIN" },
                    { "5150ec8c-e8e2-4892-8ae0-8d775264f5ff", null, "SuperUser", "SUPERUSER" },
                    { "c1392c77-50b9-40d2-ad1d-5749050b7fe0", null, "User", "USER" },
                    { "c84bfd0d-ae7b-4141-9696-da118b99a690", null, "Employee", "EMPLOYEE" },
                    { "e972fa5c-a3af-473c-9243-e9856dcc13ba", null, "Executive", "EXECUTIVE" }
                });
        }
    }
}
