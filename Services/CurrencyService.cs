using Lib.Exceptions;
using Microsoft.Extensions.Logging;
using Models.DTOs.Currency;
using Services.Interfaces;
using System.Text.Json;

namespace Services
{
    public class CurrencyService : ICurrencyService
    {
        private static readonly HttpClient client = new HttpClient();
        private readonly ILogger<CurrencyService> _logger;

        public CurrencyService(ILogger<CurrencyService> logger)
        {
            _logger = logger;
        }

        public async Task<CurrencyPriceResponse> GetCurrentPriceAsync(string code)
        {
            switch (code.ToUpper())
            {
                case "USD":
                    return await GetUSDPrice();
                case "BRL":
                    return await GetBRLPrice();
                default:
                    _logger.LogError(
                        "Currency supplied is not valid, {@RequestName}, @{DateTime}",
                        "Currency/" + code,
                        DateTime.Now);
                    throw new InvalidCodeException();
            }
        }
        private async Task<CurrencyPriceResponse> GetUSDPrice()
        {
            var httpResponse = await client.GetAsync("https://www.bancoprovincia.com.ar/Principal/Dolar");
            if(httpResponse.IsSuccessStatusCode)
            {
                var response = await httpResponse.Content.ReadAsStringAsync();
                if (response != null)
                {
                    List<string> values = JsonSerializer.Deserialize<List<string>>(response);
                    return new CurrencyPriceResponse
                    {
                        BuyPrice = Convert.ToDouble(values?[0]),
                        SellPrice = Convert.ToDouble(values?[1]),
                        UpdatedDate = values?[2],
                        CurrencyCode = "USD"
                    };
                }
            }

            _logger.LogError(
                "HttpClient call return unsuccessfull status code, {@RequestName}, @{DateTime}",
                "Currency/code",
                DateTime.Now);
            throw new Exception("An error occurs while trying to process your request, Please Contact your administrator for more information.");
        }

        private async Task<CurrencyPriceResponse> GetBRLPrice()
        {
            var USDPrice = await GetUSDPrice();
            return new CurrencyPriceResponse
            {
                BuyPrice = USDPrice.BuyPrice / 4,
                SellPrice = USDPrice.SellPrice / 4,
                UpdatedDate = USDPrice.UpdatedDate,
                CurrencyCode = "BRL"
            };
        }
    }
}
