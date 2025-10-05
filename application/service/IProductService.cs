using Adapter;
using Entities;

namespace Interfaces
{
    public interface IProduct
    {
        Task<List<DomainProduct>> ObtenerProductos();
        Task<DomainProduct?> ObtenerProductoPorId(int id_producto);
        Task AplicarDescuentoProducto(int id_producto, int discountPercent);
        Task CrearProducto(DomainProduct producto);
        Task ActualizarProducto(DomainProduct producto);
        Task EliminarProducto(int id_producto);
    }
}