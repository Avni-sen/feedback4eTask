using feedback4eTask.Core.Entities;

namespace feedback4eTask.Entities.Concrete
{
    public class Airport : BaseEntity, IEntity
    {
        public string CityName { get; set; }
        public string CityIata { get; set; }
        public string? StateCode { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
    }
}
