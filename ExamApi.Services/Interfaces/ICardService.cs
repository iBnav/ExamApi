using ExamApi.Domain.Models;
using ExamApi.Domain.Models.Requests;
using ExamApi.Domain.Models.Responses;

namespace ExamApi.Services.Interfaces
{
    public interface ICardService
    {
        CardModel SearchCardById(int id);
        Task<SaveCardResponse> SaveCard(SaveCardRequest request);
    }
}
