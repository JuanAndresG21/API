using System.ComponentModel.DataAnnotations;

namespace API_APP.DAL.Entities
{
    public class AuditBase
    {
        [Key] //DataAnnotation sirve para definir que ID es un PK
        [Required] //No permite nulos
        public virtual Guid Id { get; set; } //sera la pk de todas las tablas de la BD   Los virtual es porque van a ser heredables
        public virtual DateTime? CreatedDate { get; set; }  //? para campos nulleables
        public virtual DateTime? ModifiedDate { get; set; }
    }
}
