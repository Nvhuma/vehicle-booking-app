using Microsoft.AspNetCore.Identity;

namespace api.Models
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IdentityNumber { get; set; }
        public string Gender { get; set; }
        public string CitizenshipStatus { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
				
        public List<UserPasswordHistory> UserPasswordHistories  { get; set; } = new List<UserPasswordHistory>();
        public List<CardDetails> Cards { get; set; } = new List<CardDetails>();

    }
}