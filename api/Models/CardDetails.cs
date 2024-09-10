using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class CardDetails
    {
        public int Id { get; set;}
        public string CardHolder { get; set; } // Card Holder Name
        public string CardNumber { get; set; } // Card Number
        public DateTime ExpiryDate { get; set; } // Expiry Date
        public string CVV { get; set; } // CVV
        public string BankName { get; set; } // Bank Name (optional)

        // Foreign Key to UserAccount
        public string UserID { get; set; }

        // Navigation property to the UserAccount
        public AppUser AppUser { get; set; }
    }
}