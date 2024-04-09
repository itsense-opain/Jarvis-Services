﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opain.Jarvis.Infraestructura.Datos.Entidades
{
    public class Anexo3 : EntidadesInformes.Base
    {
        public string Factura { get; set; }
        public string Aerolinea { get; set; }
        public string FechaVuelo { get; set; }
        public string Matricula { get; set; }
        public string Sigla { get; set; }
        public string NumeroVuelo { get; set; }
        public string TarifaCOP { get; set; }
        public string TarifaUSD { get; set; }
        public string PaganCOP { get; set; }
        public string PaganUSD { get; set; }
        public string CobroCOP { get; set; }
        public string CobroUSD { get; set; }
        public string VrComisionCOP { get; set; }
        public string VrComisionUSD { get; set; }
        public string Cantidad { get; set; }
        public string VueloSalida { get; set; }
    }
}
