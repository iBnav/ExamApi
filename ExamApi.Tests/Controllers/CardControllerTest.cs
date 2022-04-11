using ExamApi.Controllers;
using ExamApi.Domain.Models.Requests;
using ExamApi.Repository.UnitOfWork;
using ExamApi.Services.Interfaces;
using ExamApi.Services.Services;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using Xunit;

namespace ExamApi.Tests.Controllers
{
    public class CardControllerTest
    {
        protected Mock<IUnitOfWork> _uow;
        protected Mock<IMemoryCache> _memory;
        protected Mock<ICustomerCardService> _customerCardService;
        private readonly CardController _controller;
        public CardControllerTest()
        {
            _uow = new Mock<IUnitOfWork>();
            _memory = new Mock<IMemoryCache>();
            _customerCardService = new Mock<ICustomerCardService>();
            _controller = new CardController(new CardService(_uow.Object, _memory.Object, _customerCardService.Object));
        }

        [Fact]
        private void ShouldReturnStatusOk()
        {
            SaveCardRequest request = new SaveCardRequest
            {
                CardNumber = 1234567890123456,
                CustomerId = 1,
                Cvv = 123
            };

            var response = _controller.SaveCard(request);

            Assert.NotNull(response.Result);
        }

        [Fact]
        private void ShouldReturnStatusUnprocessableEntityWhenCardNumberIsNull()
        {
            SaveCardRequest request = new SaveCardRequest
            {
                CustomerId = 1,
                Cvv = 123
            };

            var response = _controller.SaveCard(request);

            Assert.True(response.Result.Value?.Error?.StatusCode == 422);
        }

        [Fact]
        private void ShouldReturnStatusUnprocessableEntityWhenCvvIsNull()
        {
            SaveCardRequest request = new SaveCardRequest
            {
                CardNumber = 1234567890123456,
                CustomerId = 1
            };

            var response = _controller.SaveCard(request);

            Assert.True(response.Result.Value?.Error?.StatusCode == 422);
        }

        [Fact]
        private void ShouldReturnStatusUnprocessableEntityWhenCustomerIdIsNull()
        {
            SaveCardRequest request = new SaveCardRequest
            {
                CardNumber = 1234567890123456,
                Cvv = 123
            };

            var response = _controller.SaveCard(request);

            Assert.True(response.Result.Value?.Error?.StatusCode == 422);
        }
    }
}
