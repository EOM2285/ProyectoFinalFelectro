namespace PAWS_ProyectoFinal.Models
{
    public class Reporte
    {
        public int Id { get; set; }
        public string TipoPago { get; set; }
        public string NumeroDocumento { get; set; }
        public decimal MontoTotal { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string DescripcionProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal Total { get; set; }
    }
}
