namespace api.Models
{
    using System;
	using System.ComponentModel.DataAnnotations;

	public class ServicePrice
    {
       public int Id { get; set; }
    public int VehicleModelId { get; set; }
    public int ServiceTypeId { get; set; }
   

		   [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        public decimal Price { get; set; }

        public void AdjustPrice(double percentage)
        {
            // Validate percentage range to avoid extreme adjustments
            if (percentage < -100)
                throw new ArgumentOutOfRangeException(nameof(percentage), "Percentage cannot be less than -100%.");

            // Adjust the price based on the given percentage
            decimal adjustedPrice = Price + Price * (decimal)(percentage / 100);
            if (adjustedPrice < 0)
                throw new InvalidOperationException("Adjusted price cannot be negative.");

            Price = adjustedPrice;
        }

    public VehicleModel VehicleModel { get; set; }
    public ServiceType ServiceType { get; set; }

    }
}
