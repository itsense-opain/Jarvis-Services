
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
    public class AccesoAplicacion : IAccesoAplicacion
    {
        private readonly IAccesoRepositorio accesoRepositorio;
        private readonly IPerfilMapeos mapper;

        public AccesoAplicacion(IAccesoRepositorio acceso, IPerfilMapeos m)
        {
            mapper = m;
            accesoRepositorio = acceso;
        }

        public async Task InsertarAsync(AccesoOtd accesoOtd)
        {
            var acceso = mapper.MapAcceso(accesoOtd);
            await accesoRepositorio.InsertarAsync(acceso);
        }

        public async Task<IList<AccesoOtd>> ObtenerTodosAsync(DateTime inicio, DateTime fin,string aerolinea)
        {
            IList<AccesoOtd> accesosOtd = new List<AccesoOtd>();

            var accesos = await accesoRepositorio.ObtenerTodosAsync(inicio, fin, aerolinea);

            foreach(var item in accesos)
            {
                var acceso = mapper.MapAccesoOtd(item);

                accesosOtd.Add(acceso);
            }
            return accesosOtd;
        }
    }
}
