using System.Text.Json;

namespace Ecommerce.Entities.ErrorModels;

public class ErrorDetails
{
    public ErrorDetails(int statusCode = 500, string message = "Error")
    {
        StatusCode = statusCode;
        Message = message;
    }

    public int StatusCode { get; set; }
    public string Message { get; set; }

    public override string ToString() => JsonSerializer.Serialize(this);
}
