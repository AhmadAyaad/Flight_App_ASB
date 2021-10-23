namespace Flight.API
{
    public class PagedResponse<T> : Response<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
        public int TotalPages { get; set; }

        public PagedResponse(T data, int pageNumber, int pageSize, int totoalRecords, int totalPages)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalRecords = totoalRecords;
            TotalPages = totalPages;
            Data = data;
            Message = null;
            IsSucceeded = true;
            Error = null;
        }
    }
}
