namespace api.Models
{

	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;


	public class CardDetails
	{
		public int Id { get; set; }
		public required string CardHolder { get; set; }
		public required string CardNumber { get; set; }
		public DateTime ExpiryDate { get; set; }
		public required string CVV { get; set; }
		public string? BankName { get; set; }
		public string? UserID { get; set; }
		public decimal Balance { get; set; }
		public AppUser? AppUser { get; set; }
	}
}
