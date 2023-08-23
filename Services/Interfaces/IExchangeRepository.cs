using Models.DTOs.Exchange;

namespace Services.Interfaces
{
    public interface IExchangeRepository
    {
        Task<int> CreateExchange(ExchangeRequest request);
        Task<double> GetMontlyTotalExchanges(ExchangeRequest request);
    }
}
