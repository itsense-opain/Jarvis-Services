using Opain.Jarvis.Dominio.Entidades.Function;
using System;
using System.Linq;

namespace Opain.Jarvis.Dominio.Entidades
{
    public class PerfilMapeos : IPerfilMapeos
    {
        public PerfilMapeos()
        {

        }

        public OperacionesVuelo MapOperacionVuelo(OperacionVueloOtd objEntrada)
        {
            var objSalida = new OperacionesVuelo()
            {
                FechaVuelo = objEntrada.Fecha,
                MatriculaVuelo = objEntrada.Matricula,
                HoraVuelo = objEntrada.Hora,
                TotalEmbarcados = objEntrada.TotalEmbarcados,
                PagoCOP = objEntrada.PagoCOP,
                PagoUSD = objEntrada.PagoUSD,                
                IdAerolinea = objEntrada.IdAerolinea,
                TipoVuelo = objEntrada.Tipo,
                NumeroVuelo = objEntrada.Vuelo,
                Destino = objEntrada.Destino,
                TotalEmbarcados_LIQ = objEntrada.TotalEmbarcados_LIQ,
                TotalEmbarcadosAdd = objEntrada.TotalEmbarcadosAdd,
            };

            return objSalida;
        }

        public OperacionVueloOtd MapOperacionVueloOtd(OperacionesVuelo objEntrada)
        {
            var objSalida = new OperacionVueloOtd()
            {
                Fecha = objEntrada.FechaCreacion,
                Matricula = objEntrada.MatriculaVuelo,
                Hora = objEntrada.HoraVuelo,
                TotalEmbarcados = objEntrada.TotalEmbarcados,
                PagoCOP = objEntrada.PagoCOP,
                PagoUSD = objEntrada.PagoUSD,
                TotalEmbarcados_LIQ = objEntrada.TotalEmbarcados_LIQ,
                TotalEmbarcadosAdd = objEntrada.TotalEmbarcadosAdd,
            };

            return objSalida;
        }

        public Pasajero MapPasajero(PasajeroOtd objEntrada)
        {
            var objSalida = new Pasajero()
            {
                IdCategoriaPasajero = objEntrada.Categoria,
                IdOperacionVuelo = objEntrada.Operacion,
                FechaVuelo = objEntrada.Fecha,
                NumeroVuelo = objEntrada.NumeroVuelo,
                MatriculaVuelo = objEntrada.MatriculaVuelo,
                Realiza_viaje = objEntrada.realiza_viaje,
                Motivo_exencion = objEntrada.motivo_exencion,
                IdCargue = objEntrada.IdCargue,
                NombrePasajero = objEntrada.NombrePasajero
            };

            return objSalida;
        }

        public PasajeroOtd MapPasajeroOtd(Pasajero objEntrada)
        {
            var objSalida = new PasajeroOtd()
            {
                Id = objEntrada.Id,
                Categoria = objEntrada.IdCategoriaPasajero,
                Operacion = objEntrada.IdOperacionVuelo,
                NombrePasajero = objEntrada.NombrePasajero,
                Fecha = objEntrada.FechaVuelo,
                MatriculaVuelo = objEntrada.MatriculaVuelo,
                NombreAerolinea = objEntrada.OperacionesVuelo.Aerolinea.Nombre,
                TipoVuelo = objEntrada.OperacionesVuelo.TipoVuelo,
                realiza_viaje = objEntrada.Realiza_viaje,
                motivo_exencion = objEntrada.Motivo_exencion,
                IdCargue = objEntrada.IdCargue,
                NumeroVuelo = objEntrada.NumeroVuelo
            };

            return objSalida;
        }

