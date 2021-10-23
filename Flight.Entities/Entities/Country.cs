using System.Collections.Generic;

namespace Flight.Entities.Entities
{
    public class Country : BaseEntity
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Ticket> Ticket { get; set; } = new HashSet<Ticket>();
    }
}
