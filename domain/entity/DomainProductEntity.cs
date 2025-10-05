namespace Entities
{
    public class DomainProduct
    {
        public int id_producto { get; set; }
        public string nombre { get; set; }
        public string categoria { get; set; }
        public float precio { get; set; }
        public int descuento { get; set; }
        public string descripcion { get; set; }
        public bool iva { get; set; }

        public DomainProduct() { }
    }
}
