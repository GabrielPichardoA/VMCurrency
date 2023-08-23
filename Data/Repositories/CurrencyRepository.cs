using Microsoft.EntityFrameworkCore;
using Services.Interfaces;

namespace Data.Repositories
{
    public class CurrencyRepository : ICurrencyRepository
    {
        protected readonly VMCurrencyDBContext _dbContext;

        public CurrencyRepository(VMCurrencyDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<double> GetCurrencyLimit(string currencyCode)
        {
            var response = await _dbContext.Currencies.FirstOrDefaultAsync(x => x.Id == currencyCode);
            return response.Limit;
        }
    }
}
