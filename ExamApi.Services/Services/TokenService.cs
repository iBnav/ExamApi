using ExamApi.Domain.Models;
using ExamApi.Domain.Models.Requests;
using ExamApi.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApi.Services.Services
{
    public class TokenService : ITokenService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ICustomerCardService _customerCardService;
        private readonly ICardService _cardService;
        public TokenService(IMemoryCache memoryCache, ICustomerCardService customerCardService, ICardService cardService)
        {
            _memoryCache = memoryCache;
            _customerCardService = customerCardService;
            _cardService = cardService;
        }
        public bool IsValidToken(ValidateTokenRequest tokenRequest)
        {
            if (IsTokenExpired(tokenRequest.CardId))
                return false;

            if (!IsValidCustomerId(tokenRequest))
                return false;

            var card = _cardService.SearchCardById(tokenRequest.CardId);
            Console.WriteLine(card.CardNumber);

            if (!IsValidToken(card, tokenRequest))
                return false;

            return true;
        }

        private bool IsTokenExpired(int cardId)
        {
            TokenModel cachedToken = (TokenModel)_memoryCache.Get(cardId);
            if (cachedToken == null)
                return true;

            return false;
        }
        
        private bool IsValidCustomerId(ValidateTokenRequest tokenRequest)
        {
            var customerCard = _customerCardService.SearchCustomerCardByCardId(tokenRequest.CardId);
            if (customerCard.CustomerId != tokenRequest.CustomerId)
                return false;

            return true;
        }

        private bool IsValidToken(CardModel card, ValidateTokenRequest tokenRequest)
        {
            card.Cvv = tokenRequest.Cvv;
            TokenModel token = new TokenModel(card);

            if (token.TokenNumber != tokenRequest.Token)
                return false;

            return true;
        }
    }
}
