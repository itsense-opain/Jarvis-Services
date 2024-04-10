﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Opain.Jarvis.Dominio.Entidades
{
    public class Ticket
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string NumeroTicket { get; set; }
        [Required]
        [ForeignKey("U_Item")]
        public int TipoConsulta { get; set; }
        public U_Item U_Item { get; set; }
        [Required]
        [MaxLength(150)]
        public string Asunto { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaVuelo { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }
        [Required]
        public string Mensaje { get; set; }
        [MaxLength(300)]
        public string Adjunto { get; set; }
        [Required]
        public bool Estado { get; set; }
        [Required]
        [ForeignKey("Aerolinea")]
        public int IdAerolinea { get; set; }
        [Required]
        [ForeignKey("Usuario")]
        public string IdUsuario { get; set; }
        [Required]
        public bool Seguimiento { get; set; }
        public Aerolinea Aerolinea { get; set; }                
        public Usuario Usuario { get; set; }                                     
        public virtual ICollection<RespuestaTicket> RespuestasTickets { get; set; }
    }
}
