using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Opain.Jarvis.Aplicacion.Interfaces;
using Opain.Jarvis.Dominio.Entidades;


namespace Jarvis_Services.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //ToDo [Authorize]
    public class TicketController : ControllerBase
    {
        private readonly ITicketAplicacion ticketAplicacion;
        private readonly IRespuestaTicketAplicacion rticketAplicacion;
        private readonly ILogger<TicketController> _logger;
        //ToDo private readonly Store.OperacionesVuelo Store_OperacionesVuelo;
        private readonly IUsuarioAplicacion usuarios;

        public TicketController(ITicketAplicacion ticket, IRespuestaTicketAplicacion rticket, ILogger<TicketController> logger,
            //ToDo Store.OperacionesVuelo store_OperacionesVuelo, 
            IUsuarioAplicacion u)
        {
            ticketAplicacion = ticket;
            rticketAplicacion = rticket;
            _logger = logger;
            usuarios = u;
            //ToDothis.Store_OperacionesVuelo = store_OperacionesVuelo;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<TicketOtd>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IList<TicketOtd>>> ObtenerTodosAsync()
        {
            try
            {
                var respuesta = await ticketAplicacion.ObtenerTodosAsync();
                _logger.LogInformation("Se ejecutó TicketsController.ObtenerTodosAsync");
                return Ok(respuesta);

            }
            catch (Exception err)
            {
                _logger.LogError(err, "Error en TicketsController.ObtenerTodosAsync");
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertarAsync([FromBody]TicketOtd ticketOtd)
        {
            if (ticketOtd == null)
            {
                _logger.LogWarning("Entidad para insertar vacia");
                return BadRequest();
            }

            try
            {
                await ticketAplicacion.InsertarAsync(ticketOtd).ConfigureAwait(false);
                _logger.LogInformation("Insertó: {@entidad}" + ticketOtd);

                insertNofifyAdmin(ticketOtd, "ADMINISTRADOR");                

                return Ok();
            }
            catch (Exception err)
            {
                _logger.LogError(err, "Error insertando: {@entidad} ", ticketOtd);
                return BadRequest();
            }
        }
        [HttpPost]
        [ProducesResponseType(typeof(NotificacionODT), StatusCodes.Status200OK)]
        public async Task<bool> insertNofifyAdmin([FromBody]TicketOtd ticketOtd, string rol) 
        {
            NotificacionODT Notify = new NotificacionODT();
            Notify.titulo = ticketOtd.Asunto;
            Notify.descripcion = ticketOtd.Mensaje;            
            Notify.id_item = ticketOtd.NumeroTicket;
            Notify.id_responsable = ticketOtd.IdUsuario;
            Notify.rol_responsable = rol;
            Notify.id_aerolinea = ticketOtd.IdAerolinea.ToString();

            //ToDo this.Store_OperacionesVuelo.NotificacionesINS(Notify);

            return true;

        }

        [HttpPost]
        [ProducesResponseType(typeof(NotificacionODT), StatusCodes.Status200OK)]
        public async Task<bool> insertNofifyAero([FromBody]RespuestaTicketOtd rticketOtd)
        {
            NotificacionODT Notify = new NotificacionODT();

            var rptaTk = await ticketAplicacion.ObtenerAsync(rticketOtd.IdTicket);
            
            UsuarioOtd u = await usuarios.ObtenerAsync(rticketOtd.IdUsuario).ConfigureAwait(false);

            string rolUsr = u.RolesUsuario[0].Rol.Name;

            if (rolUsr.Equals("ADMINISTRADOR"))
            {
                rolUsr = "AEROLINEA";
            }
            else if (rolUsr.Equals("AEROLINEA")) {
                rolUsr = "ADMINISTRADOR";
            }

            string aerolineaUsr = "0";

            if (rolUsr.Equals("AEROLINEA"))
            {
                aerolineaUsr = rptaTk.IdAerolinea.ToString();
            }

            Notify.titulo = rptaTk.Asunto;
            Notify.descripcion = rticketOtd.Mensaje;
            Notify.id_item = rptaTk.NumeroTicket;
            Notify.id_responsable = rptaTk.IdUsuario;
            Notify.rol_responsable = rolUsr;
            Notify.id_aerolinea = aerolineaUsr;

            //ToDo this.Store_OperacionesVuelo.NotificacionesINS(Notify);

            return true;

        }

        [HttpPost]
        public async Task<IActionResult> ActualizarAsync([FromBody]TicketOtd ticketOtd)
        {
            if (ticketOtd == null)
            {
                _logger.LogWarning("Entidad para actualizar vacia");
                return BadRequest();
            }

            try
            {
                await ticketAplicacion.ActualizarAsync(ticketOtd).ConfigureAwait(false);
                _logger.LogInformation("Actualizó: {@entidad}", ticketOtd);                
                return Ok();
            }
            catch (Exception err)
            {
                _logger.LogError(err, "Error actualizando: {@entidad}", ticketOtd);
                return BadRequest();
            }
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> EliminarAsync(int id)
        {
            if (id < 1)
            {
                _logger.LogWarning("Identificador para eliminar no válido");
                return BadRequest();
            }

            try
            {
                await ticketAplicacion.EliminarAsync(id).ConfigureAwait(false);
                _logger.LogInformation("Eliminó id: {@id}", id);
                return Ok();
            }
            catch (Exception err)
            {
                _logger.LogError(err, "Error eliminando: {@id}", id);
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TicketOtd), StatusCodes.Status200OK)]
        public async Task<ActionResult<TicketOtd>> ObtenerAsync(int id)
        {
            if (id < 1)
            {
                _logger.LogWarning("Identificador para consultar no válido");
                return BadRequest();
            }

            try
            {
                var respuesta = await ticketAplicacion.ObtenerAsync(id).ConfigureAwait(false);
                _logger.LogInformation("Consultó: {@entidad}", respuesta);
                return Ok(respuesta);
            }
            catch (Exception err)
            {
                _logger.LogError(err, "Error consultando id: {@id}", id);
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IList<RespuestaTicketOtd>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IList<RespuestaTicketOtd>>> ObtenerMensajesAsync(int id)
        {
            try
            {
                var respuesta = await rticketAplicacion.ObtenerPorTicketAsync(id);
                _logger.LogInformation("Se ejecutó TicketsController.ObtenerMensajeAsync");
                return Ok(respuesta);

            }
            catch (Exception err)
            {
                _logger.LogError(err, "Error en TicketsController.ObtenerMensajeAsync");
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertarMensajeAsync([FromBody]RespuestaTicketOtd rticketOtd)
        {
            if (rticketOtd == null)
            {
                _logger.LogWarning("Entidad para insertar vacia");
                return BadRequest();
            }

            try
            {
                await rticketAplicacion.InsertarAsync(rticketOtd).ConfigureAwait(false);
                insertNofifyAero(rticketOtd);
                _logger.LogInformation("Insertó: {@entidad}" + rticketOtd);
                return Ok();
            }
            catch (Exception err)
            {
                _logger.LogError(err, "Error insertando: {@entidad} ", rticketOtd);
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(RespuestaTicketOtd), StatusCodes.Status200OK)]
        public async Task<ActionResult<RespuestaTicketOtd>> ObtenerMensajeAsync(int id)
        {
            if (id < 1)
            {
                _logger.LogWarning("Identificador para consultar no válido");
                return BadRequest();
            }

            try
            {
                var respuesta = await rticketAplicacion.ObtenerAsync(id).ConfigureAwait(false);
                _logger.LogInformation("Consultó: {@entidad}", respuesta);
                return Ok(respuesta);
            }
            catch (Exception err)
            {
                _logger.LogError(err, "Error consultando id: {@id}", id);
                return BadRequest();
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        public async Task<ActionResult<int>> ObtenerUltimoIdAsync()
        {
            try
            {
                int id = 0;
                var respuesta = await ticketAplicacion.ObtenerTodosAsync();
                if(respuesta.Count() > 0)
                {
                    id = respuesta.OrderByDescending(x => x.Id).FirstOrDefault().Id;                  
                }

                _logger.LogInformation("Se ejecutó TicketsController.ObtenerUltimoIdAsync");
                return Ok(id);


            }
            catch (Exception err)
            {
                _logger.LogError(err, "Error en TicketsController.ObtenerUltimoIdAsync");
                return BadRequest();
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(DataTable), StatusCodes.Status200OK)]
        public async Task<ActionResult<DataTable>> TraerInformeTicket(int idAerolinea, string fechaIni, string fechaFin, int tipoticket)
        {
            //ToDo
            //var resultado = this.Store_OperacionesVuelo.TraerInformeTickets(idAerolinea, 
            //    DateTime.ParseExact(fechaIni, "dd/MM/yyyy", CultureInfo.InvariantCulture), 
            //    DateTime.ParseExact(fechaFin, "dd/MM/yyyy", CultureInfo.InvariantCulture).AddDays(1).AddTicks(-1), 0);

            return Ok("");
        }


    }
}