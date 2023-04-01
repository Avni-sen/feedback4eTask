using feedback4eTask.Core.DataAccess;
using feedback4eTask.Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IAirportRepository : IEntityRepository<Airport>
    {
        Task<IEnumerable<Airport>> GetCountries();
        Task<IEnumerable<Airport>> GetCitiesByCountryName(string countryname);
    }
}
