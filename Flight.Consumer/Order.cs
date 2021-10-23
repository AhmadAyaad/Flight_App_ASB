namespace Flight.Consumer
{
    public class Order
    {
        public int OrderId { get; set; }
        public int TicketId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public override string ToString()
        {
            return $"Order Id : {OrderId }, TicketID: {TicketId} , OrderStatus : {OrderStatus} ";
        }
    }
}
