namespace Flight.API
{
    public class Response<T>
    {
        public Response()
        {

        }
        public Response(T data)
        {
            Data = data;
            IsSucceeded = true;
            Message = string.Empty;
            Error = string.Empty;
        }
        public bool IsSucceeded { get; set; }
        public T Data { get; set; }
        public string Error { get; set; }
        public string Message { get; set; }
    }
}
