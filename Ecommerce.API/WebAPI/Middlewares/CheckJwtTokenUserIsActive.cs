using Ecommerce.Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Api;

public class CheckJwtTokenUserIsActive
{
    private readonly RequestDelegate next;
    public CheckJwtTokenUserIsActive(RequestDelegate next)
    {
        this.next = next;
    }
    public async Task InvokeAsync(HttpContext context, UserManager<User> userManager)
    {
        var token = context.Request.Headers["Authorization"];
        var userId = context.User.Claims.Where(x => x.Type == "Id").FirstOrDefault()?.Value;
        var user = await userManager.FindByIdAsync(userId);

        if (string.IsNullOrEmpty(token))
            throw new BadHttpRequestException("you're not authenticated");
        await next(context);
    }
}
