using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Opain.Jarvis.Dominio.Entidades
{
    [Table("RespuestaTicket")]
    public class RespuestaTicket
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Ticket")]
        public int IdTicket { get; set; }
        public Ticket Ticket { get; set; }
        [Required]
        public string Mensaje { get; set; }
        [MaxLength(300)]
        public string Adjunto { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }
        [Required]
        [ForeignKey("Usuario")]
        public string IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
    }
}
