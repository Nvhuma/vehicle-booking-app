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
        public DbSet<CardDetails> CardDetails {get; set; }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        
            // This Block of code renames the "Id" Column to UserID
            modelBuilder.Entity<AppUser>()
                .Property(u => u.Id)
                .HasColumnName("UserID");
        
             // This table keeps history records of the user's passwords
            modelBuilder.Entity<UserPasswordHistory>()
                .HasOne(p => p.AppUser)
                .WithMany(u => u.UserPasswordHistories)
                .HasForeignKey(p => p.UserID);

            /*  This block of cade links card details to user 
                If a user is deleted, then all their card details will also be deleted.
            */
             modelBuilder.Entity<CardDetails>()
                .HasOne(cd => cd.AppUser)
                .WithMany(ua => ua.Cards)
                .HasForeignKey(cd => cd.UserID)
                .OnDelete(DeleteBehavior.Cascade);


            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name="SuperUser",
                    NormalizedName="SUPERUSER",
                },
                new IdentityRole
                {
                    Name="Admin",
                    NormalizedName = "ADMIN",
                },
                new IdentityRole
                {
                    Name="User",
                    NormalizedName="USER",
                },
                new IdentityRole
                {
                    Name="Executive",
                    NormalizedName = "EXECUTIVE",
                },
                new IdentityRole
                {
                    Name="Employee",
                    NormalizedName = "EMPLOYEE",
                }
            };

            modelBuilder.Entity<IdentityRole>().HasData(roles);

        }
    }
}