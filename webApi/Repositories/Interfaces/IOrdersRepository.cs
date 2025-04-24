using webApi.Models;
using webApi.Models.Dtos;

namespace webApi.Repositories.Interfaces
{
    public interface IOrdersRepository
    {
        Task <ICollection<Order>> GetOrdersAsync ();

        Task<ICollection<Order>> GetOrdersbyCostumer(orderByCustomerDto data);

        Task<int>postOrder(postOrderDto order);

        Task<int> postOrderDetails(postOrderDto order);
    }
}
