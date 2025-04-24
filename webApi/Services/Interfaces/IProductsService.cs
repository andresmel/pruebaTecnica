using webApi.Models.Dtos;

namespace webApi.Services.Interfaces
{
    public interface IProductsService
    {
        Task<ICollection<ProductDto>> GetProductsAsync();
      
    }
}
