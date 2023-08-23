using Microsoft.EntityFrameworkCore;
using Models.DatabaseModels;
using Models.DTOs.Exchange;
using Services.Interfaces;

namespace Data.Repositories
{
    public class ExchangeRepository : IExchangeRepository
    {
        protected readonly VMCurrencyDBContext _dbContext;

        public ExchangeRepository(VMCurrencyDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateExchange(ExchangeRequest request)
        {
            var entity = new Exchange()
            {
                UserId = request.UserId,
                CurrencyId = request.CurrencyCode,
                Amount = request.Amount,
                CreationDate = DateTime.UtcNow
            };
            
            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<double> GetMontlyTotalExchanges(ExchangeRequest request)
        {
            DateTime now = DateTime.Now;
            int currentMonth = now.Month;

            double sumAmount = _dbContext.Exchanges
                .Where(a => a.UserId == request.UserId &&
                            a.CreationDate.Month == currentMonth &&
                            a.CurrencyId == request.CurrencyCode)
                .Sum(a => a.Amount);

            return sumAmount;
        }
    }
}
