using Ecommerce.Entities;
using Ecommerce.Service.Contracts;
using Ecommerce.Shared;
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

    [HttpGet(Name = "GetAll")]
    public async Task<IActionResult> GetAllProducts()
    {
        var products = await _serviceManager.ProductService.GetAllAsync();
        return Ok(products);
    }

    [HttpGet("{id:guid}", Name = "GetById")]
    public async Task<IActionResult> GetProductById(Guid Id)
    {
        var product = await _serviceManager.ProductService.GetByIdAsync(Id);
        if (product == null)
            throw new ProductNotFoundException(Id);
        return Ok(product);
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddProduct([FromBody] ProductToAddDto product)
    {
        var userId = User.Claims.FirstOrDefault().Value;
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var _product = await _serviceManager.ProductService.AddAsync(product, userId);
        return Ok(_product);
    }
}
