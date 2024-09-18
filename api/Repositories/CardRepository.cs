using api.Data;
using api.DTOs.CardDtos;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly IEncryptionService _encryptionService;
        private readonly ApplicationDBContext _context;
        public CardRepository(ApplicationDBContext context, IEncryptionService encryptionService)
        {
            _context = context;
            _encryptionService = encryptionService;
        }
        public async Task<CardDetails> CreateCardAsync(string userId, CreateCardDto createCardDto)
        {
            string encryptedCardNumber = _encryptionService.Encrypt(createCardDto.CardNumber);
            string encryptedCVV = _encryptionService.Encrypt(createCardDto.CVV);

            //MAPING THE dto to the card credentials
            var card = new CardDetails
            {
                CardHolder = createCardDto.CardHolder,
                CardNumber = encryptedCardNumber,
                ExpiryDate = createCardDto.ExpiryDate,
                CVV = encryptedCVV,
                BankName = createCardDto.BankName,
                UserID = userId // Assign the logged-in user's ID
            };

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

        public Task<CardDetails> GetCardsAsync(string userId, GetCardDto getCardDto)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CardDetails>> GetCardsByUserIdAsync(string userId)
        {
            var cards = await _context.CardDetails
               .Where(c => c.UserID == userId) // Filter cards by UserId
               .ToListAsync();                 // Convert to a list asynchronously

            // Decrypt the card details
            foreach (var card in cards)
            {
                card.CardNumber = _encryptionService.Decrypt(card.CardNumber); // Decrypt the card number
                card.CVV = _encryptionService.Decrypt(card.CVV);               // Decrypt the CVV
            }

            return cards;
        }
    }
}