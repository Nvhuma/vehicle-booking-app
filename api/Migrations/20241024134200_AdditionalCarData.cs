using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AdditionalCarData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "EmissionStandard",
                table: "VehicleModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HorsepowerRange",
                table: "VehicleModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MaxTowingCapacity",
                table: "VehicleModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TorqueRange",
                table: "VehicleModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Bookings",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "DriveTrains",
                columns: table => new
                {
                    DriveTrainId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriveTrainName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriveTrains", x => x.DriveTrainId);
                });

            migrationBuilder.CreateTable(
                name: "EngineTypes",
                columns: table => new
                {
                    EngineTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EngineTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EngineTypes", x => x.EngineTypeId);
                });

            migrationBuilder.CreateTable(
                name: "FuelTypes",
                columns: table => new
                {
                    FuelTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FuelTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelTypes", x => x.FuelTypeId);
                });

            migrationBuilder.CreateTable(
                name: "TransmissionTypes",
                columns: table => new
                {
                    TransmissionTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransmissionTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransmissionTypes", x => x.TransmissionTypeId);
                });

            migrationBuilder.CreateTable(
                name: "TrimLevels",
                columns: table => new
                {
                    TrimLevelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrimLevelName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrimLevels", x => x.TrimLevelId);
                });

            migrationBuilder.CreateTable(
                name: "VehicleModelDriveTrains",
                columns: table => new
                {
                    VehicleModelId = table.Column<int>(type: "int", nullable: false),
                    DriveTrainId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleModelDriveTrains", x => new { x.VehicleModelId, x.DriveTrainId });
                    table.ForeignKey(
                        name: "FK_VehicleModelDriveTrains_DriveTrains_DriveTrainId",
                        column: x => x.DriveTrainId,
                        principalTable: "DriveTrains",
                        principalColumn: "DriveTrainId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleModelDriveTrains_VehicleModels_VehicleModelId",
                        column: x => x.VehicleModelId,
                        principalTable: "VehicleModels",
                        principalColumn: "VehicleModelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleModelEngineTypes",
                columns: table => new
                {
                    VehicleModelId = table.Column<int>(type: "int", nullable: false),
                    EngineTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleModelEngineTypes", x => new { x.VehicleModelId, x.EngineTypeId });
                    table.ForeignKey(
                        name: "FK_VehicleModelEngineTypes_EngineTypes_EngineTypeId",
                        column: x => x.EngineTypeId,
                        principalTable: "EngineTypes",
                        principalColumn: "EngineTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleModelEngineTypes_VehicleModels_VehicleModelId",
                        column: x => x.VehicleModelId,
                        principalTable: "VehicleModels",
                        principalColumn: "VehicleModelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleModelFuelTypes",
                columns: table => new
                {
                    VehicleModelId = table.Column<int>(type: "int", nullable: false),
                    FuelTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleModelFuelTypes", x => new { x.VehicleModelId, x.FuelTypeId });
                    table.ForeignKey(
                        name: "FK_VehicleModelFuelTypes_FuelTypes_FuelTypeId",
                        column: x => x.FuelTypeId,
                        principalTable: "FuelTypes",
                        principalColumn: "FuelTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleModelFuelTypes_VehicleModels_VehicleModelId",
                        column: x => x.VehicleModelId,
                        principalTable: "VehicleModels",
                        principalColumn: "VehicleModelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleModelTransmissionTypes",
                columns: table => new
                {
                    VehicleModelId = table.Column<int>(type: "int", nullable: false),
                    TransmissionTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleModelTransmissionTypes", x => new { x.VehicleModelId, x.TransmissionTypeId });
                    table.ForeignKey(
                        name: "FK_VehicleModelTransmissionTypes_TransmissionTypes_TransmissionTypeId",
                        column: x => x.TransmissionTypeId,
                        principalTable: "TransmissionTypes",
                        principalColumn: "TransmissionTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleModelTransmissionTypes_VehicleModels_VehicleModelId",
                        column: x => x.VehicleModelId,
                        principalTable: "VehicleModels",
                        principalColumn: "VehicleModelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleModelTrimLevels",
                columns: table => new
                {
                    VehicleModelId = table.Column<int>(type: "int", nullable: false),
                    TrimLevelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleModelTrimLevels", x => new { x.VehicleModelId, x.TrimLevelId });
                    table.ForeignKey(
                        name: "FK_VehicleModelTrimLevels_TrimLevels_TrimLevelId",
                        column: x => x.TrimLevelId,
                        principalTable: "TrimLevels",
                        principalColumn: "TrimLevelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleModelTrimLevels_VehicleModels_VehicleModelId",
                        column: x => x.VehicleModelId,
                        principalTable: "VehicleModels",
                        principalColumn: "VehicleModelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0f024934-1cbe-4744-a053-d5e61918cc59", null, "SuperUser", "SUPERUSER" },
                    { "3106a0c5-9f3c-45bf-bfce-87a1732aa739", null, "Employee", "EMPLOYEE" },
                    { "8a154fd0-9351-4503-8e8b-455e3d7e9213", null, "User", "USER" },
                    { "92df9b37-d3bc-4f06-89b9-a2c2b2f0385a", null, "Admin", "ADMIN" },
                    { "bb31ecee-62f9-4f6b-8dfd-cd6a144417d9", null, "Executive", "EXECUTIVE" }
                });

            migrationBuilder.InsertData(
                table: "DriveTrains",
                columns: new[] { "DriveTrainId", "DriveTrainName" },
                values: new object[,]
                {
                    { 1, "FWD" },
                    { 2, "RWD" },
                    { 3, "AWD" },
                    { 4, "4WD" },
                    { 5, "2WD" }
                });

            migrationBuilder.InsertData(
                table: "EngineTypes",
                columns: new[] { "EngineTypeId", "EngineTypeName" },
                values: new object[,]
                {
                    { 1, "V6" },
                    { 2, "V8" },
                    { 3, "Inline-4" },
                    { 4, "Electric" },
                    { 5, "Hybrid" }
                });

            migrationBuilder.InsertData(
                table: "FuelTypes",
                columns: new[] { "FuelTypeId", "FuelTypeName" },
                values: new object[,]
                {
                    { 1, "Petrol" },
                    { 2, "Diesel" },
                    { 3, "Electric" },
                    { 4, "Hybrid" },
                    { 5, "Hydrogen" }
                });

            migrationBuilder.InsertData(
                table: "TransmissionTypes",
                columns: new[] { "TransmissionTypeId", "TransmissionTypeName" },
                values: new object[,]
                {
                    { 1, "Manual" },
                    { 2, "Automatic" },
                    { 3, "CVT" },
                    { 4, "Dual-clutch" },
                    { 5, "Semi-automatic" }
                });

            migrationBuilder.InsertData(
                table: "TrimLevels",
                columns: new[] { "TrimLevelId", "TrimLevelName" },
                values: new object[,]
                {
                    { 1, "Base" },
                    { 2, "Sport" },
                    { 3, "Luxury" },
                    { 4, "Premium" },
                    { 5, "Limited" }
                });

            migrationBuilder.UpdateData(
                table: "VehicleModels",
                keyColumn: "VehicleModelId",
                keyValue: 1,
                columns: new[] { "EmissionStandard", "HorsepowerRange", "MaxTowingCapacity", "TorqueRange", "Year" },
                values: new object[] { "Euro 6", "200-250 HP", 0, "180-220 lb-ft", 2023 });

            migrationBuilder.UpdateData(
                table: "VehicleModels",
                keyColumn: "VehicleModelId",
                keyValue: 2,
                columns: new[] { "EmissionStandard", "HorsepowerRange", "MaxTowingCapacity", "TorqueRange", "Year" },
                values: new object[] { "Euro 6", "168-200 HP", 0, "151-177 lb-ft", 2023 });

            migrationBuilder.UpdateData(
                table: "VehicleModels",
                keyColumn: "VehicleModelId",
                keyValue: 3,
                columns: new[] { "EmissionStandard", "HorsepowerRange", "Make", "MaxTowingCapacity", "Model", "TorqueRange", "Year" },
                values: new object[] { "BS-VI", "290-400 HP", "Ford", 13000, "F-150", "265-400 lb-ft", 2024 });

            migrationBuilder.UpdateData(
                table: "VehicleModels",
                keyColumn: "VehicleModelId",
                keyValue: 4,
                columns: new[] { "EmissionStandard", "HorsepowerRange", "Make", "MaxTowingCapacity", "Model", "TorqueRange", "Year" },
                values: new object[] { "Euro 6", "450-700 HP", "Ford", 0, "Mustang", "420-550 lb-ft", 2024 });

            migrationBuilder.UpdateData(
                table: "VehicleModels",
                keyColumn: "VehicleModelId",
                keyValue: 5,
                columns: new[] { "EmissionStandard", "HorsepowerRange", "Make", "MaxTowingCapacity", "Model", "TorqueRange", "Year" },
                values: new object[] { "Zero Emissions", "670-1020 HP", "Tesla", 5000, "Model X", "713 lb-ft", 2024 });

            migrationBuilder.UpdateData(
                table: "VehicleModels",
                keyColumn: "VehicleModelId",
                keyValue: 6,
                columns: new[] { "EmissionStandard", "HorsepowerRange", "Make", "MaxTowingCapacity", "Model", "TorqueRange", "Year" },
                values: new object[] { "Zero Emissions", "258-310 HP", "Tesla", 1500, "Model 3", "339-347 lb-ft", 2024 });

            migrationBuilder.UpdateData(
                table: "VehicleModels",
                keyColumn: "VehicleModelId",
                keyValue: 7,
                columns: new[] { "EmissionStandard", "HorsepowerRange", "Make", "MaxTowingCapacity", "Model", "TorqueRange", "Year" },
                values: new object[] { "Euro 6", "150-180 HP", "Honda", 0, "Civic", "160-177 lb-ft", 2023 });

            migrationBuilder.UpdateData(
                table: "VehicleModels",
                keyColumn: "VehicleModelId",
                keyValue: 8,
                columns: new[] { "EmissionStandard", "HorsepowerRange", "Make", "MaxTowingCapacity", "Model", "TorqueRange", "Year" },
                values: new object[] { "Euro 6", "190-240 HP", "Honda", 1500, "CR-V", "177-221 lb-ft", 2024 });

            migrationBuilder.UpdateData(
                table: "VehicleModels",
                keyColumn: "VehicleModelId",
                keyValue: 9,
                columns: new[] { "EmissionStandard", "HorsepowerRange", "Make", "MaxTowingCapacity", "Model", "TorqueRange", "Year" },
                values: new object[] { "Euro 6", "147-200 HP", "Hyundai", 0, "Elantra", "139-186 lb-ft", 2023 });

            migrationBuilder.InsertData(
                table: "VehicleModels",
                columns: new[] { "VehicleModelId", "EmissionStandard", "HorsepowerRange", "Make", "MaxTowingCapacity", "Model", "TorqueRange", "Year" },
                values: new object[,]
                {
                    { 10, "Euro 6", "191-281 HP", "Hyundai", 5000, "Santa Fe", "185-261 lb-ft", 2024 },
                    { 11, "Euro 6", "182-248 HP", "Nissan", 0, "Altima", "178-236 lb-ft", 2023 },
                    { 12, "Euro 6", "170-240 HP", "Nissan", 1500, "Rogue", "175-221 lb-ft", 2024 },
                    { 13, "Euro 6", "182-248 HP", "Kia", 0, "Optima", "178-236 lb-ft", 2023 },
                    { 14, "Euro 6", "191-281 HP", "Kia", 5000, "Sorento", "185-261 lb-ft", 2024 },
                    { 15, "Euro 6", "160-200 HP", "Chevrolet", 0, "Malibu", "155-184 lb-ft", 2023 },
                    { 16, "Euro 6", "355-420 HP", "Chevrolet", 8900, "Tahoe", "383-460 lb-ft", 2024 },
                    { 17, "Euro 6", "182-260 HP", "Subaru", 3500, "Outback", "176-244 lb-ft", 2024 },
                    { 18, "Euro 6", "182-260 HP", "Subaru", 3500, "Forester", "176-244 lb-ft", 2024 },
                    { 19, "Euro 6", "187-250 HP", "Mazda", 2000, "CX-5", "186-258 lb-ft", 2024 },
                    { 20, "Euro 6", "186-227 HP", "Mazda", 1500, "3", "186-250 lb-ft", 2023 }
                });

            migrationBuilder.InsertData(
                table: "VehicleModelDriveTrains",
                columns: new[] { "DriveTrainId", "VehicleModelId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 4, 3 },
                    { 2, 4 },
                    { 3, 5 },
                    { 3, 6 },
                    { 1, 7 },
                    { 3, 8 },
                    { 1, 9 },
                    { 3, 10 }
                });

            migrationBuilder.InsertData(
                table: "VehicleModelEngineTypes",
                columns: new[] { "EngineTypeId", "VehicleModelId" },
                values: new object[,]
                {
                    { 3, 1 },
                    { 3, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 4, 5 },
                    { 4, 6 },
                    { 3, 7 },
                    { 5, 8 },
                    { 3, 9 },
                    { 5, 10 }
                });

            migrationBuilder.InsertData(
                table: "VehicleModelFuelTypes",
                columns: new[] { "FuelTypeId", "VehicleModelId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 3, 5 },
                    { 3, 6 },
                    { 1, 7 },
                    { 4, 8 },
                    { 1, 9 },
                    { 4, 10 }
                });

            migrationBuilder.InsertData(
                table: "VehicleModelTransmissionTypes",
                columns: new[] { "TransmissionTypeId", "VehicleModelId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 3, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 4, 5 },
                    { 4, 6 },
                    { 1, 7 },
                    { 2, 8 },
                    { 3, 9 },
                    { 2, 10 }
                });

            migrationBuilder.InsertData(
                table: "VehicleModelTrimLevels",
                columns: new[] { "TrimLevelId", "VehicleModelId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 4, 3 },
                    { 3, 4 },
                    { 5, 5 },
                    { 4, 6 },
                    { 1, 7 },
                    { 3, 8 },
                    { 1, 9 },
                    { 5, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModelDriveTrains_DriveTrainId",
                table: "VehicleModelDriveTrains",
                column: "DriveTrainId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModelEngineTypes_EngineTypeId",
                table: "VehicleModelEngineTypes",
                column: "EngineTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModelFuelTypes_FuelTypeId",
                table: "VehicleModelFuelTypes",
                column: "FuelTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModelTransmissionTypes_TransmissionTypeId",
                table: "VehicleModelTransmissionTypes",
                column: "TransmissionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModelTrimLevels_TrimLevelId",
                table: "VehicleModelTrimLevels",
                column: "TrimLevelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleModelDriveTrains");

            migrationBuilder.DropTable(
                name: "VehicleModelEngineTypes");

            migrationBuilder.DropTable(
                name: "VehicleModelFuelTypes");

            migrationBuilder.DropTable(
                name: "VehicleModelTransmissionTypes");

            migrationBuilder.DropTable(
                name: "VehicleModelTrimLevels");

            migrationBuilder.DropTable(
                name: "DriveTrains");

            migrationBuilder.DropTable(
                name: "EngineTypes");

            migrationBuilder.DropTable(
                name: "FuelTypes");

            migrationBuilder.DropTable(
                name: "TransmissionTypes");

            migrationBuilder.DropTable(
                name: "TrimLevels");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f024934-1cbe-4744-a053-d5e61918cc59");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3106a0c5-9f3c-45bf-bfce-87a1732aa739");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8a154fd0-9351-4503-8e8b-455e3d7e9213");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "92df9b37-d3bc-4f06-89b9-a2c2b2f0385a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bb31ecee-62f9-4f6b-8dfd-cd6a144417d9");

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "VehicleModelId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "VehicleModelId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "VehicleModelId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "VehicleModelId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "VehicleModelId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "VehicleModelId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "VehicleModelId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "VehicleModelId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "VehicleModelId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "VehicleModelId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "VehicleModelId",
                keyValue: 20);

            migrationBuilder.DropColumn(
                name: "EmissionStandard",
                table: "VehicleModels");

            migrationBuilder.DropColumn(
                name: "HorsepowerRange",
                table: "VehicleModels");

            migrationBuilder.DropColumn(
                name: "MaxTowingCapacity",
                table: "VehicleModels");

            migrationBuilder.DropColumn(
                name: "TorqueRange",
                table: "VehicleModels");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Bookings");

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

            migrationBuilder.UpdateData(
                table: "VehicleModels",
                keyColumn: "VehicleModelId",
                keyValue: 1,
                column: "Year",
                value: 2019);

            migrationBuilder.UpdateData(
                table: "VehicleModels",
                keyColumn: "VehicleModelId",
                keyValue: 2,
                column: "Year",
                value: 2020);

            migrationBuilder.UpdateData(
                table: "VehicleModels",
                keyColumn: "VehicleModelId",
                keyValue: 3,
                columns: new[] { "Make", "Model", "Year" },
                values: new object[] { "Toyota", "Corolla", 2018 });

            migrationBuilder.UpdateData(
                table: "VehicleModels",
                keyColumn: "VehicleModelId",
                keyValue: 4,
                columns: new[] { "Make", "Model", "Year" },
                values: new object[] { "Honda", "Civic", 2021 });

            migrationBuilder.UpdateData(
                table: "VehicleModels",
                keyColumn: "VehicleModelId",
                keyValue: 5,
                columns: new[] { "Make", "Model", "Year" },
                values: new object[] { "Honda", "Civic", 2019 });

            migrationBuilder.UpdateData(
                table: "VehicleModels",
                keyColumn: "VehicleModelId",
                keyValue: 6,
                columns: new[] { "Make", "Model", "Year" },
                values: new object[] { "Honda", "Accord", 2020 });

            migrationBuilder.UpdateData(
                table: "VehicleModels",
                keyColumn: "VehicleModelId",
                keyValue: 7,
                columns: new[] { "Make", "Model", "Year" },
                values: new object[] { "Ford", "Mustang", 2022 });

            migrationBuilder.UpdateData(
                table: "VehicleModels",
                keyColumn: "VehicleModelId",
                keyValue: 8,
                columns: new[] { "Make", "Model", "Year" },
                values: new object[] { "Ford", "Mustang", 2029 });

            migrationBuilder.UpdateData(
                table: "VehicleModels",
                keyColumn: "VehicleModelId",
                keyValue: 9,
                columns: new[] { "Make", "Model", "Year" },
                values: new object[] { "Ford", "F-150", 2022 });
        }
    }
}
