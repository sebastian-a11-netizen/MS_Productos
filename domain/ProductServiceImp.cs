using db;
using Interfaces;
using Entities;

namespace Domain.Services
{
    public class ProductService : IProduct
    {
        private readonly Repository repository;

        public ProductService(Repository repository)
        {
            this.repository = repository;
        }

        // Obtener todos los productos
        public async Task<List<DomainProduct>> ObtenerProductos()
        {
            return await repository.ObtenerProductos();
        }

        // Obtener un producto por ID
        public async Task<DomainProduct?> ObtenerProductoPorId(int id_producto)
        {
            var producto = await repository.ObtenerProductoPorId(id_producto);
            if (producto == null) throw new Exception("Producto no encontrado");
            return producto;
        }

        // Crear un producto
        public async Task<DomainProduct> CrearProducto(DomainProduct producto)
        {
            await repository.CrearProducto(producto);
            return producto;
        }

        // Actualizar un producto
        public async Task<DomainProduct> ActualizarProducto(DomainProduct producto)
        {
            var existing = await repository.ObtenerProductoPorId(producto.id_producto);
            if (existing == null) throw new Exception("Producto no encontrado");

            await repository.ActualizarProducto(producto);
            return producto;
        }

        // Eliminar un producto
        public async Task EliminarProducto(int id_producto)
        {
            var existing = await repository.ObtenerProductoPorId(id_producto);
            if (existing == null) throw new Exception("Producto no encontrado");

            await repository.EliminarProducto(id_producto);
        }

        // Aplicar descuento a un producto
        public async Task<DomainProduct> AplicarDescuentoProducto(int id_producto, int discountPercent)
        {
            var producto = await repository.ObtenerProductoPorId(id_producto);
            if (producto == null) throw new Exception("Producto no encontrado");

            producto.descuento = discountPercent;
            producto.precio = producto.precio * (1 - discountPercent / 100f);

            await repository.ActualizarProducto(producto);
            return producto;
        }
    }
}
