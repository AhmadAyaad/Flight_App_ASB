using Flight.Entities.Enums;

namespace Flight.Entities.Entities
{
    public class Order : BaseEntity
    {
        public int OrderId { get; set; }
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }
        public OrderStatus OrderStatus { get; set; } = OrderStatus.Pending;

    }
}
