using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class relationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5e017ad0-a09c-4f94-b206-b8cdff525ad4", null, "Employee", "EMPLOYEE" },
                    { "696f1ccd-e05b-46bf-8f62-e472a10f89de", null, "SuperUser", "SUPERUSER" },
                    { "95226450-a258-499c-b013-110004b9136d", null, "Admin", "ADMIN" },
                    { "b65e4bcc-1e8b-4681-9618-6daa12f1f85e", null, "Executive", "EXECUTIVE" },
                    { "b6ef7621-7aef-4a5f-a508-dc7a0ce55066", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_AppUserId",
                table: "Bookings",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_AspNetUsers_AppUserId",
                table: "Bookings",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_AspNetUsers_AppUserId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_AppUserId",
                table: "Bookings");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e017ad0-a09c-4f94-b206-b8cdff525ad4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "696f1ccd-e05b-46bf-8f62-e472a10f89de");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95226450-a258-499c-b013-110004b9136d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b65e4bcc-1e8b-4681-9618-6daa12f1f85e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b6ef7621-7aef-4a5f-a508-dc7a0ce55066");

            migrationBuilder.DropColumn(
                name: "AppUserId",
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
    }
}
