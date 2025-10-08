using Entities;
using Interfaces;

namespace Adapter
{
    public class AdapterMapper : IAdapterMapper
    {
        public AdapterProduct ToAdapterProduct(DomainProduct domainProduct)
        {
            return new AdapterProduct
            {
                id_producto = domainProduct.id_producto,
                nombre = domainProduct.nombre,
                categoria = domainProduct.categoria,
                precio = domainProduct.precio,
                descuento = domainProduct.descuento,
                descripcion = domainProduct.descripcion,
                iva = domainProduct.iva
            };
        }

        public List<AdapterProduct> ToAdapterProductList(List<DomainProduct> domainProducts)
        {
            return domainProducts.Count == 0 ? new List<AdapterProduct>() : domainProducts.Select(ToAdapterProduct).ToList();
        }

        public DomainProduct ToDomainProduct(AdapterProduct adapterProduct)
        {
            return new DomainProduct
            {
                id_producto = adapterProduct.id_producto,
                nombre = adapterProduct.nombre,
                categoria = adapterProduct.categoria,
                precio = adapterProduct.precio,
                descuento = adapterProduct.descuento,
                descripcion = adapterProduct.descripcion,
                iva = adapterProduct.iva
            };
        }
        
        public List<DomainProduct> ToDomainProductList(List<AdapterProduct> adapterProducts)
        {
            return adapterProducts.Count == 0 ? new List<DomainProduct>() : adapterProducts.Select(ToDomainProduct).ToList();
        }
    }
}