using ExamApi.Domain.Models.Requests;
using ExamApi.Domain.Models.Responses;
using ExamApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamApi.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public TokenController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost]
        public ValidateTokenResponse ValidateToken([FromBody]ValidateTokenRequest request)
        {
            return new ValidateTokenResponse { Validated = _tokenService.IsValidToken(request) };
        }
    }
}
