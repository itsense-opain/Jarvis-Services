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
    public class PoliticasDeTratamientoDeDatosController : ControllerBase
    {
        private readonly IPoliticasDeTratamientoDeDatosAplicacion politicasDeTratamientoDeDatosAplicacion;
        private readonly ILogger<PoliticasDeTratamientoDeDatosController> _logger;

        public PoliticasDeTratamientoDeDatosController(IPoliticasDeTratamientoDeDatosAplicacion politicasDeTratamientoDeDatos, ILogger<PoliticasDeTratamientoDeDatosController> logger)
        {
            politicasDeTratamientoDeDatosAplicacion = politicasDeTratamientoDeDatos;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> ObtenerTodosAsync(string NombreUsuario)
        {
            IList<PoliticasDeTratamientoDeDatosOtd> politicasDeTratamientoDeDatos = new List<PoliticasDeTratamientoDeDatosOtd>();
            bool Respuesta = false;
            try
            {

                if (!string.IsNullOrEmpty(NombreUsuario))
                {
                    try
                    {
                        Respuesta = await politicasDeTratamientoDeDatosAplicacion.ObtenerTodosAsync(NombreUsuario).ConfigureAwait(false);
                        _logger.LogInformation("Acepto Politica: {@cantidad} registros", Respuesta);
                    }
                    catch (Exception err)
                    {
                        _logger.LogError(err, "Error al consultar la pilitica con el usuario: {@fi}", NombreUsuario);
                    }
                }

                
                return Ok(Respuesta);
            }
            catch (Exception err)
            { 
                _logger.LogError(err, "Error consultando todas los Politicas De Tratamiento De Datos: {@fi}", NombreUsuario);
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertarAsync([FromBody]PoliticasDeTratamientoDeDatosOtd politicasDeTratamientoDeDatosOtd)
        {
            if (politicasDeTratamientoDeDatosOtd == null)
            {
                _logger.LogWarning("Entidad para insertar vacia");
                return BadRequest();
            }

            try
            {
                await politicasDeTratamientoDeDatosAplicacion.InsertarAsync(politicasDeTratamientoDeDatosOtd).ConfigureAwait(false);
                _logger.LogInformation("Insertó: {@entidad}" + politicasDeTratamientoDeDatosOtd);
                return Ok();
            }
            catch (Exception err)
            {
                _logger.LogError(err, "Error insertando: {@entidad} ", politicasDeTratamientoDeDatosOtd);
                return BadRequest();
            }
        }
    }
}