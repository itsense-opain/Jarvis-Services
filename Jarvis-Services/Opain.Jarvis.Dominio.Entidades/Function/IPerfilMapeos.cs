using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Opain.Jarvis.Dominio.Entidades.Function
{
    public interface IPerfilMapeos
    {
        OperacionesVuelo MapOperacionVuelo(OperacionVueloOtd objEntrada);

        OperacionVueloOtd MapOperacionVueloOtd(OperacionesVuelo objEntrada);
        Pasajero MapPasajero(PasajeroOtd objEntrada);
        PasajeroOtd MapPasajeroOtd(Pasajero objEntrada);
        PasajeroTransito MapPasajeroTransito(PasajeroTransitoOtd objEntrada);
        PasajeroTransitoOtd MapPasajeroTransitoOtd(PasajeroTransito objEntrada);
        RutaArchivos MapArchivo(ArchivoOtd objEntrada);

        ArchivoOtd MapArchivoOtd(RutaArchivos objEntrada);
        UsuarioOtd MapUsuarioOtd(Usuario objEntrada);
        UsuariosAerolineasOtd MapUsuariosAerolineasOtd(UsuariosAerolineas objEntrada);
        HorarioAerolinea MapHorarioAerolinea(HorarioAerolineaOtd objEntrada);
        HorarioAerolineaOtd MapHorarioAerolineaOtd(HorarioAerolinea objEntrada);
        AerolineaOtd MapAerolineaOtd(Aerolinea objEntrada);
        Aerolinea MapAerolinea(AerolineaOtd objEntrada);
        RolesUsuariosOtd MapRolesUsuariosOtd(RolesUsuarios objEntrada);
        RolOtd MapRolOtd(Rol objEntrada);
        TasaAeroportuaria MapTasaAeroportuaria(TasaAeroportuariaOtd objEntrada);
        TasaAeroportuariaOtd MapTasaAeroportuariaOtd(TasaAeroportuaria objEntrada);
        HorarioOperacion MapHorarioOperacion(HorarioOperacionOtd objEntrada);
        HorarioOperacionOtd MapHorarioOperacionOtd(HorarioOperacion objEntrada);
        IngresoOtd MapIngresoOtd(Ingreso objEntrada);
        TicketOtd MapTicketOtd(Ticket objEntrada);
        Ticket MapTicket(TicketOtd objEntrada);
        RespuestaTicketOtd MapRespuestaTicketOtd(RespuestaTicket objEntrada);
        RespuestaTicket MapRespuestaTicket(RespuestaTicketOtd objEntrada);
        AccesoOtd MapAccesoOtd(Acceso objEntrada);
        Acceso MapAcceso(AccesoOtd objEntrada);

        PoliticasDeTratamientoDeDatos MapPoliticasDeTratamientoDeDatos(PoliticasDeTratamientoDeDatosOtd objEntrada);
        PoliticasDeTratamientoDeDatosOtd MapPoliticasDeTratamientoDeDatosOtd(PoliticasDeTratamientoDeDatos objEntrada);
        Cargue MapCargueConsecutivo(ConsecutivoCargueOtd objEntrada);
        Causal MapCausal(CausalOtd objEntrada);
        CausalOtd MapCausalOtd(Causal objEntrada);
        NovedadProceso MapNovedadProceso(NovedadOtd objEntrada);
        NovedadOtd MapNovedadOtd(NovedadProceso objEntrada);
        ConsecutivoCargueOtd MapConsecutivoCargueOtd(ConsecutivoCargueOtd objEntrada);
        ConsecutivoCargueOtd MapCargue(Cargue objEntrada);
        RutaArchivos MapCargue(CargueOtd cargueOtd);
        CargueOtd MapCargueOtd(RutaArchivos cargue);
    }
}
