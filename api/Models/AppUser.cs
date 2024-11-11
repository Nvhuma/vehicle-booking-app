namespace api.Models
{

using Microsoft.AspNetCore.Identity;


    public class AppUser : IdentityUser
    {
        public required string  Name { get; set; }
        public required string  Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public required string  IdentityNumber { get; set; }
        public required string  Gender { get; set; }
        public required string  CitizenshipStatus { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
				
        public List<UserPasswordHistory> UserPasswordHistories  { get; set; } = new List<UserPasswordHistory>();
        public List<CardDetails> Cards { get; set; } = new List<CardDetails>();

    }
}