namespace PAWS_ProyectoFinal.Models
{
    public class DetalleVenta
    {
        public int Id { get; set; }
        //public Producto oProducto { get; set; }
        public int Venta_ID { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
        public Venta? Venta { get; set; }
    }
}
