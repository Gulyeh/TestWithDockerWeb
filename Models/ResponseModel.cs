namespace Task1_0.Models
{
    public class ResponseModel<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public T? Content { get; set; }
    }
}