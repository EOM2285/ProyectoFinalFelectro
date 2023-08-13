namespace PAWS_ProyectoFinal.Models
{
    public class DetalleVenta
    {
        public int Id { get; set; }           
		public int VentaId { get; set; }
		//
		public int ProductoId { get; set; }
		public string ProductoNombre { get; set; }
        //
		public decimal PrecioVenta { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
        public Venta? Venta { get; set; }
    }
}
