using webApi.Models;

namespace webApi.Repositories.Interfaces
{
    public interface IProductsRepository
    {
        Task<ICollection<Product>> GetProductsAsync();
    }
}
