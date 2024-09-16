using api.Data;
using api.DTOs.CardDtos;
using api.Interfaces;
using api.Models;

namespace api.Repositories
{
    public class CardRepository : ICardRepository
    {

        private readonly ApplicationDBContext _context;
        public CardRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<CardDetails> CreateCardAsync(string userId, CreateCardDto createCardDto)
        {
            //MAPING THE dto to the card credentials
            var card = new CardDetails
            {
                CardHolder = createCardDto.CardHolder,
                CardNumber = createCardDto.CardNumber,
                ExpiryDate = createCardDto.ExpiryDate,
                CVV = createCardDto.CVV,
                BankName = createCardDto.BankName,
                UserID = userId // Assign the logged-in user's ID
            };


            // [SQL - Staging the changes on sql]


            _context.CardDetails.Add(card);
            //now we save the card details 
            await _context.SaveChangesAsync();
            return card;
        }

        public async Task<CardDetails> DeleteCardAsync(string userId, int cardId)
        {
            var card = await _context.CardDetails.FindAsync(cardId);

            if (card == null)
            {
                return null;
            }

            if (card.UserID != userId)
            {
                throw new UnauthorizedAccessException("User not autherized to delete this card.");
            }

            _context.CardDetails.Remove(card);
            await _context.SaveChangesAsync();
            return card;
        }

        public async Task<CardDetails> GetCardsAsync(string userId, GetCardDto getCardDto)
        {
            throw new NotImplementedException();
        }
    }
}