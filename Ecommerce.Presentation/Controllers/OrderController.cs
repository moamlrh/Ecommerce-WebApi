using Microsoft.AspNetCore.Authorization;
using Ecommerce.Service.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Presentation.Controllers;

[Route("api/orders")]
[ApiController]
[Authorize]
public class OrderController : ControllerBase
{
    private readonly IServiceManager _serviceManager;
    public OrderController(IServiceManager serviceManager) => _serviceManager = serviceManager;
}