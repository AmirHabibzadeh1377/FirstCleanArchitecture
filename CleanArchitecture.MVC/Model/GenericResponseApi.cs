namespace CleanArchitecture.MVC.Model
{
    public class GenericResponseApi<T>
    {
        public string Message { get; set; }
        public string ValidationError { get; set; }
        public bool Success { get; set; }
        public T Data { get; set; }
    }
}