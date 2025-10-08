using Adapter;
using Entities;

namespace Interfaces
{
    public interface IAdapterMapper
    {
        AdapterProduct ToAdapterProduct(DomainProduct domainProduct);
        DomainProduct ToDomainProduct(AdapterProduct adapterProduct);
        List<AdapterProduct> ToAdapterProductList(List<DomainProduct> domainProducts);
        List<DomainProduct> ToDomainProductList(List<AdapterProduct> adapterProducts);
    }
}