using System.ComponentModel.DataAnnotations;

namespace Registro.Models
{
    public class Persona
    {
        public int IdPersona{ get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
       
        [Required]
        [Range(0, 130)]
        public int Edad { get; set; }

        [Required]
        [EmailAddress(ErrorMessage ="El formato del correo no es valido.")]
        public string Correo { get; set; }
    }
}
