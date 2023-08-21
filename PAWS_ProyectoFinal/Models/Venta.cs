namespace PAWS_ProyectoFinal.Models
{
    public class Venta
    {
        public int Id { get; set; }
        public string TipoPago { get; set; }       
        public int ClienteId { get; set; }
        public string NombreCliente { get; set; }
        public string CorreoCliente { get; set; }
        public decimal MontoPago { get; set; }      
        public DateTime FechaRegistro { get; set; }
        public string StatusPedido { get; set; }
        public List<DetalleVenta>? DetalleVentas { get; set; }
    }
}
