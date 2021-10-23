namespace Flight.Consumer
{
    public class ApiConfiguration
    {
        public static string BaseUrl { get; set; } = "http://localhost:64885/api";
        public static string OrderEndpoint { get; set; } = "/order";
        public static string AZURE_SERVICE_BUS_CONNECTIONSTRING { get; set; }
        = "Endpoint=sb://flightservicesbus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=Osa5HaGDjluycq4LP/FeUKdyUEwbdakLle1yjRLpLwY=";
        public static string QUEUE_NAME { get; set; } = "flightappqueue";
    }
}
