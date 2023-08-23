using Models.DTOs.Exchange;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IExchangeService
    {
        Task<ExchangeResponse> CreateExchangeAsync(ExchangeRequest request);
    }
}
