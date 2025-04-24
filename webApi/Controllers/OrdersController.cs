using Microsoft.AspNetCore.Mvc;
using webApi.Models;
using webApi.Models.Dtos;
using webApi.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _iserviceorders;
        public OrdersController(IOrderService _iserviceorders)
        {
            this._iserviceorders = _iserviceorders;
        }

        [HttpGet("clientOrders")]
        public async Task<IActionResult> GetClientOrders()
        {
            responseApi res = new responseApi();

            try
            {
                var result = await this._iserviceorders.GetOrdersAsync();
                if (result != null)
                {
                    res.status = 200;
                    res.data = result;
                    res.message = "success";
                    return Ok(res);
                }
                else
                {
                    res.status = 404;
                    res.data = result;
                    res.message = "empty";
                    return NotFound(res);
                }
            }
            catch (ApplicationException ex)
            {
                res.status = 500;
                res.data = null;
                res.message = ex.Message;
                return BadRequest(res);
            }
        }

        [HttpPost("getOrdersByCustomer")]
        public async Task<IActionResult> GetOrderByCustomer([FromBody] orderByCustomerDto data)
        {
            responseApi res = new responseApi();

            try
            {
                var result = await this._iserviceorders.GetOrdersbyCostumer(data);
                if (result != null)
                {
                    res.status = 200;
                    res.data = result;
                    res.message = "success";
                    return Ok(res);
                }
                else
                {
                    res.status = 404;
                    res.data = result;
                    res.message = "empty";
                    return NotFound(res);
                }
            }
            catch (ApplicationException ex)
            {
                res.status = 500;
                res.data = null;
                res.message = ex.Message;
                return BadRequest(res);
            }
        }

        [HttpPost("postOrder")]
        public async Task<IActionResult> PostOrder([FromBody] postOrderDto order)
        {
            responseApi res = new responseApi();

            try
            {
                var result = await this._iserviceorders.postOrder(order);
                if (result != 0)
                {
                    res.status = 200;
                    res.data = result;
                    res.message = "success";
                    return Ok(res);
                }
                else
                {
                    res.status = 404;
                    res.data = result;
                    res.message = "empty";
                    return NotFound(res);
                }
            }
            catch (ApplicationException ex)
            {
                res.status = 500;
                res.data = null;
                res.message = ex.Message;
                return BadRequest(res);
            }
        }
    }
}
