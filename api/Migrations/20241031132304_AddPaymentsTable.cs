using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AddPaymentsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c9db58b-f9d2-4ecb-8aa5-ba28061c25ee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57592596-0c39-41c4-8481-bf4d88292d9a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7347d4ef-91a0-4324-8c68-47c346b0754b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc0483ed-98d8-4356-b6bc-ec109270dac0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb0d7c36-c7db-4763-8efb-aa4def45c526");

            migrationBuilder.CreateTable(
                name: "PaymentRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardExpiry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardCvc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentRequests", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentRequests");

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
                    { "3c9db58b-f9d2-4ecb-8aa5-ba28061c25ee", null, "Admin", "ADMIN" },
                    { "57592596-0c39-41c4-8481-bf4d88292d9a", null, "Employee", "EMPLOYEE" },
                    { "7347d4ef-91a0-4324-8c68-47c346b0754b", null, "User", "USER" },
                    { "bc0483ed-98d8-4356-b6bc-ec109270dac0", null, "Executive", "EXECUTIVE" },
                    { "cb0d7c36-c7db-4763-8efb-aa4def45c526", null, "SuperUser", "SUPERUSER" }
                });
        }
    }
}
