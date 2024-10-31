using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AddBalanceToCardDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15a2a459-3fba-4f6e-a1c0-bc7ccb6f51ea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8fc37c66-38c0-41a6-8d27-48de7d42795b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9828dfd8-9cf3-4665-b169-b720c9883b37");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bdaed4f5-80d9-4efd-9a87-4f365faa1758");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6eb9d25-48ed-4f3d-b213-247504f982b0");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "CardDetails",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Balance",
                table: "CardDetails");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Employee",
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
                    { "15a2a459-3fba-4f6e-a1c0-bc7ccb6f51ea", null, "SuperUser", "SUPERUSER" },
                    { "8fc37c66-38c0-41a6-8d27-48de7d42795b", null, "Admin", "ADMIN" },
                    { "9828dfd8-9cf3-4665-b169-b720c9883b37", null, "Executive", "EXECUTIVE" },
                    { "bdaed4f5-80d9-4efd-9a87-4f365faa1758", null, "User", "USER" },
                    { "c6eb9d25-48ed-4f3d-b213-247504f982b0", null, "Employee", "EMPLOYEE" }
                });
        }
    }
}
