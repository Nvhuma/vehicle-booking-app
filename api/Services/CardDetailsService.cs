

namespace api.Services

{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;
	using api.Data;
	using api.Interfaces;
	using api.Models;
	using Microsoft.EntityFrameworkCore;

	public class CardDetailsService : ICardDetailsService
	{
		private readonly ApplicationDBContext _context;

		public CardDetailsService(ApplicationDBContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));

		}


		public async Task<CardDetails> GetCardDetailsByIdAsync(int Id, string UserID)
		{

			return await _context.CardDetails
							 .FirstOrDefaultAsync(c => c.Id == Id && c.UserID == UserID);

		}

		public async Task UpdateCardAsync(CardDetails card)
		{
			_context.CardDetails.Update(card);
			await _context.SaveChangesAsync();
		}
	}
}