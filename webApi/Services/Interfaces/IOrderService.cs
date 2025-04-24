using webApi.Models;
using webApi.Models.Dtos;

namespace webApi.Services.Interfaces
{
    public interface IOrderService
    {
        Task<ICollection<OrderDto>> GetOrdersAsync();

        Task<ICollection<Order>> GetOrdersbyCostumer(orderByCustomerDto data);

        Task<int> postOrder(postOrderDto order);
    }
}
