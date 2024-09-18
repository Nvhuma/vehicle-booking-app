using api.DTOs.CardDtos;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Interfaces
{
    public interface ICardRepository 
    {
        // implement the _repo in the route
        Task<CardDetails> CreateCardAsync(string userId, CreateCardDto createCardDto);

        // Create route for getting card
        Task<CardDetails> GetCardsAsync(string userId, GetCardDto getCardDto);

        // implement the _repo in the route
        Task<CardDetails> DeleteCardAsync(string userId, int cardId);


        Task<List<CardDetails>> GetCardsByUserIdAsync(string userId);
    }
}