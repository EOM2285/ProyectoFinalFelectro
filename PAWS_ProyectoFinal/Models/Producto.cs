using System.ComponentModel.DataAnnotations.Schema;

namespace PAWS_ProyectoFinal.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public int CategoriaId { get; set; }
        public string NombreProducto { get; set; }
        public string DescripcionProducto { get; set; }
        public int PrecioProducto { get; set; }        
        public bool EstadoProducto { get; set; }
        
        public string? ImagenProducto { get; set; }
        [NotMapped]
        public IFormFile? File { get; set; }
        public Categoria? Categoria { get;  set; }
    }
}
