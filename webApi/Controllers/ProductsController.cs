using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webApi.Models.Dtos;
using webApi.Services.Interfaces;

namespace webApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;
        public ProductsController(IProductsService _productsService) { 
             this._productsService = _productsService;
        }

        [HttpGet("product")]
        public async Task<IActionResult> GetProducts()
        {
            responseApi res = new responseApi();
            try
            {
                var result = await this._productsService.GetProductsAsync();
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
                    res.message = "success";
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
