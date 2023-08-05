namespace PAWS_ProyectoFinal.Models
{
    public class Venta
    {
        public int Id { get; set; }
        public string TipoPago { get; set; }
        public string NumeroDocumento { get; set; }
        public string DocumentoCliente { get; set; }
        public string NombreCliente { get; set; }
        public decimal MontoPago { get; set; }
        public decimal MontoTotal { get; set; }
        public DateTime FechaRegistro { get; set; }

        public List<DetalleVenta>? DetalleVentas { get; set; }
    }
}
