using Flight.Entities.Entities;
using Flight.Entities.Interfaces;
using Flight.Infrastructre.Data;
using Flight.Infrastructre.Repostiory;

using System.Linq;
using System.Threading.Tasks;

namespace Flight.Infrastructure.Repostiory
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(FlightDbContext context) : base(context)
        {

        }
        public Task<bool> CustomerExists(string customerName)
        {
            var existingCustomer = _context.Customers.Any(c => c.Name == customerName);
            if (existingCustomer)
                return Task.FromResult(true);
            return Task.FromResult(false);
        }



    }
}
