using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace api.Data
{
	public class ApplicationDBContext : IdentityDbContext<AppUser>
	{
		public ApplicationDBContext(DbContextOptions<ApplicationDBContext> dbContextOptions)
				: base(dbContextOptions)
		{
		}

		public DbSet<UserPasswordHistory> PasswordHistories { get; set; }
		public DbSet<CardDetails> CardDetails { get; set; }

		public DbSet<VehicleModel> VehicleModels { get; set; }
		public DbSet<ServiceType> ServiceTypes { get; set; }
		public DbSet<ServicePrice> ServicePrices { get; set; }
		public DbSet<Booking> Bookings { get; set; }

		public DbSet<EngineType> EngineTypes { get; set; }
		public DbSet<TransmissionType> TransmissionTypes { get; set; }
		public DbSet<DriveTrain> DriveTrains { get; set; }
		public DbSet<FuelType> FuelTypes { get; set; }
		public DbSet<TrimLevel> TrimLevels { get; set; }

		public DbSet<VehicleModelEngineType> VehicleModelEngineTypes { get; set; }
		public DbSet<VehicleModelTransmissionType> VehicleModelTransmissionTypes { get; set; }
		public DbSet<VehicleModelDriveTrain> VehicleModelDriveTrains { get; set; }
		public DbSet<VehicleModelFuelType> VehicleModelFuelTypes { get; set; }
		public DbSet<VehicleModelTrimLevel> VehicleModelTrimLevels { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<AppUser>()
				.Property(u => u.Id)
				.HasColumnName("UserID");

			modelBuilder.Entity<UserPasswordHistory>()
				.HasOne(p => p.AppUser)
				.WithMany(u => u.UserPasswordHistories)
				.HasForeignKey(p => p.UserID);

			modelBuilder.Entity<ServicePrice>()
				.Property(sp => sp.Price)
				.HasColumnType("decimal(18, 2)");

			modelBuilder.Entity<CardDetails>()
				.HasOne(cd => cd.AppUser)
				.WithMany(ua => ua.Cards)
				.HasForeignKey(cd => cd.UserID)
				.OnDelete(DeleteBehavior.Cascade);

			// **Seed Employees**

			var employees = new List<Employee>
			{
				new Employee { EmployeeId = 1, Name = "Vusi Vusimusi", ServiceSpecialty = "Oil Change",   IsAvailable = true },
				new Employee { EmployeeId = 2, Name = "Jane Smith" ,ServiceSpecialty = "Tire Rotation" ,   IsAvailable = true},
				new Employee { EmployeeId = 3, Name = "Bob Johnson" , ServiceSpecialty = "Break pads",  IsAvailable = true },
			};

			modelBuilder.Entity<ServiceType>().HasData(
				new ServiceType { ServiceTypeId = 1, Name = "Oil Change" },
				new ServiceType { ServiceTypeId = 2, Name = "Tire Rotation" },
				new ServiceType { ServiceTypeId = 3, Name = "Brake Repair" }
			);

			modelBuilder.Entity<ServicePrice>().HasData(
				new ServicePrice { Id = 1, VehicleModelId = 1, ServiceTypeId = 1, Price = 29.99m },
				new ServicePrice { Id = 2, VehicleModelId = 1, ServiceTypeId = 2, Price = 19.99m },
				new ServicePrice { Id = 3, VehicleModelId = 2, ServiceTypeId = 1, Price = 31.99m },
				new ServicePrice { Id = 4, VehicleModelId = 4, ServiceTypeId = 1, Price = 29.99m },
				new ServicePrice { Id = 5, VehicleModelId = 4, ServiceTypeId = 3, Price = 99.99m },
				new ServicePrice { Id = 6, VehicleModelId = 9, ServiceTypeId = 3, Price = 99.99m }
			);
			modelBuilder.Entity<VehicleModel>().HasData(

				// Toyota
				new VehicleModel { VehicleModelId = 1, Make = "Toyota", Model = "Camry", Year = 2023, HorsepowerRange = "200-250 HP", TorqueRange = "180-220 lb-ft", MaxTowingCapacity = 0, EmissionStandard = "Euro 6" },
				new VehicleModel { VehicleModelId = 2, Make = "Toyota", Model = "Corolla", Year = 2023, HorsepowerRange = "168-200 HP", TorqueRange = "151-177 lb-ft", MaxTowingCapacity = 0, EmissionStandard = "Euro 6" },

				// Ford
				new VehicleModel { VehicleModelId = 3, Make = "Ford", Model = "F-150", Year = 2024, HorsepowerRange = "290-400 HP", TorqueRange = "265-400 lb-ft", MaxTowingCapacity = 13000, EmissionStandard = "BS-VI" },
				new VehicleModel { VehicleModelId = 4, Make = "Ford", Model = "Mustang", Year = 2024, HorsepowerRange = "450-700 HP", TorqueRange = "420-550 lb-ft", MaxTowingCapacity = 0, EmissionStandard = "Euro 6" },

				// Tesla
				new VehicleModel { VehicleModelId = 5, Make = "Tesla", Model = "Model X", Year = 2024, HorsepowerRange = "670-1020 HP", TorqueRange = "713 lb-ft", MaxTowingCapacity = 5000, EmissionStandard = "Zero Emissions" },
				new VehicleModel { VehicleModelId = 6, Make = "Tesla", Model = "Model 3", Year = 2024, HorsepowerRange = "258-310 HP", TorqueRange = "339-347 lb-ft", MaxTowingCapacity = 1500, EmissionStandard = "Zero Emissions" },

				// Honda
				new VehicleModel { VehicleModelId = 7, Make = "Honda", Model = "Civic", Year = 2023, HorsepowerRange = "150-180 HP", TorqueRange = "160-177 lb-ft", MaxTowingCapacity = 0, EmissionStandard = "Euro 6" },
				new VehicleModel { VehicleModelId = 8, Make = "Honda", Model = "CR-V", Year = 2024, HorsepowerRange = "190-240 HP", TorqueRange = "177-221 lb-ft", MaxTowingCapacity = 1500, EmissionStandard = "Euro 6" },

				// Hyundai
				new VehicleModel { VehicleModelId = 9, Make = "Hyundai", Model = "Elantra", Year = 2023, HorsepowerRange = "147-200 HP", TorqueRange = "139-186 lb-ft", MaxTowingCapacity = 0, EmissionStandard = "Euro 6" },
				new VehicleModel { VehicleModelId = 10, Make = "Hyundai", Model = "Santa Fe", Year = 2024, HorsepowerRange = "191-281 HP", TorqueRange = "185-261 lb-ft", MaxTowingCapacity = 5000, EmissionStandard = "Euro 6" },

				// Nissan
				new VehicleModel { VehicleModelId = 11, Make = "Nissan", Model = "Altima", Year = 2023, HorsepowerRange = "182-248 HP", TorqueRange = "178-236 lb-ft", MaxTowingCapacity = 0, EmissionStandard = "Euro 6" },
				new VehicleModel { VehicleModelId = 12, Make = "Nissan", Model = "Rogue", Year = 2024, HorsepowerRange = "170-240 HP", TorqueRange = "175-221 lb-ft", MaxTowingCapacity = 1500, EmissionStandard = "Euro 6" },

				// Kia
				new VehicleModel { VehicleModelId = 13, Make = "Kia", Model = "Optima", Year = 2023, HorsepowerRange = "182-248 HP", TorqueRange = "178-236 lb-ft", MaxTowingCapacity = 0, EmissionStandard = "Euro 6" },
				new VehicleModel { VehicleModelId = 14, Make = "Kia", Model = "Sorento", Year = 2024, HorsepowerRange = "191-281 HP", TorqueRange = "185-261 lb-ft", MaxTowingCapacity = 5000, EmissionStandard = "Euro 6" },

				// Chevrolet
				new VehicleModel { VehicleModelId = 15, Make = "Chevrolet", Model = "Malibu", Year = 2023, HorsepowerRange = "160-200 HP", TorqueRange = "155-184 lb-ft", MaxTowingCapacity = 0, EmissionStandard = "Euro 6" },
				new VehicleModel { VehicleModelId = 16, Make = "Chevrolet", Model = "Tahoe", Year = 2024, HorsepowerRange = "355-420 HP", TorqueRange = "383-460 lb-ft", MaxTowingCapacity = 8900, EmissionStandard = "Euro 6" },

				// Subaru
				new VehicleModel { VehicleModelId = 17, Make = "Subaru", Model = "Outback", Year = 2024, HorsepowerRange = "182-260 HP", TorqueRange = "176-244 lb-ft", MaxTowingCapacity = 3500, EmissionStandard = "Euro 6" },
				new VehicleModel { VehicleModelId = 18, Make = "Subaru", Model = "Forester", Year = 2024, HorsepowerRange = "182-260 HP", TorqueRange = "176-244 lb-ft", MaxTowingCapacity = 3500, EmissionStandard = "Euro 6" },

				// Mazda
				new VehicleModel { VehicleModelId = 19, Make = "Mazda", Model = "CX-5", Year = 2024, HorsepowerRange = "187-250 HP", TorqueRange = "186-258 lb-ft", MaxTowingCapacity = 2000, EmissionStandard = "Euro 6" },
				new VehicleModel { VehicleModelId = 20, Make = "Mazda", Model = "3", Year = 2023, HorsepowerRange = "186-227 HP", TorqueRange = "186-250 lb-ft", MaxTowingCapacity = 1500, EmissionStandard = "Euro 6" }

			);

			modelBuilder.Entity<Employee>().HasData(employees);

			List<IdentityRole> roles = new List<IdentityRole>
					{
							new IdentityRole
							{
									Name = "SuperUser",
									NormalizedName = "SUPERUSER",
							},
							new IdentityRole
							{
									Name = "Admin",
									NormalizedName = "ADMIN",
							},
							new IdentityRole
							{
									Name = "User",
									NormalizedName = "USER",
							},
							new IdentityRole
							{
									Name = "Executive",
									NormalizedName = "EXECUTIVE",
							},
							new IdentityRole
							{
									Name = "Employee",
									NormalizedName = "EMPLOYEE",
							}
					};

			modelBuilder.Entity<IdentityRole>().HasData(roles);

			modelBuilder.Entity<VehicleModelEngineType>()
				.HasKey(vme => new { vme.VehicleModelId, vme.EngineTypeId });

			modelBuilder.Entity<VehicleModelEngineType>()
				.HasOne(vme => vme.VehicleModel)
				.WithMany(vm => vm.VehicleModelEngineTypes)
				.HasForeignKey(vme => vme.VehicleModelId);

			modelBuilder.Entity<VehicleModelEngineType>()
				.HasOne(vme => vme.EngineType)
				.WithMany(et => et.VehicleModelEngineTypes)
				.HasForeignKey(vme => vme.EngineTypeId);

			modelBuilder.Entity<VehicleModelTransmissionType>()
				.HasKey(vmt => new { vmt.VehicleModelId, vmt.TransmissionTypeId });

			modelBuilder.Entity<VehicleModelTransmissionType>()
				.HasOne(vmt => vmt.VehicleModel)
				.WithMany(vm => vm.VehicleModelTransmissionTypes)
				.HasForeignKey(vmt => vmt.VehicleModelId);

			modelBuilder.Entity<VehicleModelTransmissionType>()
				.HasOne(vmt => vmt.TransmissionType)
				.WithMany(tt => tt.VehicleModelTransmissionTypes)
				.HasForeignKey(vmt => vmt.TransmissionTypeId);

			modelBuilder.Entity<VehicleModelDriveTrain>()
				.HasKey(vmd => new { vmd.VehicleModelId, vmd.DriveTrainId });

			modelBuilder.Entity<VehicleModelDriveTrain>()
				.HasOne(vmd => vmd.VehicleModel)
				.WithMany(vm => vm.VehicleModelDriveTrains)
				.HasForeignKey(vmd => vmd.VehicleModelId);

			modelBuilder.Entity<VehicleModelDriveTrain>()
				.HasOne(vmd => vmd.DriveTrain)
				.WithMany(dt => dt.VehicleModelDriveTrains)
				.HasForeignKey(vmd => vmd.DriveTrainId);

			modelBuilder.Entity<VehicleModelFuelType>()
				.HasKey(vmf => new { vmf.VehicleModelId, vmf.FuelTypeId });

			modelBuilder.Entity<VehicleModelFuelType>()
				.HasOne(vmf => vmf.VehicleModel)
				.WithMany(vm => vm.VehicleModelFuelTypes)
				.HasForeignKey(vmf => vmf.VehicleModelId);

			modelBuilder.Entity<VehicleModelFuelType>()
				.HasOne(vmf => vmf.FuelType)
				.WithMany(ft => ft.VehicleModelFuelTypes)
				.HasForeignKey(vmf => vmf.FuelTypeId);

			modelBuilder.Entity<VehicleModelTrimLevel>()
				.HasKey(vmt => new { vmt.VehicleModelId, vmt.TrimLevelId });

			modelBuilder.Entity<VehicleModelTrimLevel>()
				.HasOne(vmt => vmt.VehicleModel)
				.WithMany(vm => vm.VehicleModelTrimLevels)
				.HasForeignKey(vmt => vmt.VehicleModelId);

			modelBuilder.Entity<VehicleModelTrimLevel>()
				.HasOne(vmt => vmt.TrimLevel)
				.WithMany(tl => tl.VehicleModelTrimLevels)
				.HasForeignKey(vmt => vmt.TrimLevelId);

			modelBuilder.Entity<EngineType>().HasData(
				new EngineType { EngineTypeId = 1, EngineTypeName = "V6" },
				new EngineType { EngineTypeId = 2, EngineTypeName = "V8" },
				new EngineType { EngineTypeId = 3, EngineTypeName = "Inline-4" },
				new EngineType { EngineTypeId = 4, EngineTypeName = "Electric" },
				new EngineType { EngineTypeId = 5, EngineTypeName = "Hybrid" }
			);

			// Seed data for TransmissionTypes
			modelBuilder.Entity<TransmissionType>().HasData(
				new TransmissionType { TransmissionTypeId = 1, TransmissionTypeName = "Manual" },
				new TransmissionType { TransmissionTypeId = 2, TransmissionTypeName = "Automatic" },
				new TransmissionType { TransmissionTypeId = 3, TransmissionTypeName = "CVT" },
				new TransmissionType { TransmissionTypeId = 4, TransmissionTypeName = "Dual-clutch" },
				new TransmissionType { TransmissionTypeId = 5, TransmissionTypeName = "Semi-automatic" }
			);

			// Seed data for DriveTrains
			modelBuilder.Entity<DriveTrain>().HasData(
				new DriveTrain { DriveTrainId = 1, DriveTrainName = "FWD" },  // Front Wheel Drive
				new DriveTrain { DriveTrainId = 2, DriveTrainName = "RWD" },  // Rear Wheel Drive
				new DriveTrain { DriveTrainId = 3, DriveTrainName = "AWD" },  // All Wheel Drive
				new DriveTrain { DriveTrainId = 4, DriveTrainName = "4WD" },  // Four Wheel Drive
				new DriveTrain { DriveTrainId = 5, DriveTrainName = "2WD" }   // Two Wheel Drive
			);

			// Seed data for FuelTypes
			modelBuilder.Entity<FuelType>().HasData(
				new FuelType { FuelTypeId = 1, FuelTypeName = "Petrol" },
				new FuelType { FuelTypeId = 2, FuelTypeName = "Diesel" },
				new FuelType { FuelTypeId = 3, FuelTypeName = "Electric" },
				new FuelType { FuelTypeId = 4, FuelTypeName = "Hybrid" },
				new FuelType { FuelTypeId = 5, FuelTypeName = "Hydrogen" }
			);

			// Seed data for TrimLevels
			modelBuilder.Entity<TrimLevel>().HasData(
				new TrimLevel { TrimLevelId = 1, TrimLevelName = "Base" },
				new TrimLevel { TrimLevelId = 2, TrimLevelName = "Sport" },
				new TrimLevel { TrimLevelId = 3, TrimLevelName = "Luxury" },
				new TrimLevel { TrimLevelId = 4, TrimLevelName = "Premium" },
				new TrimLevel { TrimLevelId = 5, TrimLevelName = "Limited" }
			);

			// Seed data for VehicleModelEngineType relationships
			modelBuilder.Entity<VehicleModelEngineType>().HasData(
				new VehicleModelEngineType { VehicleModelId = 1, EngineTypeId = 3 }, // Toyota Camry -> Inline-4
				new VehicleModelEngineType { VehicleModelId = 2, EngineTypeId = 3 }, // Toyota Corolla -> Inline-4
				new VehicleModelEngineType { VehicleModelId = 3, EngineTypeId = 2 }, // Ford F-150 -> V8
				new VehicleModelEngineType { VehicleModelId = 4, EngineTypeId = 2 }, // Ford Mustang -> V8
				new VehicleModelEngineType { VehicleModelId = 5, EngineTypeId = 4 }, // Tesla Model X -> Electric
				new VehicleModelEngineType { VehicleModelId = 6, EngineTypeId = 4 }, // Tesla Model 3 -> Electric
				new VehicleModelEngineType { VehicleModelId = 7, EngineTypeId = 3 }, // Honda Civic -> Inline-4
				new VehicleModelEngineType { VehicleModelId = 8, EngineTypeId = 5 }, // Honda CR-V -> Hybrid
				new VehicleModelEngineType { VehicleModelId = 9, EngineTypeId = 3 }, // Hyundai Elantra -> Inline-4
				new VehicleModelEngineType { VehicleModelId = 10, EngineTypeId = 5 } // Hyundai Santa Fe -> Hybrid
			);

			// Seed data for VehicleModelTransmissionType relationships
			modelBuilder.Entity<VehicleModelTransmissionType>().HasData(
				new VehicleModelTransmissionType { VehicleModelId = 1, TransmissionTypeId = 2 }, // Toyota Camry -> Automatic
				new VehicleModelTransmissionType { VehicleModelId = 2, TransmissionTypeId = 3 }, // Toyota Corolla -> CVT
				new VehicleModelTransmissionType { VehicleModelId = 3, TransmissionTypeId = 2 }, // Ford F-150 -> Automatic
				new VehicleModelTransmissionType { VehicleModelId = 4, TransmissionTypeId = 2 }, // Ford Mustang -> Automatic
				new VehicleModelTransmissionType { VehicleModelId = 5, TransmissionTypeId = 4 }, // Tesla Model X -> Dual-clutch
				new VehicleModelTransmissionType { VehicleModelId = 6, TransmissionTypeId = 4 }, // Tesla Model 3 -> Dual-clutch
				new VehicleModelTransmissionType { VehicleModelId = 7, TransmissionTypeId = 1 }, // Honda Civic -> Manual
				new VehicleModelTransmissionType { VehicleModelId = 8, TransmissionTypeId = 2 }, // Honda CR-V -> Automatic
				new VehicleModelTransmissionType { VehicleModelId = 9, TransmissionTypeId = 3 }, // Hyundai Elantra -> CVT
				new VehicleModelTransmissionType { VehicleModelId = 10, TransmissionTypeId = 2 } // Hyundai Santa Fe -> Automatic
			);

			// Seed data for VehicleModelDriveTrain relationships
			modelBuilder.Entity<VehicleModelDriveTrain>().HasData(
				new VehicleModelDriveTrain { VehicleModelId = 1, DriveTrainId = 1 }, // Toyota Camry -> FWD
				new VehicleModelDriveTrain { VehicleModelId = 2, DriveTrainId = 1 }, // Toyota Corolla -> FWD
				new VehicleModelDriveTrain { VehicleModelId = 3, DriveTrainId = 4 }, // Ford F-150 -> 4WD
				new VehicleModelDriveTrain { VehicleModelId = 4, DriveTrainId = 2 }, // Ford Mustang -> RWD
				new VehicleModelDriveTrain { VehicleModelId = 5, DriveTrainId = 3 }, // Tesla Model X -> AWD
				new VehicleModelDriveTrain { VehicleModelId = 6, DriveTrainId = 3 }, // Tesla Model 3 -> AWD
				new VehicleModelDriveTrain { VehicleModelId = 7, DriveTrainId = 1 }, // Honda Civic -> FWD
				new VehicleModelDriveTrain { VehicleModelId = 8, DriveTrainId = 3 }, // Honda CR-V -> AWD
				new VehicleModelDriveTrain { VehicleModelId = 9, DriveTrainId = 1 }, // Hyundai Elantra -> FWD
				new VehicleModelDriveTrain { VehicleModelId = 10, DriveTrainId = 3 } // Hyundai Santa Fe -> AWD
			);

			// Seed data for VehicleModelFuelType relationships
			modelBuilder.Entity<VehicleModelFuelType>().HasData(
				new VehicleModelFuelType { VehicleModelId = 1, FuelTypeId = 1 }, // Toyota Camry -> Petrol
				new VehicleModelFuelType { VehicleModelId = 2, FuelTypeId = 1 }, // Toyota Corolla -> Petrol
				new VehicleModelFuelType { VehicleModelId = 3, FuelTypeId = 1 }, // Ford F-150 -> Petrol
				new VehicleModelFuelType { VehicleModelId = 4, FuelTypeId = 1 }, // Ford Mustang -> Petrol
				new VehicleModelFuelType { VehicleModelId = 5, FuelTypeId = 3 }, // Tesla Model X -> Electric
				new VehicleModelFuelType { VehicleModelId = 6, FuelTypeId = 3 }, // Tesla Model 3 -> Electric
				new VehicleModelFuelType { VehicleModelId = 7, FuelTypeId = 1 }, // Honda Civic -> Petrol
				new VehicleModelFuelType { VehicleModelId = 8, FuelTypeId = 4 }, // Honda CR-V -> Hybrid
				new VehicleModelFuelType { VehicleModelId = 9, FuelTypeId = 1 }, // Hyundai Elantra -> Petrol
				new VehicleModelFuelType { VehicleModelId = 10, FuelTypeId = 4 } // Hyundai Santa Fe -> Hybrid
			);

			// Seed data for VehicleModelTrimLevel relationships
			modelBuilder.Entity<VehicleModelTrimLevel>().HasData(
				new VehicleModelTrimLevel { VehicleModelId = 1, TrimLevelId = 1 }, // Toyota Camry -> Base
				new VehicleModelTrimLevel { VehicleModelId = 2, TrimLevelId = 2 }, // Toyota Corolla -> Sport
				new VehicleModelTrimLevel { VehicleModelId = 3, TrimLevelId = 4 }, // Ford F-150 -> Premium
				new VehicleModelTrimLevel { VehicleModelId = 4, TrimLevelId = 3 }, // Ford Mustang -> Luxury
				new VehicleModelTrimLevel { VehicleModelId = 5, TrimLevelId = 5 }, // Tesla Model X -> Limited
				new VehicleModelTrimLevel { VehicleModelId = 6, TrimLevelId = 4 }, // Tesla Model 3 -> Premium
				new VehicleModelTrimLevel { VehicleModelId = 7, TrimLevelId = 1 }, // Honda Civic -> Base
				new VehicleModelTrimLevel { VehicleModelId = 8, TrimLevelId = 3 }, // Honda CR-V -> Luxury
				new VehicleModelTrimLevel { VehicleModelId = 9, TrimLevelId = 1 }, // Hyundai Elantra -> Base
				new VehicleModelTrimLevel { VehicleModelId = 10, TrimLevelId = 5 } // Hyundai Santa Fe -> Limited
			);
		}
	}
}