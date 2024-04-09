﻿
using Opain.Jarvis.Aplicacion.Interfaces;
using Opain.Jarvis.Dominio.Entidades;
using Opain.Jarvis.Dominio.Entidades.Function;
using Opain.Jarvis.Infraestructura.Datos.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opain.Jarvis.Aplicacion.Principal
{
    public class TasaAeroportuariaAplicacion : ITasaAeroportuariaAplicacion
    {
        private readonly ITasaAeroportuariaRepositorio tasaRepositorio;
        private readonly IPerfilMapeos mapper;

        public TasaAeroportuariaAplicacion(IPerfilMapeos map, ITasaAeroportuariaRepositorio tasa)
        {
            mapper = map;
            tasaRepositorio = tasa;
        }

        public async Task ActualizarAsync(TasaAeroportuariaOtd tasaAeroportuariaOtd)
        {
            var tasa = mapper.MapTasaAeroportuaria(tasaAeroportuariaOtd);
            await tasaRepositorio.ActualizarAsync(tasa);
        }

        public async Task EliminarAsync(int id)
        {
            await tasaRepositorio.EliminarAsync(id);
        }

        public async Task InsertarAsync(TasaAeroportuariaOtd tasaAeroportuariaOtd)
        {
            var tasa = mapper.MapTasaAeroportuaria(tasaAeroportuariaOtd);
            await tasaRepositorio.InsertarAsync(tasa);
        }

        public async Task<TasaAeroportuariaOtd> ObtenerAsync(int id)
        {
            var tasa = await tasaRepositorio.ObtenerAsync(id);
            var tasaOdt = mapper.MapTasaAeroportuariaOtd(tasa);

            return tasaOdt;
        }

        public async Task<IList<TasaAeroportuariaOtd>> ObtenerTodosAsync()
        {
            List<TasaAeroportuariaOtd> tasasOtd = new List<TasaAeroportuariaOtd>();

            var tasas = await tasaRepositorio.ObtenerTodosAsync().ConfigureAwait(false);

            foreach (var item in tasas)
            {
                var t = mapper.MapTasaAeroportuariaOtd(item);
                tasasOtd.Add(t);
            }

            return tasasOtd;
        }

        public async Task<TasaAeroportuariaOtd> ObtenerUltimaAsync()
        {
            var tasas = await tasaRepositorio.ObtenerTodosAsync().ConfigureAwait(false);

            var tasa = tasas.OrderByDescending(x => x.Id).FirstOrDefault();

            var tasaOtd = mapper.MapTasaAeroportuariaOtd(tasa);

            return tasaOtd;
        }
    }
}
