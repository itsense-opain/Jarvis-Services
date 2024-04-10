﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Opain.Jarvis.Dominio.Entidades
{
    public class OperacionVueloOtd
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name ="Fecha de vuelo")]
        public DateTime Fecha { get; set; }
        [Required]
        [Display(Name = "Número de Matrícula")]
        public string Matricula { get; set; }
        [Required(ErrorMessage ="El campo {0} es obligatorio.")]
        [Display(Name = "Número de Vuelo")]
        public string Vuelo { get; set; }
        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Hora de Vuelo")]
        public string Hora { get; set; }
        [Required]
        [Display(Name = "Total Embarcados")]
        public int TotalEmbarcados { get; set; }
        [Required]
        [Display(Name = "Infantes")]
        public int INF { get; set; }
        [Required]
        [Display(Name = "Transitos en línea")]
        public int TTL { get; set; }
        [Required]
        [Display(Name = "Tránsito en Conexión")]
        public int TTC { get; set; }
        [Required]
        [Display(Name = "Exentos")]
        public int EX { get; set; }
        [Required]
        [Display(Name = "Tripulantes")]
        public int TRIP { get; set; }
        [Display(Name = "Pasajeros")]
        public int PAX { get; set; }
        [Required]
        [Display(Name = "Pagos en COP")]
        public int PagoCOP { get; set; }
        [Required]
        [Display(Name = "Pagos en USD")]
        public int PagoUSD { get; set; }
        [Display(Name = "Pasajeros")]
        public int ConfirmacionPasajeros { get; set; }
        [Display(Name = "Tránsito")]
        public int ConfirmacionTransitos { get; set; }
        [Display(Name = "Gen Dec")]
        public int ConfirmacionGenDec { get; set; }
        [Display(Name = "Manifiesto")]
        public int ConfirmacionManifiesto { get; set; }
        [Display(Name = "Operación")]
        public int ConfirmacionOperacion { get; set; }
        [Display(Name = "Aerolínea")]
        public string NombreAerolinea { get; set; }
        [Required]
        [Display(Name = "Destino")]
        public string Destino { get; set; }
        [Required]
        [Display(Name = "Tipo")]
        public string Tipo { get; set; }
        public int IdAerolinea { get; set; }
        public string ArchivoGendec { get; set; }
        public string ArchivoManifiesto { get; set; }
        public string ArchivoPasajeros { get; set; }

        public string ArchivoTransito { get; set; }
        public int PDFPasajeros { get; set; }
        public string EstadoProceso { get; set; }
        [Display(Name = "Indentificador de Cargue")]
        public string ConsecutivoCargue { get; set; }
        public int IdCargue { get; set; }
        public int IdConsecutivoCargue { get; set; }
        public int NovedadCargue { get; set; }
        public int NovedadProceso { get; set; }
        public int IdVuelo { get; set; }
        public int? TotalEmbarcados_LIQ { get; set; }
        public int? TotalEmbarcadosAdd { get; set; }
        public string EnvioNotificacion { get; set; }
        public string SiglaAerolinea { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string FechaDesde { get; set; }
        public string FechaHasta { get; set; }
    }
}
