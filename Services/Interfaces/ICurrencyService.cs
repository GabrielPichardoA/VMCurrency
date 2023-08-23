using Models.DTOs.Currency;
using Models.DTOs.Exchange;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ICurrencyService
    {
        Task<CurrencyPriceResponse> GetCurrentPriceAsync(string code);
    }
}
