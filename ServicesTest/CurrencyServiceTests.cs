using Models.DTOs.Currency;
using Moq;
using NUnit.Framework;
using Services;
using Services.Interfaces;

namespace ServicesTests
{
    [TestFixture]
    public class CurrencyServiceTests
    {
        private ICurrencyService _Service;
        private Mock<ICurrencyService> _mockCurrencyService;

        [SetUp]
        public void SetUp()
        {
            _mockCurrencyService = new Mock<ICurrencyService>();
        }

        [Test]
        public async Task GetCurrentPriceAsyncReturnsGracefully()
        {
            // Arrange
            string content = @"[""347.500"",""365.500"",""Actualizada al 18/8/2023 15:00""]";
            CurrencyPriceResponse currencyPriceResponse = new CurrencyPriceResponse()
            {
                BuyPrice = 50,
                SellPrice = 50,
                UpdatedDate = "Actualizada al 18/8/2023 15:00"
            };

            // Action
            var result = _mockCurrencyService.Setup(x => x.GetCurrentPriceAsync("USD"))
                .ReturnsAsync(currencyPriceResponse);

            // Asserts
            NUnit.Framework.Assert.NotNull(result);
        }
    }
}
