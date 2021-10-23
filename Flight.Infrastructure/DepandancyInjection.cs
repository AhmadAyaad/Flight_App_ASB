using Flight.Entities.Entities;
using Flight.Entities.Interfaces;
using Flight.Infrastructre.Data;
using Flight.Infrastructre.Repostiory;
using Flight.Infrastructure.Repostiory;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Flight.Infrastructre
{
    public class DepandancyInjection
    {
        public static void ConfigureServices(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<FlightDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
            services.AddScoped<IRepository<Customer>, Repository<Customer>>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IRepository<Ticket>, Repository<Ticket>>();
            services.AddScoped<IRepository<CreditCard>, Repository<CreditCard>>();
            services.AddScoped<IRepository<Country>, Repository<Country>>();
            services.AddScoped<IRepository<Order>, Repository<Order>>();
            services.AddScoped<IOrderRepository, OrderRepository>();
        }
    }
}
