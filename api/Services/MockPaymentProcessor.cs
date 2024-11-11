namespace api.Services
{


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.CardDtos;
using api.Interfaces;
using api.Models;


	public class MockPaymentProcessor : IPaymentProcessor
	{
		public  async Task<PaymentResult> ProcessPaymentAsync(PaymentRequest paymentRequest)
		{
			   await Task.Delay(2000); // Simulate processing time

        var isSuccessful = Random.Shared.NextDouble() > 0.5;

        return new PaymentResult
        {
            IsSuccess = isSuccessful,
            Message = isSuccessful ? "Payment successful" : "Payment failed",
            PaymentId = Guid.NewGuid().ToString()
        };
		}
	}
}