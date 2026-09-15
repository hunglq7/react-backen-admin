namespace WebApi.Models.Common
{
    public class ApiSuccessResult<T> : ApiResult<T>
    {
        public ApiSuccessResult(T resultObj)
        {
            IsSuccessed = true;
            ResultObj = resultObj;
            Count = resultObj;
            Message = "Đăng nhập thành công";
        }

        public ApiSuccessResult()
        {
            IsSuccessed = true;
        }
    }
}
