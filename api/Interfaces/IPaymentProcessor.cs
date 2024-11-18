
namespace api.Interfaces
{
	
using api.DTOs.CardDtos;
using api.Models;

    public interface IPaymentProcessor
    {
        Task<PaymentResult> ProcessPaymentAsync(PaymentRequest paymentRequest);
    }
}
