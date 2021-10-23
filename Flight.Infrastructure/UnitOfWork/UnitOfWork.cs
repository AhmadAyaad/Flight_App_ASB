using Flight.Entities.Entities;
using Flight.Entities.Interfaces;
using Flight.Infrastructre.Data;

using System.Threading.Tasks;

namespace Flight.Infrastructre.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FlightDbContext _context;
        public UnitOfWork(FlightDbContext context
                         , IRepository<Customer> customerRepository
                         , IRepository<Ticket> ticketRepository
                         , IRepository<CreditCard> creditCardRepository
                         , IRepository<Country> countryReposiotry
                         , IRepository<Order> orderReposiotry
                         , ICustomerRepository specficCustomerRepository
                         , IOrderRepository specficOrderRepository)
        {
            _context = context;
            CustomerRepository = customerRepository;
            SpecficCustomerRepository = specficCustomerRepository;
            SpecficOrderRepository = specficOrderRepository;
            TicketRepository = ticketRepository;
            CreditCardRepository = creditCardRepository;
            CountryRepository = countryReposiotry;
            OrderRepository = orderReposiotry;
        }

        public IRepository<Customer> CustomerRepository { get; }
        public IRepository<Ticket> TicketRepository { get; }
        public IRepository<Country> CountryRepository { get; }
        public IRepository<CreditCard> CreditCardRepository { get; }
        public IRepository<Order> OrderRepository { get; }
        public ICustomerRepository SpecficCustomerRepository { get; }

        public IOrderRepository SpecficOrderRepository { get; }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

    }
}
