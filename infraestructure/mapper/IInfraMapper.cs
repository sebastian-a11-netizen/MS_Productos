using Entities;

namespace Interfaces
{
    public interface IInfraestructureMapper
{
    // Convierte una entidad de Dominio a Infraestructura
    InfrProduct ToInfraestructureProduct(DomainProduct domainProduct);
    List<InfrProduct> ToInfraestructureProductList(List<DomainProduct> domainProducts);

    // Convierte una entidad de Infraestructura a Dominio
    DomainProduct ToDomainProduct(InfrProduct infraProduct);
    List<DomainProduct> ToDomainProductList(List<InfrProduct> infraProducts);
}
}