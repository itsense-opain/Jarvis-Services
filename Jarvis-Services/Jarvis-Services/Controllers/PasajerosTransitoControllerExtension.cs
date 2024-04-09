﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Opain.Jarvis.Aplicacion.Interfaces;
using Opain.Jarvis.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.IO;
using System.IO.Compression;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using System.Globalization;

namespace Jarvis_Services.Controllers
{
    public partial class PasajeroTransitoController : ControllerBase
    {

        /// <summary>
        /// Obtener datos : Permite realizar la extracción de datos de la estructura de Transitos 
        /// enviado varios tipos de filtro personalizados y ejecutados por base de datos.
        /// </summary>
        /// <param name="oFiltro">Objeto de trasnferencia de datos con parametros de busqueda</param>
        /// <returns>Colección de datos</returns>
        [HttpPost]
        [ProducesResponseType(typeof(TransitoRequest), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerDatos(TransitoRequest oFiltro)
        {
            //ToDo IList<PasajeroTransitoOtd> transitos = await this.StoreProcedure.Find(oFiltro);
            //ToDo _logger.LogInformation("Consultó Transitos {@cantidad} registros", transitos.Count);
            return Ok("");
        }
    }
}
