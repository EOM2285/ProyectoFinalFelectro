using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PAWS_ProyectoFinal.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        [DisplayName("Categoría")]
		[Required(ErrorMessage = "Debe ingresar una categoria")]
		public string NombreCategoria { get; set; }
        public List<Producto>? Productos { get; set; }

    }
}
