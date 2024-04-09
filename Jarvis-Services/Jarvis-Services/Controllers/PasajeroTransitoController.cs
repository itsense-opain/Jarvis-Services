using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Opain.Jarvis.Aplicacion.Interfaces;
using Opain.Jarvis.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;


namespace Jarvis_Services.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //ToDo [Authorize]
    public partial class PasajeroTransitoController : ControllerBase
    {
        private readonly IPasajeroTransitoAplicacion pasajeroTransito;
        private readonly ILogger<PasajeroTransitoController> _logger;
        private readonly IConfiguration _config;

        //ToDo
        //private readonly Store.OperacionesVuelo Store_OperacionesVuelo;
        //private readonly Store.Metodos.Pasajeros StoreProcedure;       

        public PasajeroTransitoController(IPasajeroTransitoAplicacion pas,           
            ILogger<PasajeroTransitoController> logger,
            // ToDo
            //Store.OperacionesVuelo store_OperacionesVuelo,
            // Store.Metodos.Pasajeros store,
             Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            pasajeroTransito = pas;
            // ToDothis.Store_OperacionesVuelo = store_OperacionesVuelo;           
            _logger = logger;
            // this.StoreProcedure = store;
            _config = configuration;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IList<PasajeroTransitoOtd>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IList<PasajeroTransitoOtd>>> ObtenerTodosAsync(int id)
        {
            try
            {
                var respuesta = await pasajeroTransito.ObtenerTodosAsync(id);
                _logger.LogInformation("Se ejecutó PasajerosTransitoController.ObtenerTodosAsync");
                return Ok(respuesta);

            }
            catch (Exception err)
            {
                _logger.LogError(err, "Error en PasajerosTransitoController.ObtenerTodosAsync");
                return BadRequest();
            }
        }


        [HttpGet("{Aerolinea}")]
        [ProducesResponseType(typeof(IList<PasajeroTransitoOtd>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IList<PasajeroTransitoOtd>>> ObtenerAerolineaAsync(string Aerolinea)
        {
            try
            {
                var respuesta = await pasajeroTransito.ObtenerAerolineaAsync(Aerolinea);
                _logger.LogInformation("Se ejecutó PasajerosTransitoController.ObtenerAerolineaAsync");
                return Ok(respuesta);

            }
            catch (Exception err)
            {
                _logger.LogError(err, "Error en PasajerosTransitoController.ObtenerAerolineaAsync");
                return BadRequest();
            }
        }


        [HttpPost]
        public async Task<IActionResult> InsertarAsync([FromBody]PasajeroTransitoOtd pasajeroOtd)
        {
            if (pasajeroOtd == null)
            {
                _logger.LogWarning("Entidad para insertar vacia");
                return BadRequest();
            }

            try
            {
                await pasajeroTransito.InsertarAsync(pasajeroOtd).ConfigureAwait(false);
                _logger.LogInformation("Insertó: {@entidad}" + pasajeroOtd);

                return Ok();
            }
            catch (Exception err)
            {
                _logger.LogError(err, "Error insertando: {@entidad} ", pasajeroOtd);
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertarMasivoAsync([FromBody]IList<PasajeroTransitoOtd> pasajerosOtd)
        {
            if (pasajerosOtd == null)
            {
                _logger.LogWarning("Entidad para insertar vacia");
                return BadRequest();
            }

            try
            {
                await pasajeroTransito.InsertarMasivoAsync(pasajerosOtd).ConfigureAwait(false);
                _logger.LogInformation("Insertó {@cantidad} registros", pasajerosOtd.Count);
                return Ok();
            }
            catch (Exception err)
            {
                _logger.LogError(err, "Error insertando {@cantidad} registros", pasajerosOtd.Count);
                return BadRequest();
            }

        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PasajeroTransitoOtd), StatusCodes.Status200OK)]
        public async Task<ActionResult<PasajeroTransitoOtd>> ObtenerAsync(int id)
        {
            try
            {
                var respuesta = await pasajeroTransito.ObtenerAsync(id);
                _logger.LogInformation("Se ejecutó PasajeroTransitoController.ObtenerAsync");
                return Ok(respuesta);

            }
            catch (Exception err)
            {
                _logger.LogError(err, "Error en PasajeroTransitoController.ObtenerAsync");
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> ActualizarAsync([FromBody]PasajeroTransitoOtd pasajeroOtd)
        {
            if (pasajeroOtd == null)
            {
                _logger.LogWarning("Entidad para actualizar vacia");
                return BadRequest();
            }

            try
            {
                await pasajeroTransito.ActualizarAsync(pasajeroOtd).ConfigureAwait(false);

                _logger.LogInformation("Actualizó: {@entidad}", pasajeroOtd);
                return Ok();
            }
            catch (Exception err)
            {
                _logger.LogError(err, "Error actualizando: {@entidad}", pasajeroOtd);
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> ActualizarEstadoVuelosFirma(int id)
        {
            //ToDo this.Store_OperacionesVuelo.ActualizaEstadoVueloFirmado(id);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> ActualizaRechazoVuelos(int id, string observacion)
        {
            //ToDo this.Store_OperacionesVuelo.ActualizarechazoVuelo(id, observacion);
            return Ok();
        }


        [HttpPost]
        public async Task<IActionResult> EnviarValidacionesAutomaticas(int id, int contador, int CantidadTTC, int CantidadTTL)
        {
            //ToDo this.Store_OperacionesVuelo.AtualizarCausalesTransito(id, contador, CantidadTTC, CantidadTTL);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerHallazgosVuelos(int id)
        {
            //ToDo int retorno= this.Store_OperacionesVuelo.ObtenerHallazgosVuelos(id);
            return Ok("");
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerRechazoVuelos(int id)
        {
            //ToDo string retorno = this.Store_OperacionesVuelo.ObtenerObservacionRechazoTrans(id);
            return Ok("");
        }
               
    }
}