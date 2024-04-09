﻿using Opain.Jarvis.Dominio.Entidades;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Opain.Jarvis.Servicios.Store.Metodos
{
    public class OperacionesVuelo
    {
        private readonly Helper.Ejecutor Ejecutor;
        private readonly IConfiguration _config;

        public OperacionesVuelo(Helper.Ejecutor ejecutor, IConfiguration config)
        {
            this.Ejecutor = ejecutor;
            this._config = config;
        }

        public async Task<IList<OperacionVueloOtd>> Find(OperacionVueloOTDRequest Otd)
        {
            List<OperacionVueloOtd> oList;
            DataTable oDT = new DataTable();
            this.Ejecutor.AgregarCampoIn("Opcion", Otd.OpcionOperacion);
            this.Ejecutor.AgregarCampoIn("Id", Otd.Id.ToString());
            this.Ejecutor.AgregarCampoIn("FechaLlegada", Otd.FechaDesde);
            this.Ejecutor.AgregarCampoIn("FechaSalida", Otd.FechaHasta);
            this.Ejecutor.AgregarCampoIn("MatriculaVuelo", Otd.Matricula);
            this.Ejecutor.AgregarCampoIn("TipoVuelo", Otd.Tipo);
            this.Ejecutor.AgregarCampoIn("NumeroVuelo", Otd.Vuelo);
            this.Ejecutor.AgregarCampoIn("IdAerolinea", Otd.IdAerolinea.ToString());
            this.Ejecutor.AgregarCampoIn("EstadoProceso", Otd.EstadoProceso);
            this.Ejecutor.AgregarCampoIn("IdCargue", Otd.IdCargue);
            this.Ejecutor.AgregarCampoIn("Id_Daily", Otd.Id_Daily);
            this.Ejecutor.AgregarCampoIn("IdPasajero", Otd.IdVuelo);
            this.Ejecutor.AgregarCampoIn("NumeroVueloLlegada", "");
            try
            {
                oDT = this.Ejecutor.GetData("FiltroOperacionesVuelo");
                oList = ConvertDataTableToList(oDT);
            }
            catch(Exception oE)
            {
                throw;
            }
            return oList;
        }

        private List<OperacionVueloOtd> ConvertDataTableToList(DataTable oDt)
        {
            //foreach (var item in Lista)
            //{
            //    var vuelo = mapper.Map<OperacionesVuelo, OperacionVueloOtd>(item);
            //    operacionesVueloOtd.Add(vuelo);
            //}


            OperacionVueloOtd Otd;
            List<OperacionVueloOtd> oList = new List<OperacionVueloOtd>();

            foreach (DataRow oR in oDt.Rows)
            {
                try
                {
                    Otd = new OperacionVueloOtd();
                    Otd.Id = int.Parse(oR["Id"].ToString());
                    Otd.IdVuelo = oR["IdVuelo"].ToString() == "" ? 0 : int.Parse(oR["IdVuelo"].ToString());
                    Otd.Fecha = DateTime.Parse(oR["FechaVuelo"].ToString());
                    Otd.Matricula = oR["MatriculaVuelo"].ToString();
                    Otd.Hora = oR["HoraVuelo"].ToString();
                    Otd.TotalEmbarcados = int.Parse(oR["TotalEmbarcados"].ToString());
                    Otd.ConfirmacionPasajeros = int.Parse(oR["ConfirmacionPasajeros"].ToString());
                    Otd.ConfirmacionTransitos = int.Parse(oR["ConfirmacionTransitos"].ToString());
                    Otd.ConfirmacionGenDec = int.Parse(oR["ConfirmacionGenDec"].ToString());
                    Otd.ConfirmacionManifiesto = int.Parse(oR["CanfirmacionManifiesto"].ToString());
                    Otd.ConfirmacionOperacion = int.Parse(oR["ConfirmacionOperacion"].ToString());
                    Otd.INF = int.Parse(oR["INF"].ToString());
                    Otd.TTL = int.Parse(oR["TTL"].ToString());
                    Otd.TTC = int.Parse(oR["TTC"].ToString());
                    Otd.EX = int.Parse(oR["EX"].ToString());
                    Otd.TRIP = int.Parse(oR["TRIP"].ToString());
                    Otd.PAX = int.Parse(oR["PAX"].ToString());
                    Otd.PagoCOP = int.Parse(oR["PagoCOP"].ToString());
                    Otd.PagoUSD = int.Parse(oR["PagoUSD"].ToString());
                    Otd.Tipo = oR["TipoVuelo"].ToString();
                    Otd.Vuelo = oR["NumeroVuelo"].ToString();

                    Otd.Destino = oR["Destino"].ToString();
                    Otd.IdAerolinea = int.Parse(oR["IdAerolinea"].ToString());
                    Otd.EstadoProceso = oR["EstadoProceso"].ToString();
                    Otd.IdCargue = int.Parse(oR["IdCargue"].ToString());
                    Otd.TotalEmbarcados_LIQ = oR["TotalEmbarcados_LIQ"].ToString() == "" ? 0 : int.Parse(oR["TotalEmbarcados_LIQ"].ToString());
                    Otd.FechaCreacion = DateTime.Parse(oR["FechaCreacion"].ToString());
                    Otd.EnvioNotificacion = oR["EnvioNotificacion"].ToString();

                    Otd.NombreAerolinea = oR["NombreAerolinea"].ToString();
                    Otd.SiglaAerolinea = oR["SiglaAerolinea"].ToString();

                    Otd.ArchivoManifiesto= oR["FManifiesto"].ToString();
                    Otd.ArchivoGendec= oR["FGen"].ToString();
                    Otd.ArchivoPasajeros= oR["FPasajeros"].ToString();
                    Otd.ArchivoTransito= oR["FTransitos"].ToString();
                    
                    Otd.PDFPasajeros = oR["PDFPasajeros"].ToString() == "" ? 0 : int.Parse(oR["PDFPasajeros"].ToString());

                    Otd.ConsecutivoCargue = "";
                    Otd.IdConsecutivoCargue = 0;
                    Otd.NovedadCargue = 0;
                    Otd.NovedadProceso =0;

                    oList.Add(Otd);
                }
                catch(Exception oE)
                {

                }
            }
            return oList;
        }
    }
}