        public PasajeroTransito MapPasajeroTransito(PasajeroTransitoOtd objEntrada)
        {
            var objSalida = new PasajeroTransito()
            {
                FechaHoraCargue = objEntrada.FechaHoraCargue,
                Firmado = objEntrada.Firmado,
                FechaHoraFirma = objEntrada.FechaHoraFirma,
                FechaLlegada = objEntrada.FechaLlegada,
                IdOperacionVuelo = objEntrada.Operacion,
                HoraLlegada = objEntrada.HoraLlegada,
                FechaSalida = objEntrada.FechaSalida,
                HoraSalida = objEntrada.HoraSalida,
                NombrePasajero = objEntrada.NombrePasajero,
                IdVueloSalida = 0, // You provided two ForMember statements for IdVueloSalida, so I'm assuming the value is 0
                NumeroVueloSalida = objEntrada.NumeroVueloSalida,
                Destino = objEntrada.Destino,
                NumeroVueloLlegada = objEntrada.NumeroVueloLlegada,
                Origen = objEntrada.Origen,
                AerolineaLlegada = objEntrada.AerolineaLlegada,
                IdCargue = objEntrada.IdCargue,
                Categoria = objEntrada.TTC == 1 ? "TTC" : "TTL"
            };

            return objSalida;
        }

        public PasajeroTransitoOtd MapPasajeroTransitoOtd(PasajeroTransito objEntrada)
        {
            var objSalida = new PasajeroTransitoOtd()
            {
                AerolineaSalida = objEntrada.AerolineaSalida,
                IdCargue = objEntrada.IdCargue,
                AerolineaLlegada = objEntrada.AerolineaLlegada,
                FechaHoraCargue = objEntrada.FechaHoraCargue,
                Firmado = objEntrada.Firmado,
                FechaHoraFirma = objEntrada.FechaHoraFirma,
                FechaLlegada = objEntrada.FechaLlegada,
                HoraLlegada = objEntrada.HoraLlegada,
                FechaSalida = objEntrada.FechaSalida,
                HoraSalida = objEntrada.HoraSalida,
                NombrePasajero = objEntrada.NombrePasajero,
                Id = objEntrada.Id,
                NumeroVueloLlegada = objEntrada.NumeroVueloLlegada,
                Origen = objEntrada.Origen,
                NumeroVueloSalida = objEntrada.NumeroVueloSalida,
                Destino = objEntrada.Destino,
                Operacion = objEntrada.IdOperacionVuelo,
                NombreAerolinea = objEntrada.OperacionesVuelo.Aerolinea.Nombre,
                TipoVuelo = objEntrada.OperacionesVuelo.TipoVuelo,
                Tipo = objEntrada.Categoria,
                TTC = objEntrada.Categoria == "TTC" ? 1 : 0,
                TTL = objEntrada.Categoria == "TTL" ? 1 : 0
            };

            return objSalida;
        }

        public RutaArchivos MapArchivo(ArchivoOtd objEntrada)
        {
            var objSalidaOtd = new RutaArchivos()
            {
                Id = objEntrada.Id,
                NombreArchivo = objEntrada.Nombre,
                TipoArchivo = objEntrada.Tipo,
                OperacionesVuelosId = objEntrada.Operacion
            };

            return objSalidaOtd;
        }
        public ArchivoOtd MapArchivoOtd(RutaArchivos objEntrada)
        {
            var objSalidaOtd = new ArchivoOtd()
            {
                Id = objEntrada.Id,
                Nombre = objEntrada.NombreArchivo,
                Tipo = objEntrada.TipoArchivo,
                Operacion = objEntrada.OperacionesVuelosId
            };

            return objSalidaOtd;
        }


        public UsuarioOtd MapUsuarioOtd(Usuario objEntrada)
        {
            var usuarioOtd = new UsuarioOtd
            {
                //UsuarioAerolinea = objEntrada.UsuariosAerolineas, ToDo
                TwoFactorEnabled = objEntrada.TwoFactorEnabled == true ? 1 : 0,
                UserName = objEntrada.UserName,
                SecurityStamp = objEntrada.SecurityStamp,
                PhoneNumberConfirmed = objEntrada.PhoneNumberConfirmed == true ? 1 : 0,
                PhoneNumber = objEntrada.PhoneNumber,
                PasswordHash = objEntrada.PasswordHash,
                NormalizedUserName = objEntrada.NormalizedUserName,
                NormalizedEmail = objEntrada.NormalizedEmail,
                Nombre = objEntrada.Nombre,
                LockoutEnd = objEntrada.LockoutEnd == null ? "" : objEntrada.LockoutEnd.ToString(),
                LockoutEnabled = objEntrada.LockoutEnabled.ToString(),
                Id = objEntrada.Id,
                EmailConfirmed = objEntrada.EmailConfirmed == true ? 1 : 0,
                Email = objEntrada.Email,
                ConcurrencyStamp = objEntrada.ConcurrencyStamp,
                Apellido = objEntrada.Apellido,
                Telefono = objEntrada.Telefono,
                Cargo = objEntrada.Cargo,
                Activo = objEntrada.Activo,
                TipoDocumento = objEntrada.TipoDocumento,
                NumeroDocumento = objEntrada.NumeroDocumento,
                AccessFailedCount = objEntrada.AccessFailedCount.ToString(),
                //ToDo
                //RolesUsuario = objEntrada.RolesUsuarios,
                Aerolinea = objEntrada.UsuariosAerolineas.FirstOrDefault()?.Aerolinea?.Nombre,
                Perfil = objEntrada.RolesUsuarios.FirstOrDefault()?.Rol?.Name
            };

            return usuarioOtd;
        }

