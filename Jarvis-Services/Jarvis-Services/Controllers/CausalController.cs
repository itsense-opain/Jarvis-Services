using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Opain.Jarvis.Aplicacion.Interfaces;
using Opain.Jarvis.Dominio.Entidades;


namespace Jarvis_Services.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    //ToDo [Authorize]
    public class CausalController : ControllerBase
    {
        private readonly ICausalAplicacion causalAplicacion;
        private readonly ILogger<CausalController> _logger;

        public CausalController(ICausalAplicacion causal, ILogger<CausalController> logger)
        {
            causalAplicacion = causal;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<CausalOtd>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IList<CausalOtd>>> ObtenerTodosAsync()
        {
            try
            {
                var respuesta = await causalAplicacion.ObtenerTodosAsync();
                _logger.LogInformation("Se ejecutó CausalController.ObtenerTodosAsync");
                return Ok(respuesta);

            }
            catch (Exception err)
            {
                _logger.LogError(err, "Error en CausalController.ObtenerTodosAsync");
                return BadRequest();
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<CausalOtd>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IList<CausalOtd>>> ObtenerPorTipoAsync(int tipo)
        {
            try
            {
                var respuestaCausales = await causalAplicacion.ObtenerPorTipoAsync(tipo);
                var respuesta = respuestaCausales.Where(p => p.Estado ==1 ).ToList();

                _logger.LogInformation("Se ejecutó CausalController.ObtenerPorTipoAsync");
                return Ok(respuesta);

            }
            catch (Exception err)
            {
                _logger.LogError(err, "Error en CausalController.ObtenerPorTipoAsync");
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertarAsync([FromBody]CausalOtd causalOtd)
        {
            if (causalOtd == null)
            {
                _logger.LogWarning("Entidad para insertar vacia");
                return BadRequest();
            }

            try
            {
                await causalAplicacion.InsertarAsync(causalOtd).ConfigureAwait(false);
                _logger.LogInformation("Insertó: {@entidad}" + causalOtd);
                return Ok();
            }
            catch (Exception err)
            {
                _logger.LogError(err, "Error insertando: {@entidad} ", causalOtd);
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> ActualizarAsync([FromBody]CausalOtd causalOtd)
        {
            if (causalOtd == null)
            {
                _logger.LogWarning("Entidad para actualizar vacia");
                return BadRequest();
            }

            try
            {
                await causalAplicacion.ActualizarAsync(causalOtd).ConfigureAwait(false);
                _logger.LogInformation("Actualizó: {@entidad}", causalOtd);
                return Ok();
            }
            catch (Exception err)
            {
                _logger.LogError(err, "Error actualizando: {@entidad}", causalOtd);
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
                await causalAplicacion.EliminarAsync(id).ConfigureAwait(false);
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
        [ProducesResponseType(typeof(CausalOtd), StatusCodes.Status200OK)]
        public async Task<ActionResult<CausalOtd>> ObtenerAsync(int id)
        {
            if (id < 1)
            {
                _logger.LogWarning("Identificador para consultar no válido");
                return BadRequest();
            }

            try
            {
                var respuesta = await causalAplicacion.ObtenerAsync(id).ConfigureAwait(false);
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
        [ProducesResponseType(typeof(CausalOtd), StatusCodes.Status200OK)]
        public async Task<ActionResult<CausalOtd>> ObtenerPorCodigoAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                _logger.LogWarning("Identificador para consultar no válido");
                return BadRequest();
            }

            try
            {
                var respuesta = await causalAplicacion.ObtenerPorCodigoAsync(id).ConfigureAwait(false);
                _logger.LogInformation("Consultó: {@entidad}", respuesta);
                return Ok(respuesta);
            }
            catch (Exception err)
            {
                _logger.LogError(err, "Error consultando id: {@id}", id);
                return BadRequest();
            }
        }
    }
}