using System.ComponentModel.DataAnnotations;

namespace P_CRUDNetCore.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Por favor ingresar el Nombre Completo")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Por favor ingresar el Correo Electronico")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Por favor ingresar el numero de Telefono")]
        public string Telefono { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}
