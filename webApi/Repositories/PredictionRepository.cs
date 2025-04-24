using Microsoft.EntityFrameworkCore;
using webApi.Models.Dtos;
using webApi.Repositories.Interfaces;

namespace webApi.Repositories
{
    public class PredictionRepository : IPredictionsRepository
    {
        private readonly StoreSampleContext.StoreSampleContext _storeSampleContext;
        public PredictionRepository(StoreSampleContext.StoreSampleContext _storeSampleContext)
        {
            this._storeSampleContext = _storeSampleContext;
        }

        public async Task<ICollection<PredictionOrderDto>> GetPredictionOrderAsync(string query)
        {
            return await _storeSampleContext.PredictionOrders.FromSqlRaw(query).ToListAsync();
        }


    }
}
