using Flight.Entities.Entities;

using System.Threading.Tasks;

namespace Flight.Entities.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Customer> CustomerRepository { get; }
        ICustomerRepository SpecficCustomerRepository { get; }
        IRepository<Ticket> TicketRepository { get; }
        IRepository<Country> CountryRepository { get; }
        IRepository<CreditCard> CreditCardRepository { get; }
        IRepository<Order> OrderRepository { get; }
        IOrderRepository SpecficOrderRepository { get; }

        Task<int> SaveChangesAsync();
    }
}
