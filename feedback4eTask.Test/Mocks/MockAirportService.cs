using feedback4eTask.Business.Handlers.Airports.Abstract;
using feedback4eTask.Core.Utilities.Results.Abstract;
using feedback4eTask.Core.Utilities.Results.Concrete;
using feedback4eTask.Entities.Concrete;

namespace feedback4eTask.Test.Mocks
{
    public class MockAirportService : IAirportService
    {
        public Task<IDataResult<int>> CalculateAirportsMesurement(CalculateAirportsRequest calculateAirportsRequest)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<IEnumerable<Airport>>> GetCitiesByCountryName(string countryname)
        {
            var cities = new List<Airport> {
        new Airport { Id = 1, CityName = "Los Angeles" },
        new Airport { Id = 2, CityName = "New York" },
        new Airport { Id = 3, CityName = "Chicago" },
    };
            return Task.FromResult<IDataResult<IEnumerable<Airport>>>(new SuccessDataResult<IEnumerable<Airport>>(cities));
        }

        public async Task<IDataResult<IEnumerable<Airport>>> GetCountries()
        {
            var countries = new List<Airport>
            {
            new Airport { Id = 1, CountryName = "USA" },
            new Airport { Id = 2, CountryName = "Canada" }
            };

            return new SuccessDataResult<IEnumerable<Airport>> { Data = countries };
        }



    }

}
