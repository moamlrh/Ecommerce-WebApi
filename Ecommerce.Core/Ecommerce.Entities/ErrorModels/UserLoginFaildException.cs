namespace Ecommerce.Entities;

public class UserLoginFaildException : AuthFaildException
{
    public UserLoginFaildException()
        : base($"Username/Password was incorrect.") { }
}
