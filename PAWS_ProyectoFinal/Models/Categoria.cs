namespace PAWS_ProyectoFinal.Models
{
    public class Categoria
    {
        public int Id { get; set; }        
        public string NombreCategoria { get; set; }
        public List<Producto>? Productos { get; set; }

    }
}