        public UsuariosAerolineasOtd MapUsuariosAerolineasOtd(UsuariosAerolineas objEntrada)
        {
            var usuariosAerolineasOtd = new UsuariosAerolineasOtd
            {
                Id = objEntrada.Id,
                IdAerolinea = objEntrada.IdAerolinea,
                IdUsuario = objEntrada.IdUsuario
            };

            return usuariosAerolineasOtd;
        }

        public HorarioAerolinea MapHorarioAerolinea(HorarioAerolineaOtd objEntrada)
        {
            var horarioAerolineaOtd = new HorarioAerolinea
            {
                Id = objEntrada.Id,
                Fecha = objEntrada.Fecha,
                HoraFin = objEntrada.HoraFin,
                HoraInicio = objEntrada.HoraInicio,
                IdAerolinea = objEntrada.IdAerolinea,
                //Aerolinea = objEntrada.Aerolinea ToDo
            };
            return horarioAerolineaOtd;
        }

        public HorarioAerolineaOtd MapHorarioAerolineaOtd(HorarioAerolinea objEntrada)
        {
            var horarioAerolineaOtd = new HorarioAerolineaOtd
            {
                Id = objEntrada.Id,
                Fecha = objEntrada.Fecha,
                HoraFin = objEntrada.HoraFin,
                HoraInicio = objEntrada.HoraInicio,
                IdAerolinea = objEntrada.IdAerolinea,
                Aerolinea = objEntrada.Aerolinea?.Nombre
            };
            return horarioAerolineaOtd;
        }

        public AerolineaOtd MapAerolineaOtd(Aerolinea objEntrada)
        {
            var aerolineaOtd = new AerolineaOtd
            {
                Id = objEntrada.Id,
                Nombre = objEntrada.Nombre,
                Sigla = objEntrada.Sigla,
                Codigo = objEntrada.Codigo,
                IdEstado = objEntrada.IdEstado ? "True" : "False",
                PDFPasajeros = objEntrada.PDFPasajeros.ToString(),
                CantidadUsuarios = objEntrada.CantidadUsuarios
            };

            return aerolineaOtd;
        }

        public Aerolinea MapAerolinea(AerolineaOtd objEntrada)
        {
            var aerolinea = new Aerolinea
            {
                Id = objEntrada.Id,
                Nombre = objEntrada.Nombre,
                Sigla = objEntrada.Sigla,
                IdEstado = objEntrada.IdEstado == "True",
                PDFPasajeros = Convert.ToInt32(objEntrada.PDFPasajeros),
                CantidadUsuarios = objEntrada.CantidadUsuarios
            };

            return aerolinea;
        }

        public RolesUsuariosOtd MapRolesUsuariosOtd(RolesUsuarios objEntrada)
        {
            var rolesUsuariosOtd = new RolesUsuariosOtd
            {
                Rol = MapRolOtd(objEntrada.Rol)
            };

            return rolesUsuariosOtd;
        }

        public RolOtd MapRolOtd(Rol objEntrada)
        {
            var rolOtd = new RolOtd
            {
                Id = objEntrada.Id,
                Name = objEntrada.Name,
                NormalizedName = objEntrada.NormalizedName,
                ConcurrencyStamp = objEntrada.ConcurrencyStamp
            };

            return rolOtd;
        }

