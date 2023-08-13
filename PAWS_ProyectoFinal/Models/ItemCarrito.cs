namespace PAWS_ProyectoFinal.Models
{
	public class ItemCarrito
	{
		public int ProductoId { get; set; }
		public string NomProducto { get; set; }
		public int Cantidad { get; set; }
		public decimal Precio { get; set; }
		public decimal Total
		{
			get { return Cantidad * Precio; }
		}
		public string Imagen { get; set; }
		public ItemCarrito()
		{

		}
		public ItemCarrito(Producto producto) 
		{
			ProductoId = producto.Id;
			NomProducto = producto.NombreProducto;
			Precio = producto.PrecioProducto;
			Cantidad = 1;
			Imagen = producto.ImagenProducto;
		}
	}
}
