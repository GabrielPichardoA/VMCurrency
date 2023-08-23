using Microsoft.AspNetCore.Mvc;
using Models.DTOs.Exchange;
using Services.Interfaces;

namespace VMCurrencyApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExchangeController : ControllerBase
    {
        private readonly IExchangeService _exchangeService;
        private readonly ILogger<ExchangeController> _logger;

        public ExchangeController(IExchangeService exchangeService, ILogger<ExchangeController> logger)
        {
            _exchangeService = exchangeService;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ExchangeResponse), 200)]
        public async Task<IActionResult> Post([FromBody] ExchangeRequest request)
        {
            _logger.LogInformation(
                "Starting request {@RequestName}, {@DateTime}",
                "Exchange/" + request,
                DateTime.Now);

            var response = await _exchangeService.CreateExchangeAsync(request);

            _logger.LogInformation(
                "Starting request {@RequestName}, {@DateTime}",
                "Exchange/" + request,
                DateTime.Now);

            return Ok(response);
        }

    }
}
