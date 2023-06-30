using Ecommerce.Service.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Presentation.Controllers;

[Route("api/products")]
[ApiController]
[Authorize]
public class ProductController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public ProductController(IServiceManager serviceManager) => _serviceManager = serviceManager;

    [HttpGet(Name = "GetAllProducts")]
    public async Task<IActionResult> GetAllProducts()
    {
        var products = await _serviceManager.ProductService.GetAllAsync();
        return Ok(products);
    }
}
