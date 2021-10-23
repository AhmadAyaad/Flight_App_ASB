using Flight.Entities.Enums;

namespace Flight.Core.Dtos
{
    public class OrderForUpdateDto
    {
        public int OrderId { get; set; }
        public int TicketId { get; set; }
        public int CutomerId { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
