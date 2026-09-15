namespace WebApi.Models.Common
{
    public class ApiResult<T>
    {
        public bool IsSuccessed { get; set; }

        public string Message { get; set; } = string.Empty;
        public T? Count { get; set; }

        public T? ResultObj { get; set; }
    }
}
