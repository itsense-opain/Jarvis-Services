﻿using System.Collections.Generic;
namespace Opain.Jarvis.Dominio.Entidades
{
    public class RespuestaGrilla<T>
    {
        public int CantidadRegistros { get; set; }
        public int CantidadPaginas { get; set; }
        public List<T> Resultado { get; set; }
    }
}
