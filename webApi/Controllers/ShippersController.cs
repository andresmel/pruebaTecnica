using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webApi.Models.Dtos;
using webApi.Services.Interfaces;

namespace webApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ShippersController : ControllerBase
    {

        private readonly IShipperService _shipperService;
        public ShippersController(IShipperService _shipperService)
        {
            this._shipperService = _shipperService;
        }

        [HttpGet("shippers")]
        public async Task<IActionResult> GetShippers()
        {
            responseApi res = new responseApi();
            try
            {
                var result = await this._shipperService.GetShipperAsync();
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
