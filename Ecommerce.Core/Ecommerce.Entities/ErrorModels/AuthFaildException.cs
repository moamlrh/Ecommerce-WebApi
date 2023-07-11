namespace Ecommerce.Entities;

public class AuthFaildException : Exception
{
    public AuthFaildException(string message)
        : base(message) { }
}
