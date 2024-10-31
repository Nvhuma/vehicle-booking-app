
namespace api.DTOs.CardDtos


{

	using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading.Tasks;

    public class PaymentRequest

    {
			public decimal Amount { get; set;}

        public int Id { get; set; }

			  	public int BookingId { get; set; }

					public string ?CardNumber { get; set; }
        public string? CardExpiry { get; set; } // Format: MM/YY
        public string? CardCvc { get; set; }

				 public DateTime PaymentDate { get; set; }


    }
}