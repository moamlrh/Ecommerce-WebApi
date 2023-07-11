using System.Security.Claims;

namespace Ecommerce.Presentation.Helpers;

public static class UserHelpers
{
    public static string GetUserId(ClaimsPrincipal User) => User.FindFirst("Id").Value;
}