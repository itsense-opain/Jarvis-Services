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
    public class ConsecutivoCargueController : ControllerBase
    {
        private readonly IConsecutivoCargueAplicacion consecutivoCargueAplicacion;
        private readonly ILogger<ConsecutivoCargueController> _logger;

        public ConsecutivoCargueController(IConsecutivoCargueAplicacion consecutivoCargue, ILogger<ConsecutivoCargueController> logger)
        {
            consecutivoCargueAplicacion = consecutivoCargue;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        public async Task<ActionResult<int>> InsertarAsync([FromBody]ConsecutivoCargueOtd cargueOtd)
        {
            if (cargueOtd == null)
            {
                _logger.LogWarning("Entidad para insertar vacia");
                return BadRequest();
            }

            try
            {
                var id = await consecutivoCargueAplicacion.InsertarAsync(cargueOtd).ConfigureAwait(false);
                _logger.LogInformation("Insertó: {@entidad}" + cargueOtd);
                return Ok(id);
            }
            catch (Exception err)
            {
                _logger.LogError(err, "Error insertando: {@entidad} ", cargueOtd);
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ConsecutivoCargueOtd), StatusCodes.Status200OK)]
        public async Task<ActionResult<ConsecutivoCargueOtd>> ObtenerAsync(int id)
        {
            if (id < 1)
            {
                _logger.LogWarning("Identificador para consultar no válido");
                return BadRequest();
            }

            try
            {
                var respuesta = await consecutivoCargueAplicacion.ObtenerAsync(id).ConfigureAwait(false);
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