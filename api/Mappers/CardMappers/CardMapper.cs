using api.DTOs.CardDtos;
using api.Models;

namespace api.Mappers.CardMappers
{
    public static class CardMapper
    {
        public static GetCardDto ToGetCardDto (this CardDetails cardDetails)
        {
            if (cardDetails == null)
            {
                return null;
            }

            return new GetCardDto
            {
                Id = cardDetails.Id,
                CardHolder = cardDetails.CardHolder,
                CardNumber = cardDetails.CardNumber,
                CVV = cardDetails.CVV,
                ExpiryDate = cardDetails.ExpiryDate
            };
        }
    }
}