using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class DobAndCitizenshipToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "077bdbd4-57fb-46f8-9c8d-63cfe4c7843f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41a8ccab-732f-4fd8-b2ab-009a0791519b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "50e93ef3-d2c0-4a94-947d-c20902b9f7ba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8bceadc5-b56b-49f4-b900-0d327b7e3d91");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df371f23-346a-4a7a-88a0-dda71f33e232");

            migrationBuilder.AddColumn<string>(
                name: "CitizenshipStatus",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4ac68686-3a45-415a-a1ac-8a1ba8efe9bb", null, "Employee", "EMPLOYEE" },
                    { "613d4e70-8a09-447a-b1bc-4b534e3d2351", null, "SuperUser", "SUPERUSER" },
                    { "a187d278-84e4-4b86-a08f-05c2fcfbc8ce", null, "Executive", "EXECUTIVE" },
                    { "a2460fd6-9bdd-4d82-ac5f-3281197813dd", null, "Admin", "ADMIN" },
                    { "bedff37c-29ad-4831-bd7b-2db3bc6517b4", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4ac68686-3a45-415a-a1ac-8a1ba8efe9bb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "613d4e70-8a09-447a-b1bc-4b534e3d2351");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a187d278-84e4-4b86-a08f-05c2fcfbc8ce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2460fd6-9bdd-4d82-ac5f-3281197813dd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bedff37c-29ad-4831-bd7b-2db3bc6517b4");

            migrationBuilder.DropColumn(
                name: "CitizenshipStatus",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "077bdbd4-57fb-46f8-9c8d-63cfe4c7843f", null, "Admin", "ADMIN" },
                    { "41a8ccab-732f-4fd8-b2ab-009a0791519b", null, "User", "USER" },
                    { "50e93ef3-d2c0-4a94-947d-c20902b9f7ba", null, "Executive", "EXECUTIVE" },
                    { "8bceadc5-b56b-49f4-b900-0d327b7e3d91", null, "SuperUser", "SUPERUSER" },
                    { "df371f23-346a-4a7a-88a0-dda71f33e232", null, "Employee", "EMPLOYEE" }
                });
        }
    }
}
