
using System;

namespace Flight.Entities.Views
{
    public class OrderDetails
    {
        public int OrderID { get; set; }
        public string OrderStatus { get; set; }
        public int TicketId { get; set; }
        public string CustomerName { get; set; }
        public DateTime Departure { get; set; }
        public bool IsTransit { get; set; }
        public int NumberOfPersons { get; set; }
        public string CreditCardHolderName { get; set; }
        public int CreditCardNumber { get; set; }
    }
}
