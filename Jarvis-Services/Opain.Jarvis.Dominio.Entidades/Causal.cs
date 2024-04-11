﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Opain.Jarvis.Dominio.Entidades
{
    [Table("Causales")]
    public class Causal
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(5)]
        public string Codigo { get; set; }

        [Required]
        [MaxLength(250)]
        public string Descripcion { get; set; }

        [Required]
        [ForeignKey("U_Item")]
        public int Tipo { get; set; }
        public U_Item U_Item { get; set; }

        [Required]
        public bool Estado { get; set; }

        // public ICollection<NovedadProceso> NovedadesProceso { get; set; }
    }
}
