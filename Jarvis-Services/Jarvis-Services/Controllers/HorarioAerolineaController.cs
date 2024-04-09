using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Opain.Jarvis.Aplicacion.Interfaces;
using Opain.Jarvis.Dominio.Entidades;
using Opain.Jarvis.Dominio.Entidades;


namespace Jarvis_Services.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //ToDo [Authorize]
    public class HorarioAerolineaController : ControllerBase
    {
        private readonly IHorarioAerolineaAplicacion horarioAplicacion;
        private readonly ILogger<HorarioAerolineaController> _logger;
        //ToDo
        //private readonly Store.OperacionesVuelo Store_OperacionesVuelo;

        public HorarioAerolineaController(IHorarioAerolineaAplicacion horario, ILogger<HorarioAerolineaController> logger)
        {
            horarioAplicacion = horario;
            _logger = logger;
            //this.Store_OperacionesVuelo = store_OperacionesVuelo;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<HorarioAerolineaOtd>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IList<HorarioAerolineaOtd>>> ObtenerTodosAsync()
        {
            try
            {
                var respuesta = await horarioAplicacion.ObtenerTodosAsync();
                _logger.LogInformation("Se ejecutó HorarioAerolineaController.ObtenerTodosAsync");
                return Ok(respuesta);

            }
            catch (Exception err)
            {
                _logger.LogError(err, "Error en HorarioAerolineaController.ObtenerTodosAsync");
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertarAsync([FromBody]HorarioAerolineaOtd horarioAerolineaOtd)
        {
            if (horarioAerolineaOtd == null)
            {
                _logger.LogWarning("Entidad para insertar vacia");
                return BadRequest(false);
            }

            try
            {
                // verifico si existe ps
                var listahorarioex = await horarioAplicacion.ObtenerTodosAsync();
                int existe = 0;
                foreach (var item in listahorarioex)
                {
                    if (item.IdAerolinea.Equals(horarioAerolineaOtd.IdAerolinea) && item.HoraInicio.Equals(horarioAerolineaOtd.HoraInicio) && item.HoraFin.Equals(horarioAerolineaOtd.HoraFin))
                    {
                        existe = 1;
                        break;
                    }
                }

                if (existe == 0)
                {
                    await horarioAplicacion.InsertarAsync(horarioAerolineaOtd).ConfigureAwait(false);
                    _logger.LogInformation("Insertó: {@entidad}" + horarioAerolineaOtd);
                    return Ok(true);
                }
                else {
                    _logger.LogWarning("El horario ya existe para esta aerolinea");
                    return BadRequest(false);
                }
               
            }
            catch (Exception err)
            {
                _logger.LogError(err, "Error insertando: {@entidad} ", horarioAerolineaOtd);
                return BadRequest(false);
            }
        }

        [HttpPost]
        public async Task<IActionResult> ActualizarAsync([FromBody]HorarioAerolineaOtd horarioAerolineaOtd)
        {
            if (horarioAerolineaOtd == null)
            {
                _logger.LogWarning("Entidad para actualizar vacia");
                return BadRequest();
            }

            try
            {
                
                await horarioAplicacion.ActualizarAsync(horarioAerolineaOtd).ConfigureAwait(false);
                _logger.LogInformation("Actualizó: {@entidad}", horarioAerolineaOtd);
                return Ok();
            }
            catch (Exception err)
            {
                _logger.LogError(err, "Error actualizando: {@entidad}", horarioAerolineaOtd);
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
        [ProducesResponseType(typeof(HorarioAerolineaOtd), StatusCodes.Status200OK)]
        public async Task<ActionResult<HorarioAerolineaOtd>> ObtenerAsync(int id)
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
        public async Task<ActionResult> InsertarTripulanteMasivoAsync([FromBody] IList<TripulantesOTD> tripulatesOtd)
        {
            if (tripulatesOtd == null)
            {
                _logger.LogWarning("Entidad para insertar vacia");
                return BadRequest();
            }
           
            try
            {
                //eliminamos tripulante de la areolinea seleccionada
               var codigoAreolinea = tripulatesOtd.First();
                //ToDo
               //bool respuesta =  this.Store_OperacionesVuelo.EjecutarEliminarTripulantes(codigoAreolinea.CodAreolinea);

                //if (respuesta)
                //{                    
                //    this.Store_OperacionesVuelo.EjecutarTripulantes(tripulatesOtd);
                //}         
               
                _logger.LogInformation("Insertó {@cantidad} registros", tripulatesOtd.Count);
                return Ok();
            }
            catch (Exception err)
            {
                _logger.LogError(err, "Error insertando {@cantidad} registros", tripulatesOtd.Count);
                return BadRequest();
            }

        }


    }
}