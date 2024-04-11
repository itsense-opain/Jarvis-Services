using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Opain.Jarvis.Dominio.Entidades
{
    [Table("CategoriaPasajeros")]
    public class CategoriaPasajeros
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(5)]
        public string CodPasajero { get; set; }
        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }// Preguntar
        [Required]
        [MaxLength(250)]
        public string Descripcion { get; set; }
        [Required]
        public int Posicion { get; set; }
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
