using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Opain.Jarvis.Dominio.Entidades
{
    [Table("RolesUsuarios")]
    public class RolesUsuarios //: IdentityUserRole<string>
    {
        [Key]
        [Column(Order = 0)]
        [Required]
        [ForeignKey("Usuario")]
        public string IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
        [Key]
        [Column(Order = 1)]
        [Required]
        [ForeignKey("Rol")]
        public string IdRol { get; set; }
        public  Rol Rol { get; set; }
    }

}
