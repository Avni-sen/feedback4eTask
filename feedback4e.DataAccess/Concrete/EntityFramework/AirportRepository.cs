using DataAccess.Abstract;
using feedback4eTask.Core.DataAccess.EntityFramework;
using feedback4eTask.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace feedback4eTask.DataAccess.Concrete.EntityFramework
{
    public class AirportRepository : EfEntityRepositoryBase<Airport, FeedBack4eTaskContext>, IAirportRepository
    {

        public async Task<IEnumerable<Airport>> GetCitiesByCountryName(string countryname)
        {
            using (FeedBack4eTaskContext context = new())
            {
                var list = await context.Airports.Where(z => z.CountryName == countryname)
                     .GroupBy(x => new { x.CityName, x.CityIata })
                     .Select(g => new Airport
                     {
                         Id = g.First().Id,
                         CityName = g.Key.CityName,
                         CityIata = g.Key.CityIata
                     }).Distinct().ToListAsync();

                return list;
            }
        }

        public async Task<IEnumerable<Airport>> GetCountries()
        {
            using (FeedBack4eTaskContext context = new())
            {
                var list = await context.Airports
                    .GroupBy(x => new { x.CountryName, x.CountryCode })
                    .Select(g => new Airport
                    {
                        Id = g.First().Id,
                        CountryCode = g.Key.CountryCode,
                        CountryName = g.Key.CountryName
                    }).Distinct().ToListAsync();

                return list;
            }
        }

    }
}
