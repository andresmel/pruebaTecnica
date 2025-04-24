using Microsoft.AspNetCore.Mvc;
using webApi.Models.Dtos;
using webApi.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeesService _employeesService;
        public EmployeesController(IEmployeesService _employeesService)
        {
            this._employeesService = _employeesService;
        }

        [HttpGet("employees")]
        public async Task<IActionResult> GetEmployees()
        {
            responseApi res = new responseApi();
            try
            {
                var result = await this._employeesService.GetEmployesSync();
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
