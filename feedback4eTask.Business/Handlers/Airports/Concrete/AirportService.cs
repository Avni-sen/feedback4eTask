using DataAccess.Abstract;
using feedback4eTask.Business.Handlers.Airports.Validators;
using feedback4eTask.Core.Aspect.Autofac.Validation;
using feedback4eTask.Core.Utilities.Results.Abstract;
using feedback4eTask.Core.Utilities.Results.Concrete;
using feedback4eTask.Entities.Concrete;

namespace feedback4eTask.Business.Handlers.Airports.Abstract
{
    public class AirportService : IAirportService
    {

        IAirportRepository _airportRepository;

        public AirportService(IAirportRepository airportRepository)
        {
            _airportRepository = airportRepository;
        }

        public async Task<IDataResult<IEnumerable<Airport>>> GetCitiesByCountryName(string countryname)
        {
            return new SuccessDataResult<IEnumerable<Airport>>(await _airportRepository.GetCitiesByCountryName(countryname));
        }

        [ValidationAspect(typeof(AirportValidator))]
        //  [CacheAspect()]
        public async Task<IDataResult<IEnumerable<Airport>>> GetCountries()
        {
            return new SuccessDataResult<IEnumerable<Airport>>(await _airportRepository.GetCountries());
        }


        public async Task<IDataResult<int>> CalculateAirportsMesurement(CalculateAirportsRequest calculateAirportsRequest)
        {
            // işlemler burada yapılacak
            double ToRadians(double degrees)
            {
                return degrees * (Math.PI / 180);
            }

            double firstlon = calculateAirportsRequest.FirstAirportLon;
            double firstlat = calculateAirportsRequest.FirstAirportLot;
            double secondlon = calculateAirportsRequest.SecondAirportLon;
            double secondlat = calculateAirportsRequest.SecondAirportLot;

            const double earthRadius = 3958.75;
            double dLat = ToRadians(secondlat - firstlat);
            double dLon = ToRadians(secondlon - firstlon);
            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
               Math.Cos(ToRadians(firstlat)) * Math.Cos(ToRadians(secondlat)) *
               Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            var distance = earthRadius * c;

            // mil cinsinden uzaklık
            return new SuccessDataResult<int>((int)distance);
        }
    }
}
