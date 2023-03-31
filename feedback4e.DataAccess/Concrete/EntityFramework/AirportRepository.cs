using feedback4eTask.Core.DataAccess.EntityFramework;
using feedback4eTask.DataAccess.Abstract;
using feedback4eTask.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace feedback4eTask.DataAccess.Concrete.EntityFramework
{
    public class AirportRepository : EfEntityRepositoryBase<Airport, FeedBack4eTaskContext>, IAirportRepository
    {
        public AirportRepository(FeedBack4eTaskContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Airport>> GetCountries()
        {
            var list = await Context.Airports.Select(x => new Airport
            {
                Id = x.Id,
                CountryCode = x.CountryCode,
                CountryName = x.CountryName
            }).ToListAsync();

            return list;
        }
    }
}
