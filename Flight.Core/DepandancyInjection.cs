using Flight.Core.Interfaces;
using Flight.Core.Services;

using Microsoft.Extensions.DependencyInjection;

namespace Flight.Core
{
    public class DepandancyInjection
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ICountryService, CountryService>();
        }
    }
}
