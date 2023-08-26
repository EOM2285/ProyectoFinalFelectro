using System.ComponentModel.DataAnnotations;

namespace PAWS_ProyectoFinal.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
		[Required(ErrorMessage = "Debe agregar un nombre")]
		public string Nombre { get; set; }
		[Required(ErrorMessage = "Debe agregar sus apellidos")]
		public string Apellidos { get; set; }
        [Required(ErrorMessage ="Debe agergar un correo")]
        public string Correo { get; set; }
		[Required(ErrorMessage = "Debe agregar una contraseña")]
		public string Contrasena { get; set; }
		[Required(ErrorMessage = " Debe agregar su # de Teléfono")]
		public string Telefono { get; set; }
        public DateTime? UltimaConexion { get; set; }
        public bool EstadoUsuario { get; set; }
        public int RollId { get; set; }
        public Roll? Roll { get; set; }

    }
}
