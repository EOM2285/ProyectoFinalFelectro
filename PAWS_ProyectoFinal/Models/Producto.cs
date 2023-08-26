using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAWS_ProyectoFinal.Models
{
	public class Producto
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "Debe ingresar almenos una categoria")]
		public int CategoriaId { get; set; }
		[Required(ErrorMessage = "Debe ingresar un nombre")]
		public string NombreProducto { get; set; }
		[Required(ErrorMessage = "Debe ingresar una descripcion")]
		public string DescripcionProducto { get; set; }
		[Required(ErrorMessage = "Debe ingresar un precio")]
		
		public int PrecioProducto { get; set; }		
		public bool EstadoProducto { get; set; }
		
		public string? ImagenProducto { get; set; }
        [NotMapped]
        public IFormFile? File { get; set; }
        public Categoria? Categoria { get;  set; }

	

	}
}
