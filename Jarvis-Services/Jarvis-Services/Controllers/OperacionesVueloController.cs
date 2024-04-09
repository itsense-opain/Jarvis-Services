using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Opain.Jarvis.Aplicacion.Interfaces;
using Opain.Jarvis.Dominio.Entidades;

using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;

namespace Jarvis_Services.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OperacionesVueloController : Controller
    {
        private readonly IUsuarioAplicacion usuarios;
        private readonly ILogger<OperacionesVueloController> _logger;
        public IConfiguration Configuration { get; }
        //ToDo private readonly Store.Metodos.OperacionesVuelo StoreProcedure;
        public OperacionesVueloController(IUsuarioAplicacion u, ILogger<OperacionesVueloController> logger
            //ToDo Store.Metodos.OperacionesVuelo store
            )
        {
            usuarios = u;
            _logger = logger;
            //ToDo this.StoreProcedure = store;
        }
        // GET: TraceController
        [HttpPost]
        [ProducesResponseType(typeof(OperacionVueloOTDRequest), StatusCodes.Status200OK)]
        [AllowAnonymous]
        public async Task<ActionResult<IList<OperacionVueloOtd>>> Find(OperacionVueloOTDRequest otd)
        {
            //ToDo IList<OperacionVueloOtd> vuelos = await this.StoreProcedure.Find(otd);
            //ToDo _logger.LogInformation("Consultó {@cantidad} registros", vuelos.Count);
            return Ok("");            
        }
    }
}
