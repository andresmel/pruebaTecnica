using webApi.Models;
using webApi.Models.Dtos;
using webApi.Repositories.Interfaces;
using webApi.Services.Interfaces;

namespace webApi.Services
{
    public class ProductsService:IProductsService
    {

        private readonly IProductsRepository _productsRepository;
        public ProductsService(IProductsRepository _productsRepository) {
            this._productsRepository = _productsRepository;
        }

        public async Task<ICollection<ProductDto>> GetProductsAsync()
        {
            try
            {
                ICollection<Product> product=await _productsRepository.GetProductsAsync();
                return product.Select(o => new ProductDto
                {
                    Productid = o.Productid,
                    Productname = o.Productname,
                }).ToList();
            }
            catch (Exception ex) {
                throw new ApplicationException("Error processing order", ex);
            }
        
        }
    }
}
