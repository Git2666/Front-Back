namespace Backend.Util;

public record ApiResult
{
    public int Code { get; set; }
    
    public string Message { get; set; }
    
    public int TotalCount { get; set; }
    
    public dynamic Data { get; set; }
}