using Flight.Entities.Entities;
using Flight.Entities.Interfaces;
using Flight.Entities.Views;
using Flight.Infrastructre.Data;
using Flight.Infrastructre.Repostiory;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight.Infrastructure.Repostiory
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(FlightDbContext context) : base(context)
        {

        }
        public Task<IQueryable<OrderDetails>> GetOrdersWithDetails()
        {
            // TODO: Add view for this join query
            var query = (from o in _context.Orders
                         join t in _context.Tickets
                         on o.TicketId equals t.TicketId
                         join c in _context.Customers
                         on o.CustomerId equals c.CustomerId
                         join country in _context.Countries
                         on t.CountryId equals country.CountryId
                         join crd in _context.CreditCards
                         on c.CustomerId equals crd.Customer.CustomerId
                         where o.IsDeleted == false
                         select (new OrderDetails
                         {
                             OrderID = o.OrderId,
                             OrderStatus = o.OrderStatus.ToString(),
                             NumberOfPersons = t.Quantity,
                             CustomerName = c.Name,
                             TicketId = t.TicketId,
                             Departure = t.Departure,
                             IsTransit = t.IsTransit,
                             CreditCardHolderName = crd.HolderName,
                             CreditCardNumber = crd.CreditCardNumber
                         }));

            return Task.FromResult(query);
        }
    }
}
