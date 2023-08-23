using Lib.Exceptions;
using Microsoft.Extensions.Logging;
using Models.DTOs.Exchange;
using Services.Interfaces;

namespace Services
{
    public class ExchangeService : IExchangeService
    {
        private readonly IExchangeRepository _exchangeRepository;
        private readonly ICurrencyService _currencyService;
        private readonly ICurrencyRepository _currencyRepository;
        private readonly ILogger<ExchangeService> _logger;

        public ExchangeService(
            IExchangeRepository exchangeRepository, 
            ICurrencyService currencyService, 
            ICurrencyRepository currencyRepository,
            ILogger<ExchangeService> logger)
        {
            _exchangeRepository = exchangeRepository;
            _currencyService = currencyService;
            _currencyRepository = currencyRepository;
            _logger = logger;
        }

        public async Task<ExchangeResponse> CreateExchangeAsync(ExchangeRequest request)
        {
            var currencyPrice = await _currencyService.GetCurrentPriceAsync(request.CurrencyCode);
            var convertedAmount = request.Amount / currencyPrice.SellPrice;
            var monthlyExchanges = await _exchangeRepository.GetMontlyTotalExchanges(request);
            var currencyLimit = await _currencyRepository.GetCurrencyLimit(request.CurrencyCode);
            var totalAmount = monthlyExchanges + convertedAmount;

            if (totalAmount > currencyLimit)
            {
                throw new AmountExceedsLimitException();
            }

            request.Amount = convertedAmount;
            var response = await _exchangeRepository.CreateExchange(request);

            if (response > 0)
            {
                return new ExchangeResponse()
                {
                    Id = response,
                    UserId = request.UserId,
                    CurrencyCode = request.CurrencyCode,
                    Amount = request.Amount,
                };
            }

            _logger.LogError(
                "HttpClient call return unsuccessfull status code, {@RequestName}, @{DateTime}",
                "Exchange",
                DateTime.Now);
            throw new Exception("An error occurs while trying to process your request, Please Contact your administrator for more information.");
        }
    }
}
