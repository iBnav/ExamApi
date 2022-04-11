using ExamApi.Domain.Models.Requests;
using ExamApi.Domain.Models.Responses;
using ExamApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExamApi.Controllers
{
    [Route("api/card")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardService _cardService;
        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpPost]
        public async Task<ActionResult<SaveCardResponse>> SaveCard([FromBody] SaveCardRequest request)
        {
            var response = await _cardService.SaveCard(request);

            if (response.Error == null)
                return Created(string.Empty, response);
            else if (response.Error.StatusCode == 400)
                return BadRequest(response.Error.ErrorMessage);
            else if (response.Error.StatusCode == 422)
                return UnprocessableEntity(response.Error.ErrorMessage);
            else
                throw new Exception(response.Error.ErrorMessage, response.Error);

        }
    }
}
