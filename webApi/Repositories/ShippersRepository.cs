using Microsoft.EntityFrameworkCore;
using webApi.Models;
using webApi.Repositories.Interfaces;

namespace webApi.Repositories
{
    public class ShippersRepository:IShippersRepository
    {
        private readonly StoreSampleContext.StoreSampleContext _storeSampleContext;
        public ShippersRepository(StoreSampleContext.StoreSampleContext _storeSampleContext) {
            this._storeSampleContext = _storeSampleContext;
        }

        public async Task<ICollection<Shipper>> GetShipperAsync()
        {
                return await this._storeSampleContext.Shippers.ToListAsync();    
        }
    }
}
