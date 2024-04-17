using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Opain.Jarvis.Dominio.Entidades
{
    [Table("OperacionesVuelo")]
    public class OperacionesVuelo
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(15)]
        public string MatriculaVuelo { get; set; }        
        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaVuelo { get; set; }
        [Required]
        [MaxLength(6)]
        public string HoraVuelo { get; set; }
        [Required]
        public int TotalEmbarcados { get; set; }       
        [Required]
        public int PagoCOP { get; set; }
        [Required]
        public int PagoUSD { get; set; }
        [Required]
        [MaxLength(5)]
        public string TipoVuelo { get; set; }
        [Required]
        [MaxLength(15)]
        public string NumeroVuelo { get; set; }
        [Required]
        [ForeignKey("Ciudad1")]
        public string Destino { get; set; }
        public Ciudad Ciudad1 { get; set; }
        [Required]
        [ForeignKey("Aerolinea")]
        public int IdAerolinea { get; set; }
        public Aerolinea Aerolinea { get; set; }
        [Required]
        [ForeignKey("U_Item")]
        public int EstadoProceso { get; set; }
        public U_Item U_Item { get; set; }
        [Required]
        [MaxLength(15)]
        public string NumeroVueloLlegada { get; set; }
        [Required]
        [ForeignKey("Ciudad")]
        public string Origen { get; set; }
        public Ciudad Ciudad { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaLlegada { get; set; }
        [Required]
        [MaxLength(6)]
        public string HoraLlegada { get; set; }
        public int? TotalEmbarcadosAdd { get; set; }
        public int? TotalEmbarcados_LIQ { get; set; }
        public DateTime FechaCreacion { get; set; }
        //public ICollection<Pasajero> Pasajeros { get; set; }
        //public ICollection<PasajeroTransito> PasajerosTransitos { get; set; }
        //public ICollection<NovedadProceso> NovedadesProceso { get; set; }
    }
}
