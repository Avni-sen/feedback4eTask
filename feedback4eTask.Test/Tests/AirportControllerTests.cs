using feedback4eTask.Business.Handlers.Airports.Abstract;
using feedback4eTask.Core.Utilities.Results.Concrete;
using feedback4eTask.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers;

namespace feedback4eTask.Test.Tests
{
    public class AirportControllerTests
    {


        [Fact]
        public async void GetCountries_Returns_OkObjectResult_With_Countries()
        {
            // Arrange
            var mockAirportService = new Mock<IAirportService>();
            var countries = new List<Airport>
            {
                new Airport { Id = 1, CountryName = "USA" },
                new Airport { Id = 2, CountryName = "Canada" }
            };
            var expectedResult = new SuccessDataResult<IEnumerable<Airport>>(countries);
            mockAirportService.Setup(x => x.GetCountries()).ReturnsAsync(expectedResult);
            var controller = new AirportsController(mockAirportService.Object);

            // Act
            var actionResult = await controller.GetCountries();

            // Assert
            Assert.IsType<OkObjectResult>(actionResult);
            var resultData = ((OkObjectResult)actionResult).Value;
            Assert.Equal(countries, resultData);
        }


        [Fact]
        public async void CalculateAirportsMesurement_InvalidRequest_Returns_BadRequestObjectResult()
        {
            // Arrange
            var mockAirportService = new Mock<IAirportService>();
            var request = new CalculateAirportsRequest { /* Geçersiz talep nesnesi */ };
            var expectedResult = new ErrorDataResult<int> { Data = default };
            mockAirportService.Setup(x => x.CalculateAirportsMesurement(request)).ReturnsAsync(expectedResult);
            var controller = new AirportsController(mockAirportService.Object);

            // Act
            var actionResult = await controller.calculateAirportsMesurement(request);

            // Assert
            Assert.IsType<BadRequestObjectResult>(actionResult);
            var resultData = ((BadRequestObjectResult)actionResult).Value;
            Assert.Equal(expectedResult, resultData);
        }

        [Fact]
        public async void GetCitiesByCountryName_ValidRequest_Returns_OkObjectResult_With_Cities()
        {
            // Arrange
            var mockAirportService = new Mock<IAirportService>();
            var countryName = "USA";
            var cities = new List<Airport> {
        new Airport { Id = 1, CityName = "Los Angeles" },
        new Airport { Id = 2, CityName = "New York" },
        new Airport { Id = 3, CityName = "Chicago" },
    };
            var expectedResult = new SuccessDataResult<IEnumerable<Airport>>(cities);
            mockAirportService.Setup(x => x.GetCitiesByCountryName(countryName)).ReturnsAsync(expectedResult);
            var controller = new AirportsController(mockAirportService.Object);

            // Act
            var actionResult = await controller.getCitiesByCountryName(countryName);

            // Assert
            Assert.IsType<OkObjectResult>(actionResult);
            var resultData = ((OkObjectResult)actionResult).Value;
            Assert.Equal(expectedResult.Data, resultData);
        }





    }
}
