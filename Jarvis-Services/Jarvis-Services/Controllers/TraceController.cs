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
    public class TraceController : Controller
    {
        private readonly IUsuarioAplicacion usuarios;
        private readonly ILogger<TraceController> _logger;
        public IConfiguration Configuration { get; }
        //ToDo private readonly Store.Trace StoreProcedure;
        public TraceController(IUsuarioAplicacion u, ILogger<TraceController> logger
            //ToDo Store.Trace store
            )
        {
            usuarios = u;
            _logger = logger;
            //ToDo this.StoreProcedure = store;
        }
        // GET: TraceController
        [HttpPost]
        [ProducesResponseType(typeof(TraceOtd), StatusCodes.Status200OK)]
        [AllowAnonymous]
        public async Task<ActionResult> SaveAsync(TraceOtd OTDTrace)
        {
            //ToDo this.StoreProcedure.Save(OTDTrace);
            return Ok();
        }

       
    }
}
