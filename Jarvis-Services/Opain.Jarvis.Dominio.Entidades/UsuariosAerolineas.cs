using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Opain.Jarvis.Dominio.Entidades
{
    [Table("UsuariosAerolineas")]
    public class UsuariosAerolineas
    {
        [Key]
        [Column(Order = 0)]
        [Required]
        [ForeignKey("Aerolinea")]
        public int IdAerolinea { get; set; }
        public Aerolinea Aerolinea { get; set; }
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Usuario")]
        public string IdUsuario { get; set; }
        public Usuario Usuario { get; set; }

    }
}
