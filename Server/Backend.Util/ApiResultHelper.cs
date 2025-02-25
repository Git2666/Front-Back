namespace Backend.Util;

public static class ApiResultHelper
{
    public static ApiResult Success(dynamic data)
    {
        return new ApiResult()
        {
            Code = 200,
            Data = data,
            Message = "SUCCESS",
            TotalCount = 0
        };
    }

    public static ApiResult Error(string message)
    {
        return new ApiResult()
        {
            Code = 500,
            Data = null,
            Message = message,
            TotalCount = 0
        };
    }
}