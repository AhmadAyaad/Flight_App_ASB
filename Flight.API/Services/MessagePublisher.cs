using Microsoft.Azure.ServiceBus;

using Newtonsoft.Json;

using System.Text;
using System.Threading.Tasks;

namespace Flight.API.Services
{
    public class MessagePublisher : IMessagePublisher
    {
        private readonly IQueueClient _queueClient;

        public MessagePublisher(IQueueClient queueClient)
        {
            _queueClient = queueClient;
        }
        public Task Publish<T>(T t)
        {
            var objAsText = JsonConvert.SerializeObject(t, Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            var message = new Message(Encoding.UTF8.GetBytes(objAsText));
            return _queueClient.SendAsync(message);
        }
    }
}
