namespace api.Models
{
    using System;
	using Microsoft.EntityFrameworkCore.Metadata.Internal;

	public class VehicleModel
    {
         public int Id { get; set; }
    public string ? Make { get; set; }
    public string ? Model { get; set; }
    public int Year { get; set; }

		//Navigation
		 public ICollection<ServicePrice> ServicePrice { get; set; }

    }
}
