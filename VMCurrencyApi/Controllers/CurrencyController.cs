using Microsoft.AspNetCore.Mvc;
using Models.DTOs.Currency;
using Services.Interfaces;

namespace VMCurrencyApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyService _currencyService;
        private readonly ILogger<CurrencyController> _logger;

        public CurrencyController(ICurrencyService currencyService, ILogger<CurrencyController> logger)
        {
            _currencyService = currencyService;    
            _logger = logger;
        }

        /// <summary>
        ///     This will be a simple get to retrieve the currency price of the ISOCode supplied.
        /// </summary>
        /// <param name="code"></param>
        /// <returns>CurrencyPrice object with the currency info.</returns>
        /// <exception cref="ArgumentException">Will thow an descriptive exception.</exception>
        [HttpGet("{code}")]
        [ProducesResponseType(typeof(CurrencyPriceResponse), 200)]
        public async Task<IActionResult> Get([FromRoute] string code)
        {
            _logger.LogInformation(
                "Starting request {@RequestName}, {@DateTime}",
                "Currency/"+code,
                DateTime.Now);

            var response = await _currencyService.GetCurrentPriceAsync(code);

            _logger.LogInformation(
                "Completed request {@RequestName}, {@DateTime}",
                "Currency/"+code,
                DateTime.Now);

            return Ok(response);
        }
    }
}
