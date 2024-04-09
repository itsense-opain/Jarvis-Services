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
    [Route("api/[controller]/[action]")]
    [ApiController]
    //ToDo [Authorize]
    public class TasaAeroportuariaController : ControllerBase
    {
        private readonly ITasaAeroportuariaAplicacion tasaAplicacion;
        private readonly ILogger<TasaAeroportuariaController> _logger;

        public TasaAeroportuariaController(ITasaAeroportuariaAplicacion tasa, ILogger<TasaAeroportuariaController> logger)
        {
            tasaAplicacion = tasa;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<TasaAeroportuariaOtd>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IList<TasaAeroportuariaOtd>>> ObtenerTodosAsync()
        {
            try
            {
                var respuesta = await tasaAplicacion.ObtenerTodosAsync();
                _logger.LogInformation("Se ejecutó TasaAeroportuariaController.ObtenerTodosAsync");
                return Ok(respuesta);

            }
            catch (Exception err)
            {
                _logger.LogError(err, "Error en TasaAeroportuariaController.ObtenerTodosAsync");
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertarAsync([FromBody]TasaAeroportuariaOtd tasaAeroportuariaOtd)
        {
            if (tasaAeroportuariaOtd == null)
            {
                _logger.LogWarning("Entidad para insertar vacia");
                return BadRequest();
            }

            try
            {
                await tasaAplicacion.InsertarAsync(tasaAeroportuariaOtd).ConfigureAwait(false);
                _logger.LogInformation("Insertó: {@entidad}" + tasaAeroportuariaOtd);
                return Ok();
            }
            catch (Exception err)
            {
                _logger.LogError(err, "Error insertando: {@entidad} ", tasaAeroportuariaOtd);
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> ActualizarAsync([FromBody]TasaAeroportuariaOtd tasaAeroportuariaOtd)
        {
            if (tasaAeroportuariaOtd == null)
            {
                _logger.LogWarning("Entidad para actualizar vacia");
                return BadRequest();
            }

            try
            {
                await tasaAplicacion.ActualizarAsync(tasaAeroportuariaOtd).ConfigureAwait(false);
                _logger.LogInformation("Actualizó: {@entidad}", tasaAeroportuariaOtd);
                return Ok();
            }
            catch (Exception err)
            {
                _logger.LogError(err, "Error actualizando: {@entidad}", tasaAeroportuariaOtd);
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
                await tasaAplicacion.EliminarAsync(id).ConfigureAwait(false);
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
        [ProducesResponseType(typeof(TasaAeroportuariaOtd), StatusCodes.Status200OK)]
        public async Task<ActionResult<TasaAeroportuariaOtd>> ObtenerAsync(int id)
        {
            if (id < 1)
            {
                _logger.LogWarning("Identificador para consultar no válido");
                return BadRequest();
            }

            try
            {
                var respuesta = await tasaAplicacion.ObtenerAsync(id).ConfigureAwait(false);
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
        [ProducesResponseType(typeof(TasaAeroportuariaOtd), StatusCodes.Status200OK)]
        public async Task<ActionResult<TasaAeroportuariaOtd>> ObtenerUltimaAsync()
        {
            try
            {
                var respuesta = await tasaAplicacion.ObtenerUltimaAsync();
                _logger.LogInformation("Se ejecutó TasaAeroportuariaController.ObtenerUltimaAsync");
                return Ok(respuesta);

            }
            catch (Exception err)
            {
                _logger.LogError(err, "Error en TasaAeroportuariaController.ObtenerUltimaAsync");
                return BadRequest();
            }
        }
    }
}