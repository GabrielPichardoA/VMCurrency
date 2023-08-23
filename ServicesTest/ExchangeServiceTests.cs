using Models.DTOs.Exchange;
using Moq;
using NUnit.Framework;
using Services;
using Services.Interfaces;

namespace ServicesTests
{
    [TestFixture]
    public class ExchangeServiceTests
    {
        private IExchangeService _service;
        private Mock<IExchangeService> _mockExchangeService;

        [SetUp]
        public void SetUp()
        {
            _mockExchangeService = new Mock<IExchangeService>();
        }

        [Test]
        public async Task CreateExchangeAsyncExistsGracefully()
        {
            // Action
            var result = _mockExchangeService.Setup(x => x.CreateExchangeAsync(It.IsAny<ExchangeRequest>()))
                .ReturnsAsync(new ExchangeResponse());

            // Asserts
            NUnit.Framework.Assert.NotNull(result);
        }
    }
}
