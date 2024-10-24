using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class updatecolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_VehicleModels_VehicleId",
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

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "VehicleModels",
                newName: "VehicleModelId");

            migrationBuilder.RenameColumn(
                name: "VehicleId",
                table: "Bookings",
                newName: "VehicleModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_VehicleId",
                table: "Bookings",
                newName: "IX_Bookings_VehicleModelId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1dd3391e-fa08-4b5f-8d21-a2807b93c46e", null, "Admin", "ADMIN" },
                    { "1f66be2c-fb2e-4fa2-8585-b60196dbb77f", null, "Executive", "EXECUTIVE" },
                    { "21b377e5-3f6b-4989-90b5-271cd02156d2", null, "Employee", "EMPLOYEE" },
                    { "5e8339bb-f2d7-4365-93f9-c1f14baff8e6", null, "User", "USER" },
                    { "6b4654d2-23d2-4f3b-af80-bb8c1d445175", null, "SuperUser", "SUPERUSER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_VehicleModels_VehicleModelId",
                table: "Bookings",
                column: "VehicleModelId",
                principalTable: "VehicleModels",
                principalColumn: "VehicleModelId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_VehicleModels_VehicleModelId",
                table: "Bookings");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1dd3391e-fa08-4b5f-8d21-a2807b93c46e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f66be2c-fb2e-4fa2-8585-b60196dbb77f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "21b377e5-3f6b-4989-90b5-271cd02156d2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e8339bb-f2d7-4365-93f9-c1f14baff8e6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b4654d2-23d2-4f3b-af80-bb8c1d445175");

            migrationBuilder.RenameColumn(
                name: "VehicleModelId",
                table: "VehicleModels",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "VehicleModelId",
                table: "Bookings",
                newName: "VehicleId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_VehicleModelId",
                table: "Bookings",
                newName: "IX_Bookings_VehicleId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_VehicleModels_VehicleId",
                table: "Bookings",
                column: "VehicleId",
                principalTable: "VehicleModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
