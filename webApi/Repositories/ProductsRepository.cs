using Microsoft.EntityFrameworkCore;
using webApi.Models;
using webApi.Repositories.Interfaces;
using webApi.StoreSampleContext;

namespace webApi.Repositories
{
    public class ProductsRepository:IProductsRepository
    {
        private readonly StoreSampleContext.StoreSampleContext _sampleContext;
        public ProductsRepository(StoreSampleContext.StoreSampleContext _sampleContext) {
            this._sampleContext = _sampleContext;
        }
        public async Task<ICollection<Product>> GetProductsAsync()
        {
            return await _sampleContext.Products.ToListAsync();
        }
    }
}
