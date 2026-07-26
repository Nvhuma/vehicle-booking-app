namespace api.DTOs.CardDtos
{
    public class GetCardDto
    {
        
        public int Id { get; set; }
        public string CardHolder { get; set; } // Card Holder Name
        public string CardNumber { get; set; } // Card Number
        public DateTime ExpiryDate { get; set; } // Expiry Date
        public string CVV { get; set; } // CVV
        public string BankName { get; set; } // Bank Name (optional)

    }
}