        public TasaAeroportuaria MapTasaAeroportuaria(TasaAeroportuariaOtd objEntrada)
        {
            var rolOtd = new TasaAeroportuaria
            {
                Id = objEntrada.Id,
                ValorCOP = (decimal)objEntrada.ValorCOP,
                ValorUSD = (decimal)objEntrada.ValorUSD,
                Fecha = objEntrada.Fecha
            };

            return rolOtd;

        }
        public TasaAeroportuariaOtd MapTasaAeroportuariaOtd(TasaAeroportuaria objEntrada)
        {
            var rolOtd = new TasaAeroportuariaOtd
            {
                Id = objEntrada.Id,
                ValorCOP = (float)objEntrada.ValorCOP,
                ValorUSD = (float)objEntrada.ValorUSD,
                Fecha = objEntrada.Fecha
            };

            return rolOtd;
        }


        public HorarioOperacion MapHorarioOperacion(HorarioOperacionOtd objEntrada)
        {
            var rolOtd = new HorarioOperacion
            {
                Id = objEntrada.Id,
                Dia = objEntrada.Dia,
                HoraInicio = objEntrada.HoraInicio,
                HoraFin = objEntrada.HoraFin
            };

            return rolOtd;
        }
        public HorarioOperacionOtd MapHorarioOperacionOtd(HorarioOperacion objEntrada)
        {
            var rolOtd = new HorarioOperacionOtd
            {
                Id = objEntrada.Id,
                Dia = objEntrada.Dia,
                HoraInicio = objEntrada.HoraInicio,
                HoraFin = objEntrada.HoraFin
            };

            return rolOtd;
        }

        public IngresoOtd MapIngresoOtd(Ingreso objEntrada)
        {
            var rolOtd = new IngresoOtd
            {
                Usuario = objEntrada.Username,
                Contrasena = objEntrada.Password
            };

            return rolOtd;
        }

        public TicketOtd MapTicketOtd(Ticket objEntrada)
        {
            var ticketOtd = new TicketOtd
            {
                Id = objEntrada.Id,
                IdAerolinea = objEntrada.IdAerolinea,
                NumeroTicket = objEntrada.NumeroTicket,
                TipoConsulta = objEntrada.TipoConsulta,
                Asunto = objEntrada.Asunto,
                FechaVuelo = objEntrada.FechaVuelo,
                FechaCreacion = objEntrada.FechaCreacion,
                Mensaje = objEntrada.Mensaje,
                Adjunto = objEntrada.Adjunto,
                Estado = objEntrada.Estado,
                NombreAerolinea = objEntrada.Aerolinea?.Nombre,
                NombreUsuario = string.Format("{0} {1}", objEntrada.Usuario.Nombre, objEntrada.Usuario.Apellido),
                IdUsuario = objEntrada.IdUsuario,
                Seguimiento = objEntrada.Seguimiento,
                //Respuestas = MapRespuestaTicketOtd(objEntrada.RespuestasTickets.ToList()) ToDo
            };

            return ticketOtd;
        }

        public Ticket MapTicket(TicketOtd objEntrada)
        {
            var ticket = new Ticket
            {
                Id = objEntrada.Id,
                IdAerolinea = objEntrada.IdAerolinea,
                NumeroTicket = objEntrada.NumeroTicket,
                TipoConsulta = objEntrada.TipoConsulta,
                Asunto = objEntrada.Asunto,
                FechaVuelo = objEntrada.FechaVuelo,
                FechaCreacion = objEntrada.FechaCreacion,
                Mensaje = objEntrada.Mensaje,
                Adjunto = objEntrada.Adjunto,
                Estado = objEntrada.Estado,
                IdUsuario = objEntrada.IdUsuario,
                Seguimiento = objEntrada.Seguimiento
            };

            return ticket;
        }

        public RespuestaTicketOtd MapRespuestaTicketOtd(RespuestaTicket objEntrada)
        {
            var respuestaTicketOtd = new RespuestaTicketOtd
            {
                Id = objEntrada.Id,
                IdTicket = objEntrada.IdTicket,
                FechaCreacion = objEntrada.FechaCreacion,
                Mensaje = objEntrada.Mensaje,
                Adjunto = objEntrada.Adjunto,
                NombreUsuario = string.Format("{0} {1}", objEntrada.Usuario.Nombre, objEntrada.Usuario.Apellido),
                IdUsuario = objEntrada.IdUsuario
            };

            return respuestaTicketOtd;
        }

