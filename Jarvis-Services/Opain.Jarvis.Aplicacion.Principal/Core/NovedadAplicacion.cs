
using Opain.Jarvis.Aplicacion.Interfaces;
using Opain.Jarvis.Dominio.Entidades;
using Opain.Jarvis.Dominio.Entidades;
using Opain.Jarvis.Dominio.Entidades.Function;
using Opain.Jarvis.Infraestructura.Datos.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Opain.Jarvis.Aplicacion.Principal
{
    public class NovedadAplicacion : INovedadAplicacion
    {
        private readonly INovedadRepositorio novedadRepositorio;
        private readonly IPerfilMapeos mapper;

        public NovedadAplicacion(INovedadRepositorio novedad, IPerfilMapeos m)
        {
            novedadRepositorio = novedad;
            mapper = m;
        }

        public async Task ActualizarAsync(NovedadOtd novedadOtd)
        {
            var novedad = mapper.MapNovedadProceso(novedadOtd);
            await novedadRepositorio.ActualizarAsync(novedad);
        }

        public async Task EliminarAsync(int id)
        {
            await novedadRepositorio.EliminarAsync(id);
        }

        public async Task InsertarAsync(NovedadOtd novedadOtd)
        {
            var novedad = mapper.MapNovedadProceso(novedadOtd);
            await novedadRepositorio.InsertarAsync(novedad);
        }

        public async Task<NovedadOtd> ObtenerAsync(int id)
        {
            var novedad = await novedadRepositorio.ObtenerAsync(id);
            var novedadOtd = mapper.MapNovedadOtd(novedad);

            return novedadOtd;
        }

        public async Task<IList<NovedadOtd>> ObtenerTodosAsync()
        {
            List<NovedadOtd> novedadesOtd = new List<NovedadOtd>();

            var novedades = await novedadRepositorio.ObtenerTodosAsync().ConfigureAwait(false);

            foreach (var item in novedades)
            {
                var a = mapper.MapNovedadOtd(item);
                novedadesOtd.Add(a);
            }

            return novedadesOtd;
        }

        public async Task<IList<NovedadOtd>> ObtenerTodosPorOperacionAsync(int id)
        {
            List<NovedadOtd> novedadesOtd = new List<NovedadOtd>();

            var novedades = await novedadRepositorio.ObtenerTodosPorOperacionAsync(id).ConfigureAwait(false);

            foreach (var item in novedades)
            {
                var a = mapper.MapNovedadOtd(item);
                novedadesOtd.Add(a);
            }

            return novedadesOtd;
        }
    }
}
