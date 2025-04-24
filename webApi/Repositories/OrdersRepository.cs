using Microsoft.EntityFrameworkCore;
using webApi.Models;
using webApi.Models.Dtos;
using webApi.Repositories.Interfaces;
using webApi.StoreSampleContext;


namespace webApi.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly StoreSampleContext.StoreSampleContext _storesamplecontext;
        public OrdersRepository(StoreSampleContext.StoreSampleContext _storesamplecontext)
        {
            this._storesamplecontext = _storesamplecontext;
        }
        public async Task<ICollection<Order>> GetOrdersAsync()
        {
            return await this._storesamplecontext.Orders.ToListAsync();
        }

        public async Task<ICollection<Order>> GetOrdersbyCostumer(orderByCustomerDto data)
        {
            return await _storesamplecontext.Orders.Where(o => o.Custid == data.custid).ToListAsync();
        }

        public async Task<int> postOrder(postOrderDto order)
        {
            this._storesamplecontext.Orders.Add(new Order
            {
                Custid = order.custid,
                Empid = order.employee,
                Orderdate = order.orderDate,
                Requireddate = order.requiredDate,
                Shippeddate = order.shippedDate,
                Shipperid = order.shipper,
                Freight = order.freight,
                Shipname = order.shipName,
                Shipaddress = order.shipAddress,
                Shipcity = order.shipCity,
                Shipcountry = order.shipCountry
            });
            int res= this._storesamplecontext.SaveChanges();
                return res > 0 ? 1 : 0;
        }

        public async Task<int> postOrderDetails(postOrderDto order)
        {
            var res = _storesamplecontext.Orders.OrderByDescending(o => o.Orderid).FirstOrDefault();
            if (res != null)
            {
                _storesamplecontext.OrderDetails.Add(new OrderDetail
                {
                    Orderid = res.Orderid,
                    Productid = order.product,
                    Unitprice = order.unitPrice,
                    Qty=order.quantity,
                    Discount=order.discount,
                });
                int resDetails= this._storesamplecontext.SaveChanges();
                return resDetails > 0 ? 1 : 0;
            }
            else {
                return 0;
            }
            
        }
    }
}
