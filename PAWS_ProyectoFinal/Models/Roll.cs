namespace PAWS_ProyectoFinal.Models
{
    public class Roll
    {
        public int IdRoll { get; set; }
        public string NombreRoll { get; set;}
        public List<Usuario>? Usuarios { get; set; }
    }
}
