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
    public class HorarioOperacionController : ControllerBase
    {
        private readonly IHorarioOperacionAplicacion horarioAplicacion;
        private readonly ILogger<HorarioOperacionController> _logger;

        public HorarioOperacionController(IHorarioOperacionAplicacion horario, ILogger<HorarioOperacionController> logger)
        {
            horarioAplicacion = horario;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<HorarioOperacionOtd>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IList<HorarioOperacionOtd>>> ObtenerTodosAsync()
        {
            try
            {
                var respuesta = await horarioAplicacion.ObtenerTodosAsync();
                _logger.LogInformation("Se ejecutó HorarioOperacionController.ObtenerTodosAsync");
                return Ok(respuesta);

            }
            catch (Exception err)
            {
                _logger.LogError(err, "Error en HorarioOperacionController.ObtenerTodosAsync");
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertarAsync([FromBody]HorarioOperacionOtd horarioOperacionOtd)
        {
            if (horarioOperacionOtd == null)
            {
                _logger.LogWarning("Entidad para insertar vacia");
                return BadRequest();
            }

            try
            {
                await horarioAplicacion.InsertarAsync(horarioOperacionOtd).ConfigureAwait(false);
                _logger.LogInformation("Insertó: {@entidad}" + horarioOperacionOtd);
                return Ok();
            }
            catch (Exception err)
            {
                _logger.LogError(err, "Error insertando: {@entidad} ", horarioOperacionOtd);
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> ActualizarAsync([FromBody]HorarioOperacionOtd horarioOperacionOtd)
        {
            if (horarioOperacionOtd == null)
            {
                _logger.LogWarning("Entidad para actualizar vacia");
                return BadRequest();
            }

            try
            {
                await horarioAplicacion.ActualizarAsync(horarioOperacionOtd).ConfigureAwait(false);
                _logger.LogInformation("Actualizó: {@entidad}", horarioOperacionOtd);
                return Ok();
            }
            catch (Exception err)
            {
                _logger.LogError(err, "Error actualizando: {@entidad}", horarioOperacionOtd);
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
                await horarioAplicacion.EliminarAsync(id).ConfigureAwait(false);
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
        [ProducesResponseType(typeof(HorarioOperacionOtd), StatusCodes.Status200OK)]
        public async Task<ActionResult<HorarioOperacionOtd>> ObtenerAsync(int id)
        {
            if (id < 1)
            {
                _logger.LogWarning("Identificador para consultar no válido");
                return BadRequest();
            }

            try
            {
                var respuesta = await horarioAplicacion.ObtenerAsync(id).ConfigureAwait(false);
                _logger.LogInformation("Consultó: {@entidad}", respuesta);
                return Ok(respuesta);
            }
            catch (Exception err)
            {
                _logger.LogError(err, "Error consultando id: {@id}", id);
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> ActualizarTodosAsync([FromBody]List<HorarioOperacionOtd> horarioOperacionOtd)
        {
            if (horarioOperacionOtd == null)
            {
                _logger.LogWarning("Entidades para actualizar vacia");
                return BadRequest();
            }

            try
            {
                await horarioAplicacion.ActualizarTodosAsync(horarioOperacionOtd).ConfigureAwait(false);
                _logger.LogInformation("Actualizó: {@entidad}", horarioOperacionOtd);
                return Ok();
            }
            catch (Exception err)
            {
                _logger.LogError(err, "Error actualizando: {@entidad}", horarioOperacionOtd);
                return BadRequest();
            }
        }
    }
}