﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opain.Jarvis.Infraestructura.Datos.Entidades
{
    public class Anexo15 : EntidadesInformes.Base
    {
        public string Factura { get; set; }
        public string SiglaAerolinea { get; set; }
        public string Matricula { get; set; }
        public string NombreAerolinea { get; set; }
        public string VueloIngreso { get; set; }
        public string VueloSalida { get; set; }
        public string FechaIngreso { get; set; }
        public string FechaSalida { get; set; }
        public string HoraIngreso { get; set; }
        public string HoraSalida { get; set; }
        public string Cantidad { get; set; }
        public string POS { get; set; }
        public string CobroCOP { get; set; }
        public string CobroUSD { get; set; }
        public string TotalCOP { get; set; }
        public string TotalUSD { get; set; }
    }
}
