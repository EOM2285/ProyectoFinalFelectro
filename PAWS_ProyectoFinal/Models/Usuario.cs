using System.ComponentModel.DataAnnotations;

namespace PAWS_ProyectoFinal.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }        
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        [Required]
        public string Correo { get; set; }
        [Required]
        public string Contrasena { get; set; }
        public string Telefono { get; set; }
        public DateTime? UltimaConexion { get; set; }
        public bool EstadoUsuario { get; set; }
        public int RollId { get; set; }
        public Roll? Roll { get; set; }

    }
}