        public RespuestaTicket MapRespuestaTicket(RespuestaTicketOtd objEntrada)
        {
            var respuestaTicket = new RespuestaTicket
            {
                Id = objEntrada.Id,
                IdTicket = objEntrada.IdTicket,
                FechaCreacion = objEntrada.FechaCreacion,
                Mensaje = objEntrada.Mensaje,
                Adjunto = objEntrada.Adjunto,
                IdUsuario = objEntrada.IdUsuario
            };

            return respuestaTicket;
        }

        public AccesoOtd MapAccesoOtd(Acceso objEntrada)
        {
            var respuestaTicket = new AccesoOtd
            {
                Id = objEntrada.Id,
                Grupo = objEntrada.Grupo,
                Rol = objEntrada.Rol,
                NombreUsuario = objEntrada.NombreUsuario,
                Fecha = objEntrada.Fecha,
                Hora = objEntrada.Hora,
                IdAeroLineas = objEntrada.IdAeroLineas,
            };

            return respuestaTicket;
        }

        public Acceso MapAcceso(AccesoOtd objEntrada)
        {
            var respuestaTicket = new Acceso
            {
                Id = objEntrada.Id,
                Grupo = objEntrada.Grupo,
                Rol = objEntrada.Rol,
                NombreUsuario = objEntrada.NombreUsuario,
                Fecha = objEntrada.Fecha,
                Hora = objEntrada.Hora,
                IdAeroLineas = objEntrada.IdAeroLineas,
            };

            return respuestaTicket;
        }

        public PoliticasDeTratamientoDeDatos MapPoliticasDeTratamientoDeDatos(PoliticasDeTratamientoDeDatosOtd objEntrada)
        {
            var respuestaTicket = new PoliticasDeTratamientoDeDatos
            {
                Id = objEntrada.Id,
                NombreUsuario = objEntrada.NombreUsuario,
                AceptarPoliticas = objEntrada.AceptarPoliticas,
                Fecha = objEntrada.Fecha,
                Hora = objEntrada.Hora,
                Email = objEntrada.Email,
                PhoneNumber = objEntrada.PhoneNumber,
                NumeroDocumento = objEntrada.NumeroDocumento,
                Cargo = objEntrada.Cargo,
                Aerolinea = objEntrada.Aerolinea
            };

            return respuestaTicket;
        }

        public PoliticasDeTratamientoDeDatosOtd MapPoliticasDeTratamientoDeDatosOtd(PoliticasDeTratamientoDeDatos objEntrada)
        {
            var respuestaTicket = new PoliticasDeTratamientoDeDatosOtd
            {
                Id = objEntrada.Id,
                NombreUsuario = objEntrada.NombreUsuario,
                AceptarPoliticas = objEntrada.AceptarPoliticas,
                Fecha = objEntrada.Fecha,
                Hora = objEntrada.Hora,
                Email = objEntrada.Email,
                PhoneNumber = objEntrada.PhoneNumber,
                NumeroDocumento = objEntrada.NumeroDocumento,
                Cargo = objEntrada.Cargo,
                Aerolinea = objEntrada.Aerolinea
            };

            return respuestaTicket;
        }

        public RutaArchivos MapCargue(CargueOtd objEntrada)
        {
            var respuestaTicket = new RutaArchivos
            {
                Id = objEntrada.Id,
                TipoArchivo = objEntrada.TipoArchivo,
                FechaCreacion = objEntrada.Fecha,
                NombreArchivo = objEntrada.NombreArchivo
            };

            return respuestaTicket;
        }

        public CargueOtd MapCargueOtd(RutaArchivos objEntrada)
        {
            var respuestaTicket = new CargueOtd
            {
                Id = objEntrada.Id,
                TipoArchivo = objEntrada.TipoArchivo,
                Fecha = objEntrada.FechaCreacion,
                Usuario = objEntrada.IdUsuario,
                NombreArchivo = objEntrada.NombreArchivo,
            };

            return respuestaTicket;
        }

        public ConsecutivoCargueOtd MapCargueOtd(Cargue objEntrada)
        {
            var respuestaTicket = new ConsecutivoCargueOtd
            {
                Id = objEntrada.Id,
                FechaHora = objEntrada.FechaHora,
                Usuario = objEntrada.Usuario,
                Tipo = objEntrada.Tipo.ToString(),
            };

            return respuestaTicket;
        }

