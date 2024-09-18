using api.DTOs.CardDtos;
using api.Models;

namespace api.Mappers.CardMappers
{
    public static class CardMapper
    {
        public static GetCardDto ToGetCardDto(this CardDetails cardDetailsModel)
        {
            if (cardDetailsModel == null)
            {
                return null;
            }

            return new GetCardDto
            {
                BankName = cardDetailsModel.BankName
            };
        }
    }
}