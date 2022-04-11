using ExamApi.Domain.Entities;
using ExamApi.Domain.Models;
using ExamApi.Domain.Models.CustomException;
using ExamApi.Domain.Models.Requests;
using ExamApi.Domain.Models.Responses;
using ExamApi.Repository.UnitOfWork;
using ExamApi.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System.Net;

namespace ExamApi.Services.Services
{
    public class CardService : ICardService
    {
        #region params
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMemoryCache _memoryCache;
        private readonly ICustomerCardService _customerCardService;
        #endregion

        #region constructor
        public CardService(IUnitOfWork unitOfWork, IMemoryCache memoryCache, ICustomerCardService customerCardService)
        {
            _unitOfWork = unitOfWork;
            _memoryCache = memoryCache;
            _customerCardService = customerCardService;
        }
        #endregion

        #region public methods
        public async Task<SaveCardResponse> SaveCard(SaveCardRequest request)
        {
            var response = ValidateRequest(request);
            if (response.Error is not null)
                return response;

            var card = new CardModel { CardNumber = request.CardNumber, Cvv = request.Cvv};
            TokenModel token = new TokenModel(card);

            card.CardId = SaveCard(card).CardId;
            SaveCustomerCard(request.CustomerId, card.CardId);
            await CacheToken(token, card.CardId);
            
            response.CardId = card.CardId;
            response.RegistrationDate = token.RegistrationDate;
            response.Token = token.TokenNumber;

            return response;
        }

        public CardModel SearchCardById(int id)
        {
            if (id <= 0)
                return null;

            return new CardModel(SearchById(id));
        }
        #endregion

        #region private methods
        private CardEntity SearchById(int id)
        {
            return _unitOfWork.CardRepositoy.Get(x => x.CardId == id);
        }

        private SaveCardResponse ValidateRequest(SaveCardRequest request)
        {
            if (request.CardNumber == 0 || request.CardNumber.ToString().Length > 16)
                return new SaveCardResponse { Error = new AppException(HttpStatusCode.UnprocessableEntity, "Invalid card number") };

            if (request.Cvv == 0 || request.Cvv.ToString().Length > 5)
                return new SaveCardResponse { Error = new AppException(HttpStatusCode.UnprocessableEntity, "Invalid cvv") };

            if (request.CustomerId == 0)
                return new SaveCardResponse { Error = new AppException(HttpStatusCode.UnprocessableEntity, "Invalid customer id") };

            return new SaveCardResponse { Error = null};
        }

        private CardEntity SaveCard(CardModel model)
        {
            var entity = new CardEntity(model);
            _unitOfWork.CardRepositoy.Add(entity);
            _unitOfWork.Commit();

            return entity;
        }

        private void SaveCustomerCard(int customerId, int cardId)
        {
            _customerCardService.InsertCustomerCard(new CustomerCardModel { CardId = cardId, CustomerId = customerId });
        }

        private Task CacheToken(TokenModel token, int cardId)
        {
            var entryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30),
                SlidingExpiration = TimeSpan.FromMinutes(30),
            };

            _memoryCache.Set(cardId, token, entryOptions);
            
            return Task.CompletedTask;
        }
        #endregion
    }
}
