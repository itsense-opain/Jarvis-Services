

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;
using Opain.Jarvis.Aplicacion.Interfaces;
using Opain.Jarvis.Aplicacion.Principal;
using Opain.Jarvis.Dominio.Entidades;
using Opain.Jarvis.Dominio.Entidades.Function;
using Opain.Jarvis.Infraestructura.Datos;
using Opain.Jarvis.Infraestructura.Datos.Core;
using System.Configuration;

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("Init Main");

try
{
    var builder = WebApplication.CreateBuilder(args);

    var connectionString = builder.Configuration.GetConnectionString("ConexionJarvisBD");
    builder.Services.AddDbContext<ContextoOpain>(options => options.UseSqlServer(connectionString));

    //builder.Services.AddIdentity<Usuario, Rol>()
    //            .AddEntityFrameworkStores<ContextoOpain>()
    //            .AddDefaultTokenProviders();

    //Domain
    builder.Services.AddTransient<IPerfilMapeos, PerfilMapeos>();

    //Core
    //builder.Services.AddTransient<UserManager<Usuario>>();
    //builder.Services.AddTransient<UserStore<Usuario>>();
    builder.Services.AddTransient<IOperacionVueloAplicacion, OperacionVueloAplicacion>();
    builder.Services.AddTransient<IOperacionesVueloRepositorio, OperacionesVueloRepositorio>();
    builder.Services.AddTransient<IVueloRepositorio, VueloRepositorio>();
    builder.Services.AddTransient<IArchivoRepositorio, ArchivoRepositorio>();
    builder.Services.AddTransient<IArchivoAplicacion, ArchivoAplicacion>();
    builder.Services.AddTransient<IPasajeroRepositorio, PasajeroRepositorio>();
    builder.Services.AddTransient<IPasajeroAplicacion, PasajeroAplicacion>();
    builder.Services.AddTransient<IPasajeroTransitoRepositorio, PasajeroTransitoRepositorio>();
    builder.Services.AddTransient<IPasajeroTransitoAplicacion, PasajeroTransitoAplicacion>();
    builder.Services.AddTransient<IUsuarioAplicacion, UsuarioAplicacion>();
    builder.Services.AddTransient<IUsuariosRepositorio, UsuariosRepositorio>();
    builder.Services.AddTransient<IAerolineaAplicacion, AerolineaAplicacion>();
    builder.Services.AddTransient<IAerolineaRepositorio, AerolineaRepositorio>();
    builder.Services.AddTransient<IHorarioOperacionAplicacion, HorarioOperacionAplicacion>();
    builder.Services.AddTransient<IHorarioOperacionRepositorio, HorarioOperacionRepositorio>();
    builder.Services.AddTransient<ITasaAeroportuariaAplicacion, TasaAeroportuariaAplicacion>();
    builder.Services.AddTransient<ITasaAeroportuariaRepositorio, TasaAeroportuariaRepositorio>();
    builder.Services.AddTransient<IHorarioAerolineaAplicacion, HorarioAerolineaAplicacion>();
    builder.Services.AddTransient<IHorarioAerolineaRepositorio, HorarioAerolineaRepositorio>();
    builder.Services.AddTransient<ITicketAplicacion, TicketAplicacion>();
    builder.Services.AddTransient<ITicketRepositorio, TicketRepositorio>();
    builder.Services.AddTransient<IRespuestaTicketAplicacion, RespuestaTicketAplicacion>();
    builder.Services.AddTransient<IRespuestaTicketRepositorio, RespuestaTicketRepositorio>();
    builder.Services.AddTransient<IAccesoAplicacion, AccesoAplicacion>();
    builder.Services.AddTransient<IPoliticasDeTratamientoDeDatosAplicacion, PoliticasDeTratamientoDeDatosAplicacion>();
    builder.Services.AddTransient<IPoliticasDeTratamientoDeDatosRepositorio, PoliticasDeTratamientoDeDatosRepositorio>();
    builder.Services.AddTransient<IAccesoRepositorio, AccesoRepositorio>();
    builder.Services.AddTransient<ICargueAplicacion, CargueAplicacion>();
    builder.Services.AddTransient<ICargueRepositorio, CargueRepositorio>();
    builder.Services.AddTransient<ICausalRepositorio, CausalRepositorio>();
    builder.Services.AddTransient<ICausalAplicacion, CausalAplicacion>();
    builder.Services.AddTransient<INovedadRepositorio, NovedadRepositorio>();
    builder.Services.AddTransient<INovedadAplicacion, NovedadAplicacion>();
    builder.Services.AddTransient<IConsecutivoCargueRepositorio, ConsecutivoCargueRepositorio>();
    builder.Services.AddTransient<IConsecutivoCargueAplicacion, ConsecutivoCargueAplicacion>();

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var services = builder.Services;

    // Register AutoMapper
    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();

}
catch (Exception ex)
{
    logger.Fatal(ex, "Unhandled exception");
}
finally
{
    logger.Info("Shut down complete");
    LogManager.Shutdown();
}

