
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
    public class CausalAplicacion : ICausalAplicacion
    {
        private readonly ICausalRepositorio causalRepositorio;
        private readonly IPerfilMapeos mapper;

        public CausalAplicacion(ICausalRepositorio causal, IPerfilMapeos m)
        {
            causalRepositorio = causal;
            mapper = m;
        }

        public async Task ActualizarAsync(CausalOtd causalOtd)
        {
            var causal = mapper.MapCausal(causalOtd);
            await causalRepositorio.ActualizarAsync(causal);
        }

        public async Task EliminarAsync(int id)
        {
            await causalRepositorio.EliminarAsync(id);
        }

        public async Task InsertarAsync(CausalOtd causalOtd)
        {
            var causal = mapper.MapCausal(causalOtd);
            await causalRepositorio.InsertarAsync(causal);
        }

        public async Task<CausalOtd> ObtenerAsync(int id)
        {
            var causal = await causalRepositorio.ObtenerAsync(id);
            var causalOtd = mapper.MapCausalOtd(causal);

            return causalOtd;
        }

        public async Task<CausalOtd> ObtenerPorCodigoAsync(string id)
        {
            var causal = await causalRepositorio.ObtenerPorCodigoAsync(id);
            var causalOtd = mapper.MapCausalOtd(causal);

            return causalOtd;
        }

        public async Task<IList<CausalOtd>> ObtenerTodosAsync()
        {
            List<CausalOtd> causalesOtd = new List<CausalOtd>();

            var causales = await causalRepositorio.ObtenerTodosAsync().ConfigureAwait(false);

            foreach (var item in causales)
            {
                var a = mapper.MapCausalOtd(item);
                causalesOtd.Add(a);
            }

            return causalesOtd;
        }
        public async Task<IList<CausalOtd>> ObtenerPorTipoAsync(int tipo)
        {
            List<CausalOtd> causalesOtd = new List<CausalOtd>();

            var causales = await causalRepositorio.ObtenerPorTipoAsync(tipo).ConfigureAwait(false);

            foreach (var item in causales)
            {
                var a = mapper.MapCausalOtd(item);
                causalesOtd.Add(a);
            }

            return causalesOtd;
        }
    }
}
