using Microsoft.Azure.ServiceBus;

using Newtonsoft.Json;

using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Flight.Consumer
{
    class Program
    {

        private static IQueueClient client;
        static async Task Main(string[] args)
        {
            await ReceiveMessagesAsync();
        }

        private static async Task ReceiveMessagesAsync()
        {
            await Task.Factory.StartNew(() =>
            {
                client = new QueueClient(ApiConfiguration.AZURE_SERVICE_BUS_CONNECTIONSTRING,
                                         ApiConfiguration.QUEUE_NAME);
                var options = new MessageHandlerOptions(ExceptionMethod)
                {
                    MaxConcurrentCalls = 1,
                    AutoComplete = false
                };
                client.RegisterMessageHandler(ExecuteMessageProcessing, options);
            });
            Console.Read();

        }

        private static async Task ExecuteMessageProcessing(Message message, CancellationToken arg2)
        {
            var order = JsonConvert.DeserializeObject<Order>(Encoding.UTF8.GetString(message.Body));
            Console.WriteLine($"Order before Update Order Status: {order.OrderStatus}" +
                                $",OrderId: {order.OrderId} ,TicketId: {order.TicketId}");
            await client.CompleteAsync(message.SystemProperties.LockToken);
            await UpdateOrder(order);
        }

        private static async Task UpdateOrder(Order order)
        {
            HttpClient _httpClient = new HttpClient();
            Array orderstates = Enum.GetValues(typeof(OrderStatus));
            Random random = new Random();
            order.OrderStatus = (OrderStatus)orderstates.GetValue(random.Next(orderstates.Length));
            Console.WriteLine($"order after updated :  {order}");
            var json = JsonConvert.SerializeObject(order);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{ApiConfiguration.BaseUrl}{ApiConfiguration.OrderEndpoint}"
                                                      , data);
        }
        private static async Task ExceptionMethod(ExceptionReceivedEventArgs arg)
        {
            await Task.Run(() =>
           Console.WriteLine($"Error occured. Error is {arg.Exception.Message}")
           );
        }
    }
}
