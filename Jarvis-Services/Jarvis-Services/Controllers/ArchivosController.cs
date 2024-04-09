using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Opain.Jarvis.Aplicacion.Interfaces;
using Opain.Jarvis.Dominio.Entidades;

namespace Jarvis_Services.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [AllowAnonymous]
    public class ArchivosController : ControllerBase
    {
        private readonly IArchivoAplicacion archivoAplicacion;
        private readonly ILogger<ArchivosController> _logger;

        public ArchivosController(IArchivoAplicacion archivo, ILogger<ArchivosController> logger)
        {
            archivoAplicacion = archivo;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> InsertarAsync([FromBody] ArchivoOtd archivoOtd)
        {
            if (archivoOtd == null)
            {
                _logger.LogWarning("Entidad para insertar vacia");
                return BadRequest();
            }

            try
            {
                await archivoAplicacion.InsertarAsync(archivoOtd);
                _logger.LogInformation("Insertó {@entidad}" + archivoOtd);
                return Ok();
            }
            catch (Exception err)
            {
                _logger.LogError(err, "Error insertando {@entidad} ", archivoOtd);
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertarMasivoAsync([FromBody] IList<ArchivoOtd> archivosOtd)
        {
            if (archivosOtd == null)
            {
                _logger.LogWarning("Entidad para insertar vacia");
                return BadRequest();
            }

            try
            {
                await archivoAplicacion.InsertarMasivoAsync(archivosOtd);
                _logger.LogInformation("Insertó {@cantidad} registros", archivosOtd.Count);
                return Ok();
            }
            catch (Exception err)
            {
                _logger.LogError(err, "Error insertando {@cantidad} registros", archivosOtd.Count);
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> ActualizarAsync([FromBody] ArchivoOtd archivoOtd)
        {
            if (archivoOtd == null)
            {
                _logger.LogWarning("Entidad para actualizar vacia");
                return BadRequest();
            }

            try
            {
                await archivoAplicacion.ActualizarAsync(archivoOtd);
                _logger.LogInformation("Actualizó: {@entidad}", archivoOtd);
                return Ok();
            }
            catch (Exception err)
            {
                _logger.LogError(err, "Error actualizando: {@entidad}", archivoOtd);
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
                await archivoAplicacion.EliminarAsync(id);
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
        [ProducesResponseType(typeof(ArchivoOtd), StatusCodes.Status200OK)]
        public async Task<ActionResult<ArchivoOtd>> ObtenerAsync(int id)
        {
            if (id < 1)
            {
                _logger.LogWarning("Identificador para consultar no válido");
                return BadRequest();
            }

            try
            {
                var respuesta = await archivoAplicacion.ObtenerAsync(id);
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
        [ProducesResponseType(typeof(ArchivoOtd), StatusCodes.Status200OK)]
        public async Task<ActionResult<ArchivoOtd>> ObtenerPorOperacionAsync(int idOperacion)
        {
            try
            {
                var respuesta = await archivoAplicacion.ObtenerPorOperacionAsync(idOperacion);
                _logger.LogInformation("Consultó: {@entidad}", respuesta);
                return Ok(respuesta);
            }
            catch (Exception err)
            {
                _logger.LogError(err, "Error consultando id: {@id}", idOperacion);
                return BadRequest();
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> ValidarAsync([FromBody] ArchivoOtd archivoOtd)
        {
            if (archivoOtd == null)
            {
                _logger.LogWarning("Entidad para validar vacia");
                return BadRequest(false);
            }

            try
            {
                IList<ArchivoOtd> listadoArchivos = await archivoAplicacion.ObtenerPorOperacionAsync(archivoOtd.Operacion);

                if (listadoArchivos.Count > 0)
                {
                    foreach (var item in listadoArchivos.Where(x => x.Tipo.Equals(archivoOtd.Tipo)))
                    {
                        await archivoAplicacion.EliminarAsync(item.Id);
                    }
                }

                await archivoAplicacion.InsertarAsync(archivoOtd);
                _logger.LogInformation("Validó: {@entidad}", archivoOtd);
                return Ok(true);
            }
            catch (Exception err)
            {
                _logger.LogError(err, "Error validando: {@entidad}", archivoOtd);
                return BadRequest(false);
            }
        }

    }
}
