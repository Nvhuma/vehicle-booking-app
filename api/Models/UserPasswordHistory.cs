using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class UserPasswordHistory
    {
        public int Id { get; set; }

        public string UserID { get; set; }  // Store the User ID as a foreign key

        public string PasswordHash { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.UtcNow;

        // navigation  properties

        public AppUser AppUser { get; set; }
    }
}