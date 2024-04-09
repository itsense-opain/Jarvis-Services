
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
    public class HorarioAerolineaAplicacion : IHorarioAerolineaAplicacion
    {
        private readonly IHorarioAerolineaRepositorio horarioRepositorio;
        private readonly IPerfilMapeos mapper;

        public HorarioAerolineaAplicacion(IPerfilMapeos map, IHorarioAerolineaRepositorio horario)
        {
            mapper = map;
            horarioRepositorio = horario;
        }

        public async Task ActualizarAsync(HorarioAerolineaOtd horarioAerolineaOtd)
        {
            var horarioAerolinea = mapper.MapHorarioAerolinea(horarioAerolineaOtd);
            await horarioRepositorio.ActualizarAsync(horarioAerolinea);
        }

        public async Task EliminarAsync(int id)
        {
            await horarioRepositorio.EliminarAsync(id);
        }

        public async Task InsertarAsync(HorarioAerolineaOtd horarioAerolineaOtd)
        {
            var horarioAerolinea = mapper.MapHorarioAerolinea(horarioAerolineaOtd);
            await horarioRepositorio.InsertarAsync(horarioAerolinea);
        }

        public async Task<HorarioAerolineaOtd> ObtenerAsync(int id)
        {
            var horario = await horarioRepositorio.ObtenerAsync(id);
            var horarioOtd = mapper.MapHorarioAerolineaOtd(horario);

            return horarioOtd;
        }

        public async Task<IList<HorarioAerolineaOtd>> ObtenerTodosAsync()
        {
            List<HorarioAerolineaOtd> horariosOtd = new List<HorarioAerolineaOtd>();

            var horarios = await horarioRepositorio.ObtenerTodosAsync().ConfigureAwait(false);

            foreach (var item in horarios)
            {
                var h = mapper.MapHorarioAerolineaOtd(item);
                horariosOtd.Add(h);
            }

            return horariosOtd;
        }

    

    }
}
