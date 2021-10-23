using Flight.Core.Dtos;
using Flight.Entities.Entities;

using Microsoft.Extensions.Configuration;

using System.Threading.Tasks;

namespace Flight.Core.Interfaces
{
    public interface IAuthService
    {
        Task<Customer> Register(Customer customer, string password);
        Task<Customer> Login(string customerName, string password);
        void GenerateToken(IConfiguration configuration, CustomerLoginDto customerLoginDto);

        Task<bool> CustomerExists(string customerName);


    }
}
