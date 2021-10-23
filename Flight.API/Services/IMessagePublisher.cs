using System.Threading.Tasks;

namespace Flight.API.Services
{
    public interface IMessagePublisher
    {
        Task Publish<T>(T t);
    }
}
