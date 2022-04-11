using ExamApi.Domain.Entities;
using ExamApi.Domain.Models;
using ExamApi.Repository.UnitOfWork;
using ExamApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApi.Services.Services
{
    public class CustomerCardService : ICustomerCardService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomerCardService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #region public methods
        public void InsertCustomerCard(CustomerCardModel model)
        {
            if (model == null)
                throw new ArgumentNullException("CustomerCardModel");
            else
                Insert(model);
        }

        public CustomerCardModel SearchCustomerCardByCardId(int cardId)
        {
            if (cardId <= 0)
                return null;

            return new CustomerCardModel(SearchByCardId(cardId));
        }
        #endregion

        #region private methods
        private CustomerCardEntity SearchByCardId(int cardId)
        {
            return _unitOfWork.CustomerCardRepository.Get(x => x.CardId == cardId);
        }

        private void Insert(CustomerCardModel model)
        {
            _unitOfWork.CustomerCardRepository.Add(new CustomerCardEntity { CardId = model.CardId, CustomerId = model.CustomerId });
            _unitOfWork.Commit();
        }
        #endregion
    }
}
