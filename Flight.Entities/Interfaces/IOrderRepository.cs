using Flight.Entities.Views;

using System.Linq;
using System.Threading.Tasks;

namespace Flight.Entities.Interfaces
{
    public interface IOrderRepository
    {
        Task<IQueryable<OrderDetails>> GetOrdersWithDetails();

    }
}
