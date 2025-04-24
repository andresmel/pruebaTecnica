using webApi.Models;
using webApi.Models.Dtos;
using webApi.Repositories;
using webApi.Repositories.Interfaces;
using webApi.Services.Interfaces;

namespace webApi.Services
{
    public class OrdersService:IOrderService
    {
        private readonly IOrdersRepository _iorders;
        public OrdersService(IOrdersRepository _iorders) {
            this._iorders = _iorders;
        }
        public async Task<ICollection<OrderDto>> GetOrdersAsync()
        {
            try
            {
                ICollection<Order> order = await _iorders.GetOrdersAsync();
                return order.Select(o => new OrderDto
                {
                    Orderid = o.Orderid,
                    Requireddate = o.Requireddate,
                    Shippeddate = o.Shippeddate,
                    Shipname = o.Shipname,
                    Shipaddress = o.Shipaddress,
                    Shipcity = o.Shipcity,
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error processing order", ex);
            }
           
        }


        public async Task<ICollection<Order>> GetOrdersbyCostumer(orderByCustomerDto data)
        {
            try
            {
                return await _iorders.GetOrdersbyCostumer(data);
            }
            catch(Exception ex)
            {
                throw new ApplicationException("Error processing order", ex);
            }
        }

        public async Task<int> postOrder(postOrderDto order)
        {
            try
            {
                if (Math.Abs(order.unitPrice) > 9.999M)
                {
                    return 0; 
                }
                var res=await _iorders.postOrder(order);
                if (res > 0)
                {
                    var resDetails = await _iorders.postOrderDetails(order);
                    if (resDetails > 0)
                        return 1;

                    return 0;
                }
                else
                {
                    return 0;
                }
            }catch(Exception ex)
            {
                throw new ApplicationException("error en el proceso", ex);
            }
        }
    }
}
