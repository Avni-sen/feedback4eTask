using feedback4eTask.Core.Entities;

namespace feedback4eTask.Entities
{
    public class BaseEntity : IEntity
    {
        //table da ortak tutulacak alanlar arttığı zaman işimize yarayacak bir kısım...
        public int Id { get; set; }
    }
}
