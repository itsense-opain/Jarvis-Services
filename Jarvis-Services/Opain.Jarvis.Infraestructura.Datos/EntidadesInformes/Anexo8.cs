﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opain.Jarvis.Infraestructura.Datos.Entidades
{
    public class Anexo8 : EntidadesInformes.Base
    {
        public string Factura { get; set; }
        public string NombreAerolinea { get; set; }
        public string Matricula { get; set; }
        public string TipodeServicio { get; set; }
        public string FechaServicio { get; set; }
        public string Tarifa { get; set; }
        public string ValorCobroCOP { get; set; }
        
    }
}
