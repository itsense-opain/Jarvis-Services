﻿
using Opain.Jarvis.Aplicacion.Interfaces;
using Opain.Jarvis.Dominio.Entidades;
using Opain.Jarvis.Dominio.Entidades;
using Opain.Jarvis.Infraestructura.Datos.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using Opain.Jarvis.Dominio.Entidades.Function;

namespace Opain.Jarvis.Aplicacion.Principal
{
    public class PasajeroAplicacion : IPasajeroAplicacion
    {
        private readonly IPasajeroRepositorio pasajeroRepositorio;
        private readonly IPerfilMapeos mapper;

        public PasajeroAplicacion(IPasajeroRepositorio PasajeroRepositorio,
            IPerfilMapeos Mapper)
        {
            pasajeroRepositorio = PasajeroRepositorio;
            mapper = Mapper;
        }

        public async Task ActualizarAsync(PasajeroOtd pasajeroOtd)
        {
            Pasajero p = mapper.MapPasajero(pasajeroOtd);

            await pasajeroRepositorio.ActualizarAsync(p).ConfigureAwait(false);
        }

        public async Task EliminarAsync(int id)
        {
            await pasajeroRepositorio.EliminarAsync(id).ConfigureAwait(false);
        }

        public async Task InsertarAsync(PasajeroOtd pasajeroOtd)
        {
            Pasajero p = mapper.MapPasajero(pasajeroOtd);            

            await pasajeroRepositorio.InsertarAsync(p).ConfigureAwait(false);

        }

        public async Task ProcesarArchivoAsync(StreamReader archivo, string nombreArchivo)
        {
            IList<Pasajero> pasajeros = new List<Pasajero>();
            IList<PasajeroOtd> pasajerosOtd = new List<PasajeroOtd>();
            string nombre = nombreArchivo.Replace(".txt", "").Replace(".csv", "").Replace("PAX", "");
            var datos = nombre.Split("-");
            int idOperacionVuelo = int.Parse(datos[0]);

            string linea;
            while ((linea = archivo.ReadLine()) != null)
            {
                var campos = linea.Split(",");
                pasajerosOtd.Add(new PasajeroOtd()
                {
                    Fecha = new DateTime(int.Parse(campos[0].Substring(6, 4)), int.Parse(campos[0].Substring(3, 2)), int.Parse(campos[0].Substring(0, 2))),
                    NumeroVuelo = campos[1],
                    MatriculaVuelo = campos[2],
                    NombrePasajero = campos[3],
                    Categoria = campos[4]
                });
            }

            foreach (var item in pasajerosOtd)
            {
                var pasajero = mapper.MapPasajero(item);
                pasajero.IdOperacionVuelo = idOperacionVuelo;
                pasajeros.Add(pasajero);
            }

            await pasajeroRepositorio.EliminarOperacionAsync(idOperacionVuelo);

            await pasajeroRepositorio.InsertarMasivoAsync(pasajeros);

        }

        public async Task<PasajeroOtd> ObtenerAsync(int id)
        {
            var pasajero = await pasajeroRepositorio.ObtenerAsync(id).ConfigureAwait(false);
            var p = mapper.MapPasajeroOtd(pasajero);


            return p;
        }

        public async Task<IList<PasajeroOtd>> ObtenerTodosAsync(int idVuelo)
        {
            List<PasajeroOtd> pasajeros = new List<PasajeroOtd>();

            var pasajeroRep = await pasajeroRepositorio.ObtenerTodosAsync(idVuelo).ConfigureAwait(false);

            foreach (var item in pasajeroRep)
            {
                var p = mapper.MapPasajeroOtd(item);
                p.NombrePasajero = p.NombrePasajero.Trim().ToUpper();
                pasajeros.Add(p);
            }

            return pasajeros;
        }

        public async Task InsertarMasivoAsync(IList<PasajeroOtd> pasajeroOtd)
        {
            int idOperacionVuelo = pasajeroOtd.FirstOrDefault().Operacion;

            IList<Pasajero> pasajeros = new List<Pasajero>();
            foreach (var item in pasajeroOtd)
            {
                var pasajero = mapper.MapPasajero(item);
                pasajeros.Add(pasajero);
            }

            await pasajeroRepositorio.EliminarOperacionAsync(idOperacionVuelo);

            await pasajeroRepositorio.InsertarMasivoAsync(pasajeros);
        }

        public Task<IList<ExentoODT>> ObtenerExentos(string numerovuelo, string fecha)
        {
            var exentos = new List<ExentoODT>();

            //var exentosRep = await pasajeroRepositorio.ObtenerTodosAsync(idVuelo).ConfigureAwait(false);
            return null;
        }
    }
}
