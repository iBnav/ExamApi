using ExamApi.Controllers;
using ExamApi.Domain.Models;
using ExamApi.Domain.Models.Requests;
using ExamApi.Repository.UnitOfWork;
using ExamApi.Services.Interfaces;
using ExamApi.Services.Services;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using Xunit;

namespace ExamApi.Tests.Controllers
{
    public class TokenControllerTest
    {
        protected Mock<IUnitOfWork> _uow;
        protected Mock<IMemoryCache> _memory;
        protected Mock<ICustomerCardService> _customerCardService;
        protected Mock<ICardService> _cardService;
        private readonly TokenController _controller;

        public TokenControllerTest()
        {
            _uow = new Mock<IUnitOfWork>();
            _memory = new Mock<IMemoryCache>();
            _customerCardService = new Mock<ICustomerCardService>();
            _cardService = new Mock<ICardService>();
            _controller = new TokenController(new TokenService(_memory.Object, _customerCardService.Object, _cardService.Object));
        }

        [Fact]
        private void ShouldReturnValidatedFalseWhenWrongToken()
        {
            ValidateTokenRequest request = new ValidateTokenRequest
            {
                CardId = 1,
                CustomerId = 1,
                Cvv = 123,
                Token = 1234567890123456
            };
            _memory.Setup(m => m.Get(1)).Returns(new TokenModel(new CardModel { CardId = 1, CardNumber = 1234567890123456, Cvv = 123 }));
            var response = _controller.ValidateToken(request);
            Assert.False(response.Validated);
        }

        [Fact]
        private void ShouldReturnValidatedFalseWhenWrongCvv()
        {
            ValidateTokenRequest request = new ValidateTokenRequest
            {
                CardId = 1,
                CustomerId = 1,
                Cvv = 125,
                Token = 1234567890123456
            };
            _memory.Setup(m => m.Get(1)).Returns(new TokenModel(new CardModel { CardId = 1, CardNumber = 1234567890123456, Cvv = 123 }));
            var response = _controller.ValidateToken(request);
            Assert.False(response.Validated);
        }

        private void ShouldReturnValidatedFalseWhenWrongCustomerId()
        {
            ValidateTokenRequest request = new ValidateTokenRequest
            {
                CardId = 1,
                CustomerId = 2,
                Cvv = 123,
                Token = 1234567890123456
            };
            _memory.Setup(m => m.Get(1)).Returns(new TokenModel(new CardModel { CardId = 1, CardNumber = 1234567890123456, Cvv = 123 }));
            var response = _controller.ValidateToken(request);
            Assert.False(response.Validated);
        }

        [Fact]
        private void ShouldReturnValidatedTrue()
        {
            ValidateTokenRequest request = new ValidateTokenRequest
            {
                CardId = 1,
                CustomerId = 1,
                Cvv = 123,
                Token = 6789012345612345
            };
            _memory.Setup(m => m.Get(1)).Returns(new TokenModel(new CardModel { CardId = 1, CardNumber = 1234567890123456, Cvv = 123 }));
            var response = _controller.ValidateToken(request);
            Assert.True(response.Validated);
        }
    }
}