        public Cargue MapCargueConsecutivo(ConsecutivoCargueOtd objEntrada)
        {
            var respuestaTicket = new Cargue
            {
                Id = objEntrada.Id,
                FechaHora = objEntrada.FechaHora,
                Usuario = objEntrada.Usuario,
                Tipo = Convert.ToInt32(objEntrada.Tipo)
            };

            return respuestaTicket;
        }

        public Causal MapCausal(CausalOtd objEntrada)
        {
            var respuestaTicket = new Causal
            {
                Id = objEntrada.Id,
                Codigo = objEntrada.Codigo,
                Descripcion = objEntrada.Descripcion,
                Tipo = objEntrada.Tipo,
                Estado = objEntrada.Estado
            };

            return respuestaTicket;
        }

        public CausalOtd MapCausalOtd(Causal objEntrada)
        {
            var respuestaTicket = new CausalOtd
            {
                Id = objEntrada.Id,
                Codigo = objEntrada.Codigo,
                Descripcion = objEntrada.Descripcion,
                Tipo = objEntrada.Tipo,
                Estado = objEntrada.Estado
            };

            return respuestaTicket;
        }

        public NovedadProceso MapNovedadProceso(NovedadOtd objEntrada)
        {
            var novedadProceso = new NovedadProceso
            {
                Id = objEntrada.Id,
                IdOperacionVuelo = objEntrada.Operacion,
                TipoNovedad = objEntrada.TipoNovedad == "Cargue" ? 1 : 2,
                IdCausal = objEntrada.IdCausal,
                Descripcion = objEntrada.DescNovedad,
                IdRegistro = objEntrada.IdRegistro,
                FechaHora = objEntrada.FechaHora
            };

            return novedadProceso;
        }

        public NovedadOtd MapNovedadOtd(NovedadProceso objEntrada)
        {
            var novedadOtd = new NovedadOtd
            {
                Id = objEntrada.Id,
                Operacion = objEntrada.IdOperacionVuelo,
                TipoVuelo = objEntrada.OperacionesVuelo?.TipoVuelo,
                NumeroVuelo = objEntrada.OperacionesVuelo?.NumeroVuelo,
                FechaVuelo = objEntrada.OperacionesVuelo.FechaVuelo,
                HoraVuelo = objEntrada.OperacionesVuelo?.HoraVuelo,
                NumeroMatricula = objEntrada.OperacionesVuelo?.MatriculaVuelo,
                TipoNovedad = objEntrada.TipoNovedad == 1 ? "Cargue" : "Proceso",
                IdCausal = objEntrada.IdCausal,
                CodCausal = objEntrada.Causal?.Codigo,
                DescCausal = objEntrada.Causal?.Descripcion,
                DescNovedad = objEntrada.Descripcion,
                IdRegistro = objEntrada.IdRegistro,
                FechaHora = objEntrada.FechaHora
            };

            return novedadOtd;
        }

        public ConsecutivoCargueOtd MapConsecutivoCargueOtd(ConsecutivoCargueOtd objEntrada)
        {
            var cargue = new ConsecutivoCargueOtd
            {
                Id = objEntrada.Id,
                FechaHora = objEntrada.FechaHora,
                Usuario = objEntrada.Usuario,
                Archivo = objEntrada.Archivo,
                Tipo = objEntrada.Tipo
            };

            return cargue;
        }

        public ConsecutivoCargueOtd MapCargue(Cargue objEntrada)
        {
            var consecutivoCargueOtd = new ConsecutivoCargueOtd
            {
                Id = objEntrada.Id,
                FechaHora = objEntrada.FechaHora,
                Usuario = objEntrada.Usuario,
                Consecutivo = string.Format("{0}{1}{2}-{3}", objEntrada.FechaHora.Year, objEntrada.FechaHora.Month, objEntrada.FechaHora.Day, objEntrada.Id),
                Archivo = objEntrada.Archivo,
                Tipo = objEntrada.Tipo == 1 ? "Manual" : "Archivo"
            };

            return consecutivoCargueOtd;
        }

    }
}


