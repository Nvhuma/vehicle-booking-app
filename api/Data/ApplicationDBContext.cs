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

		public DbSet<Employee> Employees { get; set; }
		public DbSet<EmployeeService> EmployeeServices { get; set; }
		public DbSet<TimeSlot> TimeSlots { get; set; }
		public DbSet<Bookings> Bookings { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<AppUser>()
		.Property(u => u.Id)
		.HasColumnName("UserID");

			// **Seed Employees**
			var employees = new List<Employee>
		{
				new Employee { EmployeeId = 1, Name = "Vusi Vusimusi" },
				new Employee { EmployeeId = 2, Name = "Jane Smith" },
				new Employee { EmployeeId = 3, Name = "Bob Johnson" },
		};
			modelBuilder.Entity<Employee>().HasData(employees);

 // **Seed Time Slots ( associate with Employees and Service Types )**
    var timeSlots = new List<TimeSlot>
    {
        new TimeSlot { Id = 1, StartTime = DateTime.Parse("2023-03-15T09:00:00"), EndTime = DateTime.Parse("2023-03-15T10:00:00"), IsAvailable = true, BookingId = null, ServiceTypeId = 1, EmployeeId = 1 },
        new TimeSlot { Id = 2, StartTime = DateTime.Parse("2023-03-15T10:00:00"), EndTime = DateTime.Parse("2023-03-15T11:00:00"), IsAvailable = true, BookingId = null, ServiceTypeId = 2, EmployeeId = 2 },
        new TimeSlot { Id = 3, StartTime = DateTime.Parse("2023-03-15T11:00:00"), EndTime = DateTime.Parse("2023-03-15T12:00:00"), IsAvailable = true, BookingId = null, ServiceTypeId = 3, EmployeeId = 3 },
    };
    modelBuilder.Entity<TimeSlot>().HasData(timeSlots);


			// **Service Configuration**
			modelBuilder.Entity<ServiceType>()
			 .HasMany(s => s.Bookings)
			 .WithOne(b => b.ServiceType)
			 .HasForeignKey(b => b.ServiceTypeId)
			 .OnDelete(DeleteBehavior.Restrict); // Update to Restrict

			// **Employee Configuration**
			modelBuilder.Entity<Employee>()
			 .HasMany(e => e.Bookings)
			 .WithOne(b => b.Employee)
			 .HasForeignKey(b => b.EmployeeId)
			 .OnDelete(DeleteBehavior.Restrict); // Update to Restrict

			modelBuilder.Entity<Employee>()
			 .HasMany(e => e.EmployeeServices)
			 .WithOne(es => es.Employee)
			 .HasForeignKey(es => es.EmployeeId);

			// **EmployeeService Configuration**
			modelBuilder.Entity<EmployeeService>()
			 .HasKey(es => new { es.EmployeeId, es.ServiceTypeId });

			modelBuilder.Entity<EmployeeService>()
			 .HasOne(es => es.Employee)
			 .WithMany(e => e.EmployeeServices)
			 .HasForeignKey(es => es.EmployeeId);

			modelBuilder.Entity<EmployeeService>()
			 .HasOne(es => es.ServiceType)
			 .WithMany(s => s.EmployeeServices)
			 .HasForeignKey(es => es.ServiceTypeId);

			// **TimeSlot Configuration**
			modelBuilder.Entity<TimeSlot>()
			 .HasKey(ts => ts.Id);

			modelBuilder.Entity<TimeSlot>()
			 .HasOne(ts => ts.ServiceType)
			 .WithMany(s => s.TimeSlots)
			 .HasForeignKey(ts => ts.ServiceTypeId);

			modelBuilder.Entity<TimeSlot>()
			 .HasOne(ts => ts.Booking)
			 .WithOne(b => b.TimeSlot)
			 .HasForeignKey<TimeSlot>(ts => ts.BookingId)
			 .OnDelete(DeleteBehavior.Restrict); // Update to Restrict

			modelBuilder.Entity<TimeSlot>()
			 .HasOne(ts => ts.Employee)
			 .WithMany(e => e.TimeSlots)
			 .HasForeignKey(ts => ts.EmployeeId)
			 .OnDelete(DeleteBehavior.NoAction); // Update to NoAction

			modelBuilder.Entity<Bookings>()
			 .HasOne(b => b.Employee)
			 .WithMany(e => e.Bookings)
			 .HasForeignKey(b => b.EmployeeId)
			 .OnDelete(DeleteBehavior.Restrict); // Update to Restrict

			modelBuilder.Entity<Bookings>()
			 .HasOne(b => b.ServiceType)
			 .WithMany(s => s.Bookings)
			 .HasForeignKey(b => b.ServiceTypeId)
			 .OnDelete(DeleteBehavior.Restrict); // Update to Restrict

			modelBuilder.Entity<ServicePrice>()
			 .Property(sp => sp.Price)
			 .HasColumnType("decimal(18, 2)");


			modelBuilder.Entity<VehicleModel>().HasData(
					new VehicleModel { Id = 1, Make = "Toyota", Model = "Camry", Year = 2019 },
					new VehicleModel { Id = 2, Make = "Toyota", Model = "Corolla", Year = 2020 },
					new VehicleModel { Id = 3, Make = "Toyota", Model = "Corolla", Year = 2018 },

					new VehicleModel { Id = 4, Make = "Honda", Model = "Civic", Year = 2021 },
					new VehicleModel { Id = 5, Make = "Honda", Model = "Civic", Year = 2019 },
					new VehicleModel { Id = 6, Make = "Honda", Model = "Accord", Year = 2020 },


					new VehicleModel { Id = 7, Make = "Ford", Model = "Mustang", Year = 2022 },
					new VehicleModel { Id = 8, Make = "Ford", Model = "Mustang", Year = 2029 },
					new VehicleModel { Id = 9, Make = "Ford", Model = "F-150", Year = 2022 }
			);

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



			modelBuilder.Entity<UserPasswordHistory>()
			 .HasOne(p => p.AppUser)
			 .WithMany(u => u.UserPasswordHistories)
			 .HasForeignKey(p => p.UserID);

			modelBuilder.Entity<CardDetails>()
			 .HasOne(cd => cd.AppUser)
			 .WithMany(ua => ua.Cards)
			 .HasForeignKey(cd => cd.UserID)
			 .OnDelete(DeleteBehavior.Cascade);

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
