using Adapter;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace MS_Productos.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly ProductService productService;
    private readonly AdapterMapper adapterMapper;

    public ProductController(ProductService productService)
    {
        this.productService = productService;
        adapterMapper = new();
    }

    [HttpGet]
    public async Task<ActionResult<List<AdapterProduct>>> ObtenerProductos()
    {
        return Ok(adapterMapper.ToAdapterProductList(await productService.ObtenerProductos()));
    }

    [HttpGet("{id_producto}")]
    public async Task<ActionResult<AdapterProduct>> ObtenerProductoPorId(int id_producto)
    {
        return Ok(await productService.ObtenerProductoPorId(id_producto));
    }

    [HttpPut("{id_producto}/descuento")]
    public async Task<ActionResult<AdapterProduct>> AplicarDescuento(int id_producto, int porcentaje_descuento)
    {
        await productService.AplicarDescuentoProducto(id_producto, porcentaje_descuento);
        var domainProduct = await productService.ObtenerProductoPorId(id_producto);
        return Ok(adapterMapper.ToAdapterProduct(domainProduct!));
    }

    [HttpPost]
    public async Task<ActionResult<AdapterProduct>> CrearProducto([FromBody] AdapterProduct producto)
    {
        var domainProduct = adapterMapper.ToDomainProduct(producto);
        await productService.CrearProducto(domainProduct);
        return Ok(adapterMapper.ToAdapterProduct(domainProduct)); 
    }

    [HttpPut]
    public async Task<ActionResult<AdapterProduct>> ActualizarProducto([FromBody] AdapterProduct producto)
    {
        var domainProduct = adapterMapper.ToDomainProduct(producto);
        await productService.ActualizarProducto(domainProduct);
        return Ok(adapterMapper.ToAdapterProduct(domainProduct));
    }

    [HttpDelete("{id_producto}")]
    public async Task<IActionResult> EliminarProducto(int id_producto)
    {
        await productService.EliminarProducto(id_producto);
        return NoContent();
    }
}