using feedback4eTask.Business.Handlers.Airports.Abstract;
using feedback4eTask.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportsController : ControllerBase
    {
        IAirportService _airportService;

        public AirportsController(IAirportService airportService)
        {
            _airportService = airportService;
        }

        [HttpGet("getcountries")]
        public async Task<IActionResult> GetCountries()
        {
            var result = await _airportService.GetCountries();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("getcitiesbycountryname")]
        public async Task<IActionResult> getCitiesByCountryName(string countryname)
        {
            var result = await _airportService.GetCitiesByCountryName(countryname);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result);
            }
        }


        [Produces("application/json", "text/plain")]
        [HttpPost]
        public async Task<IActionResult> calculateAirportsMesurement([FromBody] CalculateAirportsRequest request)
        {
            var result = await _airportService.CalculateAirportsMesurement(request);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result);
            }
        }

    }
}
