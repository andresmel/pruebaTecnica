using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webApi.Models.Dtos;
using webApi.Services.Interfaces;

namespace webApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class PredictionController : ControllerBase
    {
        private readonly IPredictionsService _predictionsService;
        public PredictionController(IPredictionsService _predictionsService) { 
          this._predictionsService = _predictionsService;
        }

        [HttpGet("predictionOrders")]
        public async Task<IActionResult> PredictionOrder()
        {

            responseApi res = new responseApi();

            try
            {
                var result = await this._predictionsService.GetPredictionOrderAsync();
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
            catch (Exception ex)
            {
                res.status = 500;
                res.data = null;
                res.message = ex.Message;
                return BadRequest(res);
            }
        }


        [HttpPost("predictionOrdersByname")]
        public async Task<IActionResult> PredictionOrder([FromBody]PredictionOrderDto datos)
        { 

            responseApi res = new responseApi();

            try
            {
                var result = await this._predictionsService.GetPredictionByCustomeName(datos);
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

    }

}
