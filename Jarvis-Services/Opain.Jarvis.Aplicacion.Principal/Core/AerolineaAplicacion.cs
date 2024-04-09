﻿
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
    public class AerolineaAplicacion : IAerolineaAplicacion
    {
        private readonly IAerolineaRepositorio aerolineaRepositorio;
        private readonly IPerfilMapeos mapper;

        public AerolineaAplicacion(IAerolineaRepositorio aerolinea,IPerfilMapeos m)
        {
            mapper = m;
            aerolineaRepositorio = aerolinea;
        }

        public async Task ActualizarAsync(AerolineaOtd aerolineaOtd)
        {
            var aerolinea = mapper.MapAerolinea(aerolineaOtd);
            await aerolineaRepositorio.ActualizarAsync(aerolinea);
        }

        public async Task ActualizarTodosAsync(List<AerolineaOtd> aerolineasOtd)
        {
            List<Aerolinea> aerolineas = new List<Aerolinea>();

            foreach (var item in aerolineasOtd)
            {
                var aerolinea = mapper.MapAerolinea(item);
                aerolineas.Add(aerolinea);
            }
            
            await aerolineaRepositorio.ActualizarTodosAsync(aerolineas);
        }

        public async Task EliminarAsync(int id)
        {
            await aerolineaRepositorio.EliminarAsync(id);
        }

        public async Task InsertarAsync(AerolineaOtd aerolineaOtd)
        {
            var aerolinea = mapper.MapAerolinea(aerolineaOtd);
            await aerolineaRepositorio.InsertarAsync(aerolinea);
        }

        public async Task<AerolineaOtd> ObtenerAsync(int id)
        {
            var aerolinea = await aerolineaRepositorio.ObtenerAsync(id);
            var aerolineaOtd = mapper.MapAerolineaOtd(aerolinea);

            return aerolineaOtd;
        }

        public async Task<IList<AerolineaOtd>> ObtenerTodosAsync()
        {
            List<AerolineaOtd> aerolineasOtd = new List<AerolineaOtd>();

            var aerolineas = await aerolineaRepositorio.ObtenerTodosAsync().ConfigureAwait(false);

            foreach (var item in aerolineas)
            {
                var a = mapper.MapAerolineaOtd(item);
                aerolineasOtd.Add(a);
            }

            return aerolineasOtd;
        }



        public async Task<IList<AerolineaOtd>> ObtenerHorarioIdAerolineaAsync(int IdAeroinea)
        {
            List<AerolineaOtd> aerolineasOtd = new List<AerolineaOtd>();

            var aerolineas = await aerolineaRepositorio.ObtenerHorarioIdAerolineaAsync(IdAeroinea);

            foreach (var item in aerolineas)
            {
                var a = mapper.MapAerolineaOtd(item);
                aerolineasOtd.Add(a);
            }

            return aerolineasOtd;
        }


    }
}
