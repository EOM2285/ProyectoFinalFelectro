using System.ComponentModel;

namespace PAWS_ProyectoFinal.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        [DisplayName("Categoría")]
        public string NombreCategoria { get; set; }
        public List<Producto>? Productos { get; set; }

    }
}
