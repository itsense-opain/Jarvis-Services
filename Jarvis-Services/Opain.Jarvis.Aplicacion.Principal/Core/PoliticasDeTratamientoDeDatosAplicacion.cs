﻿
using Opain.Jarvis.Aplicacion.Interfaces;
using Opain.Jarvis.Dominio.Entidades;
using Opain.Jarvis.Dominio.Entidades.Function;
using Opain.Jarvis.Infraestructura.Datos.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opain.Jarvis.Aplicacion.Principal
{
    public class PoliticasDeTratamientoDeDatosAplicacion : IPoliticasDeTratamientoDeDatosAplicacion
    {
        private readonly IPoliticasDeTratamientoDeDatosRepositorio politicasDeTratamientoDeDatosRepositorio;
        private readonly IPerfilMapeos mapper;

        public PoliticasDeTratamientoDeDatosAplicacion(IPoliticasDeTratamientoDeDatosRepositorio politicasDeTratamientoDeDatos, IPerfilMapeos m)
        {
            mapper = m;
            politicasDeTratamientoDeDatosRepositorio = politicasDeTratamientoDeDatos;
        }

        public async Task InsertarAsync(PoliticasDeTratamientoDeDatosOtd politicasDeTratamientoDeDatosOtd)
        {
            var politicasDeTratamientoDeDatos = mapper.MapPoliticasDeTratamientoDeDatos(politicasDeTratamientoDeDatosOtd);
            await politicasDeTratamientoDeDatosRepositorio.InsertarAsync(politicasDeTratamientoDeDatos);
        }

        public async Task<bool> ObtenerTodosAsync(string NombreUsuario)
        {
            List<PoliticasDeTratamientoDeDatosOtd> politicasDeTratamientoDeDatosOtd = new List<PoliticasDeTratamientoDeDatosOtd>();

            try
            {
                IList<PoliticasDeTratamientoDeDatos> politicasDeTratamientoDeDatos = await politicasDeTratamientoDeDatosRepositorio.ObtenerTodosAsync(NombreUsuario);


                foreach (var item in politicasDeTratamientoDeDatos)
                {
                    var politicasDeTratamientoDeDatosAds = mapper.MapPoliticasDeTratamientoDeDatosOtd(item);

                    politicasDeTratamientoDeDatosOtd.Add(politicasDeTratamientoDeDatosAds);
                }
                if (politicasDeTratamientoDeDatosOtd.Count() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception err)
            {
                return false;

            }

            return true;
        }
    }
}
