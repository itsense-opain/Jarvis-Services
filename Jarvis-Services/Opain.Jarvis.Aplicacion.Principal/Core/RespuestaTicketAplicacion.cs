
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
    public class RespuestaTicketAplicacion : IRespuestaTicketAplicacion
    {
        private readonly IRespuestaTicketRepositorio rticketRepositorio;
        private readonly ITicketRepositorio ticketRepositorio;
        private readonly IPerfilMapeos mapper;

        public RespuestaTicketAplicacion(ITicketRepositorio ticket, IRespuestaTicketRepositorio rticket, IPerfilMapeos m)
        {
            ticketRepositorio = ticket;
            mapper = m;
            rticketRepositorio = rticket;
        }
        public async Task ActualizarAsync(RespuestaTicketOtd rTicketOtd)
        {
            var rticket = mapper.MapRespuestaTicket(rTicketOtd);
            await rticketRepositorio.ActualizarAsync(rticket);
        }

        public async Task EliminarAsync(int id)
        {
            await rticketRepositorio.EliminarAsync(id);
        }

        public async Task InsertarAsync(RespuestaTicketOtd rTicketOtd)
        {
            var rticket = mapper.MapRespuestaTicket(rTicketOtd);
            await rticketRepositorio.InsertarAsync(rticket);

            var ticket = await ticketRepositorio.ObtenerAsync(rticket.IdTicket);

            if(ticket.Seguimiento == 1)
            {
                ticket.Seguimiento = 0;
                await ticketRepositorio.ActualizarAsync(ticket);
            }            
        }

        public async Task<RespuestaTicketOtd> ObtenerAsync(int id)
        {
            var ticket = await rticketRepositorio.ObtenerAsync(id);
            var rticketOtd = mapper.MapRespuestaTicketOtd(ticket);

            return rticketOtd;
        }

        public async Task<IList<RespuestaTicketOtd>> ObtenerPorTicketAsync(int id)
        {
            List<RespuestaTicketOtd> rticketsOtd = new List<RespuestaTicketOtd>();

            var rtickets = await rticketRepositorio.ObtenerPorTicketAsync(id).ConfigureAwait(false);

            foreach (var item in rtickets)
            {
                var r = mapper.MapRespuestaTicketOtd(item);
                rticketsOtd.Add(r);
            }

            return rticketsOtd;
        }
    }
}
