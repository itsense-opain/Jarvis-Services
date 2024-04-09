
using Opain.Jarvis.Aplicacion.Interfaces;
using Opain.Jarvis.Dominio.Entidades;
using Opain.Jarvis.Dominio.Entidades.Function;
using Opain.Jarvis.Infraestructura.Datos.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Opain.Jarvis.Aplicacion.Principal
{
    public class ConsecutivoCargueAplicacion : IConsecutivoCargueAplicacion
    {
        private readonly IConsecutivoCargueRepositorio consecutivoCargueRepositorio;
        private readonly IPerfilMapeos mapper;

        public ConsecutivoCargueAplicacion(IConsecutivoCargueRepositorio ConsecutivoCargue, IPerfilMapeos m)
        {
            consecutivoCargueRepositorio = ConsecutivoCargue;
            mapper = m;
        }

        public async Task<int> InsertarAsync(ConsecutivoCargueOtd cargueOtd)
        {
            var cargue = mapper.MapCargueConsecutivo(cargueOtd);
           return await consecutivoCargueRepositorio.InsertarAsync(cargue);
        }

        public async Task<ConsecutivoCargueOtd> ObtenerAsync(int id)
        {
            var cargue = await consecutivoCargueRepositorio.ObtenerAsync(id);
            var cargueOtd = mapper.MapCargue(cargue);

            return cargueOtd;
        }
    }
}
