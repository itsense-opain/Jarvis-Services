using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Opain.Jarvis.Aplicacion.Interfaces;
using Opain.Jarvis.Dominio.Entidades;

namespace Jarvis_Services.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //ToDo //ToDo [Authorize]
    public class AerolineaController : ControllerBase
    {
        private readonly IAerolineaAplicacion aerolineaAplicacion;
        private readonly ILogger<AerolineaController> _logger;

        public AerolineaController(IAerolineaAplicacion aerolinea, ILogger<AerolineaController> logger)
        {
            aerolineaAplicacion = aerolinea;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<AerolineaOtd>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IList<AerolineaOtd>>> ObtenerTodosAsync()
        {
            try
            {
                var respuesta = await aerolineaAplicacion.ObtenerTodosAsync();
                _logger.LogInformation("Se ejecutó AerolineaController.ObtenerTodosAsync");
                return Ok(respuesta);

            }
            catch (Exception err)
            {
                _logger.LogError(err, "Error en AerolineaController.ObtenerTodosAsync");
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertarAsync([FromBody] AerolineaOtd aerolineaOtd)
        {
            if (aerolineaOtd == null)
            {
                _logger.LogWarning("Entidad para insertar vacia");
                return BadRequest();
            }

            try
            {
                await aerolineaAplicacion.InsertarAsync(aerolineaOtd).ConfigureAwait(false);
                _logger.LogInformation("Insertó: {@entidad}" + aerolineaOtd);
                return Ok();
            }
            catch (Exception err)
            {
                _logger.LogError(err, "Error insertando: {@entidad} ", aerolineaOtd);
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> ActualizarAsync([FromBody] AerolineaOtd aerolineaOtd)
        {
            if (aerolineaOtd == null)
            {
                _logger.LogWarning("Entidad para actualizar vacia");
                return BadRequest();
            }

            try
            {
                await aerolineaAplicacion.ActualizarAsync(aerolineaOtd).ConfigureAwait(false);
                _logger.LogInformation("Actualizó: {@entidad}", aerolineaOtd);
                return Ok();
            }
            catch (Exception err)
            {
                _logger.LogError(err, "Error actualizando: {@entidad}", aerolineaOtd);
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
                await aerolineaAplicacion.EliminarAsync(id).ConfigureAwait(false);
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
        [ProducesResponseType(typeof(AerolineaOtd), StatusCodes.Status200OK)]
        public async Task<ActionResult<AerolineaOtd>> ObtenerAsync(int id)
        {
            if (id < 1)
            {
                _logger.LogWarning("Identificador para consultar no válido");
                return BadRequest();
            }

            try
            {
                var respuesta = await aerolineaAplicacion.ObtenerAsync(id).ConfigureAwait(false);
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
        public async Task<IActionResult> ActualizarTodosAsync([FromBody] List<AerolineaOtd> aerolineasOtd)
        {
            if (aerolineasOtd == null)
            {
                _logger.LogWarning("Entidades para actualizar vacia");
                return BadRequest();
            }

            try
            {
                await aerolineaAplicacion.ActualizarTodosAsync(aerolineasOtd).ConfigureAwait(false);
                _logger.LogInformation("Actualizó: {@entidad}", aerolineasOtd);
                return Ok();
            }
            catch (Exception err)
            {
                _logger.LogError(err, "Error actualizando: {@entidad}", aerolineasOtd);
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AerolineaOtd), StatusCodes.Status200OK)]
        public async Task<ActionResult<AerolineaOtd>> ObtenerHorarioIdAerolineaAsync(int id)
        {
            if (id < 1)
            {
                _logger.LogWarning("Identificador para consultar no válido");
                return BadRequest();
            }

            try
            {
                var respuesta = await aerolineaAplicacion.ObtenerHorarioIdAerolineaAsync(id).ConfigureAwait(false);
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
