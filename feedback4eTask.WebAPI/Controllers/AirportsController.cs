using feedback4eTask.DataAccess.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace feedback4eTask.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportsController : ControllerBase
    {
        IAirportRepository _productService;

        public AirportsController(IAirportRepository productService)
        {
            _productService = productService;
        }

        [HttpGet("getcountries")]
        public async Task<IActionResult> GetCountries()
        {
            var result = await _productService.GetCountries();
            if (result.Any())
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

    }
}
