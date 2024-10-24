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
					new VehicleModel { VehicleModelId = 1, Make = "Toyota", Model = "Camry", Year = 2019 },
					new VehicleModel { VehicleModelId = 2, Make = "Toyota", Model = "Corolla", Year = 2020 },
					new VehicleModel { VehicleModelId = 3, Make = "Toyota", Model = "Corolla", Year = 2018 },

					new VehicleModel { VehicleModelId = 4, Make = "Honda", Model = "Civic", Year = 2021 },
					new VehicleModel { VehicleModelId = 5, Make = "Honda", Model = "Civic", Year = 2019 },
					new VehicleModel { VehicleModelId = 6, Make = "Honda", Model = "Accord", Year = 2020 },


					new VehicleModel { VehicleModelId = 7, Make = "Ford", Model = "Mustang", Year = 2022 },
					new VehicleModel { VehicleModelId = 8, Make = "Ford", Model = "Mustang", Year = 2029 },
					new VehicleModel { VehicleModelId = 9, Make = "Ford", Model = "F-150", Year = 2022 }
					
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
		}
	}
}