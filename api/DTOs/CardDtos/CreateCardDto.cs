
using System.ComponentModel.DataAnnotations;


namespace api.DTOs.CardDtos
{
    public class CreateCardDto
    {
        [Required]
        [StringLength(50, ErrorMessage = "Card holder name can't be longer than 50 characters.")]
        public string CardHolder { get; set; }

        [Required]
        [CreditCard(ErrorMessage = "Invalid card number")] // "creditcard" validates against common card number formats 
        public string CardNumber { get; set; }

        [Required]
        public string CVV { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Bank name can't be longer than 100 characters ")]
        public string BankName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ExpiryDate { get; set; }

        // UserID should not be in the DTO  it is retrieved from the logged-in user’s claims
        //card id is auto generated 
    }
}