using feedback4eTask.Core.Aspect.Autofac.Caching;
using feedback4eTask.Core.Utilities.Results.Abstract;
using feedback4eTask.Core.Utilities.Results.Concrete;
using feedback4eTask.DataAccess.Abstract;
using feedback4eTask.Entities.Concrete;

namespace feedback4eTask.Business.Handlers.Airports.Queries
{
    public class GetCountries
    {
        private readonly IAirportRepository _airportRepository;

        public GetCountries(IAirportRepository airportRepository)
        {
            _airportRepository = airportRepository;
        }

        [CacheAspect(10)]
        public async Task<IDataResult<IEnumerable<Airport>>> Handle(GetCountries request, CancellationToken cancellationToken)
        {
            return new SuccessDataResult<IEnumerable<Airport>>(await _airportRepository.GetCountries());
        }
    }
}
