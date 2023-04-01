using feedback4eTask.Core.Utilities.Results.Abstract;
using feedback4eTask.Entities.Concrete;

namespace feedback4eTask.Business.Handlers.Airports.Abstract
{
    public interface IAirportService
    {
        Task<IDataResult<IEnumerable<Airport>>> GetCountries();
        Task<IDataResult<IEnumerable<Airport>>> GetCitiesByCountryName(string countryname);
        Task<IDataResult<int>> CalculateAirportsMesurement(CalculateAirportsRequest calculateAirportsRequest);
    }
}
