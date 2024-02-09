namespace AuctionRocket.API.Domain.Models;

public class ApiResponse<T>
{
    public ApiResponse(string status, string message, T? data)
    {
        Status = status;
        Message = message;
        Data = data;
    }

    public string Status { get; set; }
    public string Message { get; set; }
    public T? Data { get; set; }
}