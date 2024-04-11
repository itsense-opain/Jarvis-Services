using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Opain.Jarvis.Dominio.Entidades
{
    [Table("UsuariosAerolineas")]
    public class UsuariosAerolineas
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Aerolinea")]
        public int IdAerolinea { get; set; }
        public Aerolinea Aerolinea { get; set; }
        [ForeignKey("Usuario")]
        public string IdUsuario { get; set; }
        public Usuario Usuario { get; set; }

    }
}
