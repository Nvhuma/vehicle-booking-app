

namespace api.Interfaces

{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;


    public interface ICardDetailsService
    



 
    {
         Task<CardDetails> GetCardDetailsByIdAsync(int Id, string UserID);

				 Task UpdateCardAsync (CardDetails card);
    }
}
    
