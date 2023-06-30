using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Ecommerce.Presentation;

public class ValidationUserFilter : IActionFilter
{
    public void OnActionExecuted(ActionExecutedContext context) { } // after executing

    public void OnActionExecuting(ActionExecutingContext context) // before executing
    {
        var action = context.RouteData.Values["action"];
        var controller = context.RouteData.Values["controller"];
        var user = context.ActionArguments["user"];
        if (user == null)
        {
            context.Result = new UnprocessableEntityObjectResult(context.ModelState);
            return;
        }
        if (!context.ModelState.IsValid)
        {
            context.Result = new UnprocessableEntityObjectResult(context.ModelState);
        }
    }
}
