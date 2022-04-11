using ExamApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApi.Services.Interfaces
{
    public interface ICustomerCardService
    {
        void InsertCustomerCard(CustomerCardModel model);
        CustomerCardModel SearchCustomerCardByCardId(int customerId);
    }
}
