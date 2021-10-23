using Flight.Core.Dtos;
using Flight.Entities.Entities;
using Flight.Entities.Views;

using System.Linq;
using System.Threading.Tasks;

namespace Flight.Core.Interfaces
{
    public interface IOrderService
    {
        Task<Order> CreateOrder(OrderForCreateDto orderForCreateDto);
        Task<Order> UpdateOrder(OrderForUpdateDto orderForUpdateDto);
        Task<IQueryable<OrderDetails>> GetOrderDetails();
    }
}
