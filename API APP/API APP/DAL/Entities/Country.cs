using System.ComponentModel.DataAnnotations;

namespace API_APP.DAL.Entities
{
    public class Country : AuditBase
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres")]
        [Display(Name = "Pais")] //Forma de mostrar el campo en el front end
        public string Name { get; set; }
    }
}
