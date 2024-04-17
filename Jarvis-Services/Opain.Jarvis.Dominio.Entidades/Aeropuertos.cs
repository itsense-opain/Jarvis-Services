using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Opain.Jarvis.Dominio.Entidades
{
    [Table("Aeropuertos")]
    public class Aeropuertos
    {
        [Key]
        [Required]
        [MaxLength(3)]
        public string CodigoIATA { get; set; }
        //public bool CobroCausal64VuelosDom { get; set; }
        [Required]
        [ForeignKey("Ciudad1")]
        public string Ciudad { get; set; }
        public Ciudad Ciudad1 { get; set; } 
        [Required]
        [ForeignKey("Pais1")]
        public string Pais { get; set; }
        public Pais Pais1 { get; set; }
    }
}
