using Ecommerce.Presentation.Actions;
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
    [ServiceFilter(typeof(ValidationProductAttribute))]
    public async Task<IActionResult> GetAllProducts([FromQuery] ProductParameters parameters)
    {
        var products = await _serviceManager.ProductService.GetAllAsync(parameters);
        return Ok(products);
    }

    [HttpGet("{id:guid}", Name = "GetById")]
    public async Task<IActionResult> GetProductById(Guid Id)
    {
        var product = await _serviceManager.ProductService.GetByIdAsync(Id);
        return Ok(product);
    }

    [HttpPost("add")]
    [ServiceFilter(typeof(ValidationActionAttribute))]
    public async Task<IActionResult> AddProduct([FromBody] ProductToAddDto product)
    {
        var userId = User.Claims.FirstOrDefault()?.Value;
        var _product = await _serviceManager.ProductService.AddAsync(product, userId);
        return Ok(_product);
    }

    [HttpDelete("{id:guid}", Name = "DeleteProduct")]
    public async Task<IActionResult> DeleteProduct(Guid Id)
    {
        await _serviceManager.ProductService.DeleteByIdAsync(Id);
        return Ok();
    }

}