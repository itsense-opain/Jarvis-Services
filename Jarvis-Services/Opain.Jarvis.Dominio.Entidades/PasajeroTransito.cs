using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Opain.Jarvis.Dominio.Entidades
{
    [Table("PasajeroTransito")]
    public class PasajeroTransito
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [ForeignKey("OperacionesVuelo")]
        public int IdOperacionVuelo { get; set; }
        public OperacionesVuelo OperacionesVuelo { get; set; }
        [Required]
        [MaxLength(250)]
        public string NombrePasajero { get; set; }
        [Required]
        public int IdVueloLlegada { get; set; }
        [Required]
        public int IdVueloSalida { get; set; }
        [Required]
        [ForeignKey("CategoriaPasajeros")]
        public string Categoria { get; set; }
        public CategoriaPasajeros CategoriaPasajeros { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaLlegada { get; set; }
        [Required]
        [MaxLength(6)]
        public string HoraLlegada { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaSalida { get; set; }
        [Required]
        [MaxLength(6)]
        public string HoraSalida { get; set; }
        public DateTime FechaHoraCargue { get; set; }
        public bool Firmado { get; set; }
        public DateTime FechaHoraFirma { get; set; }
        [Required]
        [MaxLength(15)]
        public string NumeroVueloSalida { get; set; }
        [Required]
        [ForeignKey("Ciudad")]
        public string Destino { get; set; }
        public Ciudad Ciudad { get; set; }
        [Required]
        [ForeignKey("Aerolinea")]
        public int AerolineaSalida { get; set; }
        public Aerolinea Aerolinea { get; set; }
        [Required]
        [MaxLength(15)]
        public string NumeroVueloLlegada { get; set; }
        [Required]
        [ForeignKey("Ciudad1")]
        public string Origen { get; set; }
        public Ciudad Ciudad1 { get; set; }
        [Required]
        [ForeignKey("Aerolinea1")]
        public int AerolineaLlegada { get; set; }
        public Aerolinea Aerolinea1 { get; set; }
        [MaxLength(100)]
        public string Observaciones { get; set; }
        public bool TasaCobrada { get; set; }
        [ForeignKey("RutaArchivos")]
        public int IdCargue { get; set; }
        public RutaArchivos RutaArchivos { get; set; }       
    }
}
