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
        return Ok(await productService.ObtenerProductos());
    }

    [HttpGet("{id_producto}")]
    public async Task<ActionResult<AdapterProduct>> ObtenerProductoPorId(int id_producto)
    {
        var producto = await productService.ObtenerProductoPorId(id_producto);
        return Ok(producto);
    }

    [HttpPut("{id_producto}/descuento")]
    public async Task<IActionResult> AplicarDescuento(int id_producto, [FromBody] int porcentajeDescuento)
    {
        await productService.AplicarDescuentoProducto(id_producto, porcentajeDescuento);
        return Ok(new { mensaje = "Descuento aplicado correctamente" });
    }

    [HttpPost]
    public async Task CrearProducto([FromBody] AdapterProduct producto)
    {
        await productService.CrearProducto(adapterMapper.ToDomainProduct(producto));
    }

    [HttpPut]
    public async Task ActualizarProducto([FromBody] AdapterProduct producto)
    {
        await productService.ActualizarProducto(adapterMapper.ToDomainProduct(producto));
    }

    [HttpDelete("{id_producto}")]
    public async Task EliminarProducto(int id_producto)
    {
        await productService.EliminarProducto(id_producto);
    }
}