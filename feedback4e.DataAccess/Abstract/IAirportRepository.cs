using feedback4eTask.Core.DataAccess;
using feedback4eTask.Entities.Concrete;

namespace feedback4eTask.DataAccess.Abstract
{
    public interface IAirportRepository : IEntityRepository<Airport>
    {

        Task<IEnumerable<Airport>> GetCountries();
    }
}
