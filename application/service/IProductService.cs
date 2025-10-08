using Entities;

namespace Interfaces
{
    public interface IProduct
    {
        Task<List<DomainProduct>> ObtenerProductos();
        Task<DomainProduct?> ObtenerProductoPorId(int id_producto);
        Task<DomainProduct> AplicarDescuentoProducto(int id_producto, int discountPercent);
        Task<DomainProduct> CrearProducto(DomainProduct producto);
        Task<DomainProduct> ActualizarProducto(DomainProduct producto);
        Task EliminarProducto(int id_producto);
    }
}