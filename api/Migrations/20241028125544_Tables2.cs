using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class Tables2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdentityNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CitizenshipStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.UserID);
                });

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
                name: "ServiceTypes",
                columns: table => new
                {
                    ServiceTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTypes", x => x.ServiceTypeId);
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
                name: "VehicleModels",
                columns: table => new
                {
                    VehicleModelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    HorsepowerRange = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TorqueRange = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxTowingCapacity = table.Column<int>(type: "int", nullable: false),
                    EmissionStandard = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleModels", x => x.VehicleModelId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CardDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardHolder = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CVV = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardDetails_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PasswordHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PasswordHistories_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceSpecialty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    ServiceTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employee_ServiceTypes_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalTable: "ServiceTypes",
                        principalColumn: "ServiceTypeId");
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VehicleModelId = table.Column<int>(type: "int", nullable: false),
                    ServiceType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DesiredDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionalNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookingStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ServiceTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Bookings_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK_Bookings_ServiceTypes_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalTable: "ServiceTypes",
                        principalColumn: "ServiceTypeId");
                    table.ForeignKey(
                        name: "FK_Bookings_VehicleModels_VehicleModelId",
                        column: x => x.VehicleModelId,
                        principalTable: "VehicleModels",
                        principalColumn: "VehicleModelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServicePrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleModelId = table.Column<int>(type: "int", nullable: false),
                    ServiceTypeId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicePrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServicePrices_ServiceTypes_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalTable: "ServiceTypes",
                        principalColumn: "ServiceTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServicePrices_VehicleModels_VehicleModelId",
                        column: x => x.VehicleModelId,
                        principalTable: "VehicleModels",
                        principalColumn: "VehicleModelId",
                        onDelete: ReferentialAction.Cascade);
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
                    { "15a2a459-3fba-4f6e-a1c0-bc7ccb6f51ea", null, "SuperUser", "SUPERUSER" },
                    { "8fc37c66-38c0-41a6-8d27-48de7d42795b", null, "Admin", "ADMIN" },
                    { "9828dfd8-9cf3-4665-b169-b720c9883b37", null, "Executive", "EXECUTIVE" },
                    { "bdaed4f5-80d9-4efd-9a87-4f365faa1758", null, "User", "USER" },
                    { "c6eb9d25-48ed-4f3d-b213-247504f982b0", null, "Employee", "EMPLOYEE" }
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
                table: "Employee",
                columns: new[] { "EmployeeId", "IsAvailable", "Name", "ServiceSpecialty", "ServiceTypeId" },
                values: new object[,]
                {
                    { 1, true, "Vusi Vusimusi", "Oil Change", null },
                    { 2, true, "Jane Smith", "Tire Rotation", null },
                    { 3, true, "Bob Johnson", "Break pads", null }
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
                table: "ServiceTypes",
                columns: new[] { "ServiceTypeId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, null, "Oil Change" },
                    { 2, null, "Tire Rotation" },
                    { 3, null, "Brake Repair" }
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

            migrationBuilder.InsertData(
                table: "VehicleModels",
                columns: new[] { "VehicleModelId", "EmissionStandard", "HorsepowerRange", "Make", "MaxTowingCapacity", "Model", "TorqueRange", "Year" },
                values: new object[,]
                {
                    { 1, "Euro 6", "200-250 HP", "Toyota", 0, "Camry", "180-220 lb-ft", 2023 },
                    { 2, "Euro 6", "168-200 HP", "Toyota", 0, "Corolla", "151-177 lb-ft", 2023 },
                    { 3, "BS-VI", "290-400 HP", "Ford", 13000, "F-150", "265-400 lb-ft", 2024 },
                    { 4, "Euro 6", "450-700 HP", "Ford", 0, "Mustang", "420-550 lb-ft", 2024 },
                    { 5, "Zero Emissions", "670-1020 HP", "Tesla", 5000, "Model X", "713 lb-ft", 2024 },
                    { 6, "Zero Emissions", "258-310 HP", "Tesla", 1500, "Model 3", "339-347 lb-ft", 2024 },
                    { 7, "Euro 6", "150-180 HP", "Honda", 0, "Civic", "160-177 lb-ft", 2023 },
                    { 8, "Euro 6", "190-240 HP", "Honda", 1500, "CR-V", "177-221 lb-ft", 2024 },
                    { 9, "Euro 6", "147-200 HP", "Hyundai", 0, "Elantra", "139-186 lb-ft", 2023 },
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
                table: "ServicePrices",
                columns: new[] { "Id", "Price", "ServiceTypeId", "VehicleModelId" },
                values: new object[,]
                {
                    { 1, 29.99m, 1, 1 },
                    { 2, 19.99m, 2, 1 },
                    { 3, 31.99m, 1, 2 },
                    { 4, 29.99m, 1, 4 },
                    { 5, 99.99m, 3, 4 },
                    { 6, 99.99m, 3, 9 }
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
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_AppUserId",
                table: "Bookings",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ServiceTypeId",
                table: "Bookings",
                column: "ServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_VehicleModelId",
                table: "Bookings",
                column: "VehicleModelId");

            migrationBuilder.CreateIndex(
                name: "IX_CardDetails_UserID",
                table: "CardDetails",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_ServiceTypeId",
                table: "Employee",
                column: "ServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PasswordHistories_UserID",
                table: "PasswordHistories",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_ServicePrices_ServiceTypeId",
                table: "ServicePrices",
                column: "ServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicePrices_VehicleModelId",
                table: "ServicePrices",
                column: "VehicleModelId");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "CardDetails");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "PasswordHistories");

            migrationBuilder.DropTable(
                name: "ServicePrices");

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
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ServiceTypes");

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

            migrationBuilder.DropTable(
                name: "VehicleModels");
        }
    }
}
