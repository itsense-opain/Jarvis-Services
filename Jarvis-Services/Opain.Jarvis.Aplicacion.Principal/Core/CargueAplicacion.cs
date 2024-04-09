
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
    public class CargueAplicacion : ICargueAplicacion
    {
        private readonly ICargueRepositorio cargueRepositorio;
        private readonly IPerfilMapeos mapper;

        public CargueAplicacion(ICargueRepositorio cargue, IPerfilMapeos m)
        {
            mapper = m;
            cargueRepositorio = cargue;
        }

        public async Task<CargueOtd> InsertarAsync(CargueOtd cargueOtd)
        {
            var cargue = mapper.MapCargue(cargueOtd);
            await cargueRepositorio.InsertarAsync(cargue);
            return mapper.MapCargueOtd(cargue);
        }

        public async Task<IList<CargueOtd>> ObtenerTodosAsync(DateTime inicio, DateTime fin)
        {
            IList<CargueOtd> carguesOtd = new List<CargueOtd>();

            var cargues = await cargueRepositorio.ObtenerTodosAsync(inicio, fin);

            foreach (var item in cargues)
            {
                var cargue = mapper.MapCargueOtd(item);
                carguesOtd.Add(cargue);
            }
            return carguesOtd;
        }
    }
}
