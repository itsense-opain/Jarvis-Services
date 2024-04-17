using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Opain.Jarvis.Dominio.Entidades;
namespace Opain.Jarvis.Infraestructura.Datos
{
    public class ContextoOpain : DbContext
    {
        public DbSet<U_Catalogo> U_Catalogo { get; set; }
        public DbSet<U_Item> U_Item { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Ciudad> Ciudades { get; set; }
        public DbSet<Aerolinea> Aerolineas { get; set; }
        //public DbSet<Vuelo> Vuelos { get; set; }
        public DbSet<OperacionesVuelo> OperacionesVuelos { get; set; }
        public DbSet<OperacionesVueloErrores> OperacionesVuelosErrores { get; set; }
        public DbSet<OperacionesVueloSeguimiento> OperacionVueloSeguimiento { get; set; }
        public DbSet<Pasajero> Pasajeros { get; set; }
        public DbSet<PasajeroTransito> PasajerosTransito { get; set; }
        public DbSet<UsuariosAerolineas> UsuariosAerolineas { get; set; }
        //public DbSet<HorarioAerolinea> HorariosAerolineas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<TasaAeroportuaria> TasasAeroportuarias { get; set; }
        //public DbSet<HorarioOperacion> HorariosOperaciones { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<RespuestaTicket> RespuestasTickets { get; set; }
        //public DbSet<Acceso> Accesos { get; set; }
        public DbSet<Aeropuertos> Aeropuertos { get; set; }
        public DbSet<PoliticasDeTratamientoDeDatos> PoliticasDeTratamientoDeDatos { get; set; }
        public DbSet<RutaArchivos> RutaArchivos { get; set; }
        public DbSet<Causal> Causales { get; set; }
        //public DbSet<NovedadProceso> NovedadesProcesos { get; set; }
        //public DbSet<Cargue> Cargues { get; set; }
        //public DbSet<ValidacionManual> ValidacionesManuales { get; set; }
        public DbSet<Tripulantes> Tripulantes { get; set; }
        public DbSet<CategoriaPasajeros> CategoriaPasajeros { get; set; }
        public DbSet<CantidadPasajerosOperacionVuelo> CantidadPasajerosOperacionVuelo { get; set; }
        public ContextoOpain(DbContextOptions<ContextoOpain> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Rol>(b =>
            {
                b.ToTable("Roles");

                b.Property(e => e.Id).HasMaxLength(150);
            });

            builder.Entity<RolesUsuarios>(
                b =>
                {
                    b.HasKey(e => new { e.IdUsuario, e.IdRol });
                });

            builder.Entity<UsuariosAerolineas>(
                b =>
                {
                    b.HasKey(e => new { e.IdAerolinea, e.IdUsuario });
                });

            builder.Entity<OperacionesVuelo>(b =>
            {
                b.Property(e => e.FechaVuelo).HasColumnType("date");
                b.Property(e => e.FechaLlegada).HasColumnType("date");
            });

            builder.Entity<OperacionesVueloErrores>(b =>
            {
                b.Property(e => e.Fecha).HasColumnType("date");
                b.Property(e => e.TipoValidacion).HasDefaultValueSql("0");
                b.Property(e => e.TipoValidacion2).HasDefaultValueSql("0");
            });

            builder.Entity<Pasajero>(b =>
            {
                b.Property(e => e.FechaVuelo).HasColumnType("date");
            });

            builder.Entity<PasajeroTransito>(b =>
            {
                b.Property(e => e.FechaLlegada).HasColumnType("date");
                b.Property(e => e.FechaSalida).HasColumnType("date");
            });

            builder.Entity<TasaAeroportuaria>(b =>
            {
                b.Property(e => e.Fecha).HasColumnType("date");
            });

            builder.Entity<Ticket>(b =>
            {
                b.Property(e => e.FechaVuelo).HasColumnType("date");
            });

            builder.Entity<PoliticasDeTratamientoDeDatos>(b =>
            {
                b.Property(e => e.Fecha).HasColumnType("date");
            });

            builder.Entity<Aerolinea>(b =>
            {
                b.Property(e => e.PDFPasajeros).HasConversion<int>();
                b.Property(e => e.FechaCreacion).HasDefaultValueSql("GETDATE()");
            });
        }
        public class YourDbContextFactory : IDesignTimeDbContextFactory<ContextoOpain>
        {
            public ContextoOpain CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<ContextoOpain>();
                optionsBuilder.UseSqlServer("Server=192.168.93.11;Database=OpainDev;User Id=DevelopOpain;Password=Jarvis2024Dv;TrustServerCertificate=True");

                return new ContextoOpain(optionsBuilder.Options);
            }
        }
    }
}
