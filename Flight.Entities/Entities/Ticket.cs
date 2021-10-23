
using System;

namespace Flight.Entities.Entities
{
    public class Ticket : BaseEntity
    {
        public int TicketId { get; set; }
        public bool IsTransit { get; set; } = false;
        public int Quantity { get; set; }
        public string AirLine { get; set; }
        public DateTime Departure { get; set; }
        public int? CountryId { get; set; }
        public Country Country { get; set; }
    }
}
