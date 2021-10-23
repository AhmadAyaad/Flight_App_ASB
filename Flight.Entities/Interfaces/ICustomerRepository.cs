using System.Threading.Tasks;

namespace Flight.Entities.Interfaces
{
    public interface ICustomerRepository
    {
        Task<bool> CustomerExists(string customerName);
    }
}
