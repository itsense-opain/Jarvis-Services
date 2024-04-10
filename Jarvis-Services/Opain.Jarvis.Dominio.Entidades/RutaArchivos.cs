using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Opain.Jarvis.Dominio.Entidades
{
    public class RutaArchivos
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(256)]
        public string NombreArchivo { get; set; }
        [Required]
        [ForeignKey("OperacionesVuelo")]
        public int IdOperacionVuelo { get; set; }
        public OperacionesVuelo OperacionesVuelo { get; set; }
        [Required]
        [MaxLength(45)]
        public string TipoArchivo { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }
        [Required]
        public DateTime FechaActualizacion { get; set; }
        [Required]
        [ForeignKey("Usuario")]
        public string IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
    }
}
