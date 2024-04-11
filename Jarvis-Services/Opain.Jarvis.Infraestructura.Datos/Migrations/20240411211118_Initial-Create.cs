using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Opain.Jarvis.Infraestructura.Datos.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aerolineas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IdEstado = table.Column<bool>(type: "bit", nullable: false),
                    PDFPasajeros = table.Column<int>(type: "int", nullable: false),
                    CantidadUsuarios = table.Column<int>(type: "int", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    Sigla = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aerolineas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Aeropuertos",
                columns: table => new
                {
                    CodigoIATA = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    CobroCausal64VuelosDom = table.Column<bool>(type: "bit", nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    Pais = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aeropuertos", x => x.CodigoIATA);
                });

            migrationBuilder.CreateTable(
                name: "Pais",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdEstado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PoliticasDeTratamientoDeDatos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreUsuario = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    AceptarPoliticas = table.Column<bool>(type: "BIT", nullable: false),
                    Fecha = table.Column<DateTime>(type: "date", nullable: false),
                    Hora = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    NumeroDocumento = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Cargo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Aerolinea = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoliticasDeTratamientoDeDatos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TasaAeroportuaria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValorCOP = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorUSD = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TasaAeroportuaria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "U_Catalogo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 11, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_U_Catalogo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<bool>(type: "bit", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cargo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TipoDocumento = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    NumeroDocumento = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tripulantes",
                columns: table => new
                {
                    IdTripulantes = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreTripulante = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    LicenciaTripulante = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    FuncionTripulante = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    codigoAreolinea = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tripulantes", x => x.IdTripulantes);
                    table.ForeignKey(
                        name: "FK_Tripulantes_Aerolineas_codigoAreolinea",
                        column: x => x.codigoAreolinea,
                        principalTable: "Aerolineas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ciudades",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IdPais = table.Column<string>(type: "nvarchar(2)", nullable: false),
                    IdEstado = table.Column<bool>(type: "bit", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ciudades_Pais_IdPais",
                        column: x => x.IdPais,
                        principalTable: "Pais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "U_Item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCatalogo = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_U_Item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_U_Item_U_Catalogo_IdCatalogo",
                        column: x => x.IdCatalogo,
                        principalTable: "U_Catalogo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoriaPasajeros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodPasajero = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Posicion = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUsuario = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaPasajeros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoriaPasajeros_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolesUsuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdRol = table.Column<string>(type: "nvarchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesUsuarios", x => new { x.IdUsuario, x.IdRol });
                    table.ForeignKey(
                        name: "FK_RolesUsuarios_Roles_IdRol",
                        column: x => x.IdRol,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolesUsuarios_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuariosAerolineas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAerolinea = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosAerolineas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuariosAerolineas_Aerolineas_IdAerolinea",
                        column: x => x.IdAerolinea,
                        principalTable: "Aerolineas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuariosAerolineas_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Causales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Causales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Causales_U_Item_Tipo",
                        column: x => x.Tipo,
                        principalTable: "U_Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OperacionesVuelo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatriculaVuelo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    FechaVuelo = table.Column<DateTime>(type: "date", nullable: false),
                    HoraVuelo = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    TotalEmbarcados = table.Column<int>(type: "int", nullable: false),
                    PagoCOP = table.Column<int>(type: "int", nullable: false),
                    PagoUSD = table.Column<int>(type: "int", nullable: false),
                    TipoVuelo = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    NumeroVuelo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Destino = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    IdAerolinea = table.Column<int>(type: "int", nullable: false),
                    EstadoProceso = table.Column<int>(type: "int", nullable: false),
                    NumeroVueloLlegada = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    OrigenDes = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Origen = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    FechaLlegada = table.Column<DateTime>(type: "date", nullable: false),
                    HoraLlegada = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    TotalEmbarcadosAdd = table.Column<int>(type: "int", nullable: true),
                    TotalEmbarcados_LIQ = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperacionesVuelo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OperacionesVuelo_Aerolineas_IdAerolinea",
                        column: x => x.IdAerolinea,
                        principalTable: "Aerolineas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OperacionesVuelo_U_Item_EstadoProceso",
                        column: x => x.EstadoProceso,
                        principalTable: "U_Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroTicket = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TipoConsulta = table.Column<int>(type: "int", nullable: false),
                    Asunto = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    FechaVuelo = table.Column<DateTime>(type: "date", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mensaje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adjunto = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    IdAerolinea = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Seguimiento = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ticket_Aerolineas_IdAerolinea",
                        column: x => x.IdAerolinea,
                        principalTable: "Aerolineas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ticket_U_Item_TipoConsulta",
                        column: x => x.TipoConsulta,
                        principalTable: "U_Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ticket_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CantidadPasajerosOperacionVuelo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdVuelo = table.Column<int>(type: "int", nullable: false),
                    CodPasajero = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUsuario = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CantidadPasajerosOperacionVuelo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CantidadPasajerosOperacionVuelo_CategoriaPasajeros_CodPasajero",
                        column: x => x.CodPasajero,
                        principalTable: "CategoriaPasajeros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CantidadPasajerosOperacionVuelo_OperacionesVuelo_IdVuelo",
                        column: x => x.IdVuelo,
                        principalTable: "OperacionesVuelo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CantidadPasajerosOperacionVuelo_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "OperacionesVueloErrores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdVuelo = table.Column<int>(type: "int", nullable: false),
                    TipoError = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Error = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Fecha = table.Column<DateTime>(type: "date", nullable: false),
                    Valores = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ValoresNuevos = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    TipoValidacion = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    TipoValidacion2 = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperacionesVueloErrores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OperacionesVueloErrores_OperacionesVuelo_IdVuelo",
                        column: x => x.IdVuelo,
                        principalTable: "OperacionesVuelo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OperacionesVueloSeguimiento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdOperacionVuelo = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperacionesVueloSeguimiento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OperacionesVueloSeguimiento_OperacionesVuelo_IdOperacionVuelo",
                        column: x => x.IdOperacionVuelo,
                        principalTable: "OperacionesVuelo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OperacionesVueloSeguimiento_U_Item_Estado",
                        column: x => x.Estado,
                        principalTable: "U_Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_OperacionesVueloSeguimiento_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RutaArchivos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreArchivo = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    IdOperacionVuelo = table.Column<int>(type: "int", nullable: false),
                    TipoArchivo = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUsuario = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RutaArchivos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RutaArchivos_OperacionesVuelo_IdOperacionVuelo",
                        column: x => x.IdOperacionVuelo,
                        principalTable: "OperacionesVuelo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RutaArchivos_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RespuestaTicket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTicket = table.Column<int>(type: "int", nullable: false),
                    Mensaje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adjunto = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUsuario = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespuestaTicket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RespuestaTicket_Ticket_IdTicket",
                        column: x => x.IdTicket,
                        principalTable: "Ticket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RespuestaTicket_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Pasajero",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdOperacionVuelo = table.Column<int>(type: "int", nullable: false),
                    NombrePasajero = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IdCategoriaPasajero = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    FechaVuelo = table.Column<DateTime>(type: "date", nullable: false),
                    NumeroVuelo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    MatriculaVuelo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Realiza_viaje = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    Motivo_exencion = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    IdCargue = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pasajero", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pasajero_OperacionesVuelo_IdOperacionVuelo",
                        column: x => x.IdOperacionVuelo,
                        principalTable: "OperacionesVuelo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pasajero_RutaArchivos_IdCargue",
                        column: x => x.IdCargue,
                        principalTable: "RutaArchivos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PasajeroTransito",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdOperacionVuelo = table.Column<int>(type: "int", nullable: false),
                    NombrePasajero = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IdVueloLlegada = table.Column<int>(type: "int", nullable: false),
                    IdVueloSalida = table.Column<int>(type: "int", nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    FechaLlegada = table.Column<DateTime>(type: "date", nullable: false),
                    HoraLlegada = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    FechaSalida = table.Column<DateTime>(type: "date", nullable: false),
                    HoraSalida = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    FechaHoraCargue = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Firmado = table.Column<bool>(type: "bit", nullable: false),
                    FechaHoraFirma = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumeroVueloSalida = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Destino = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    AerolineaSalida = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NumeroVueloLlegada = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Origen = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    AerolineaLlegada = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TasaCobrada = table.Column<bool>(type: "bit", nullable: false),
                    IdCargue = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasajeroTransito", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PasajeroTransito_OperacionesVuelo_IdOperacionVuelo",
                        column: x => x.IdOperacionVuelo,
                        principalTable: "OperacionesVuelo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PasajeroTransito_RutaArchivos_IdCargue",
                        column: x => x.IdCargue,
                        principalTable: "RutaArchivos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CantidadPasajerosOperacionVuelo_CodPasajero",
                table: "CantidadPasajerosOperacionVuelo",
                column: "CodPasajero");

            migrationBuilder.CreateIndex(
                name: "IX_CantidadPasajerosOperacionVuelo_IdUsuario",
                table: "CantidadPasajerosOperacionVuelo",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_CantidadPasajerosOperacionVuelo_IdVuelo",
                table: "CantidadPasajerosOperacionVuelo",
                column: "IdVuelo");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriaPasajeros_IdUsuario",
                table: "CategoriaPasajeros",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Causales_Tipo",
                table: "Causales",
                column: "Tipo");

            migrationBuilder.CreateIndex(
                name: "IX_Ciudades_IdPais",
                table: "Ciudades",
                column: "IdPais");

            migrationBuilder.CreateIndex(
                name: "IX_OperacionesVuelo_EstadoProceso",
                table: "OperacionesVuelo",
                column: "EstadoProceso");

            migrationBuilder.CreateIndex(
                name: "IX_OperacionesVuelo_IdAerolinea",
                table: "OperacionesVuelo",
                column: "IdAerolinea");

            migrationBuilder.CreateIndex(
                name: "IX_OperacionesVueloErrores_IdVuelo",
                table: "OperacionesVueloErrores",
                column: "IdVuelo");

            migrationBuilder.CreateIndex(
                name: "IX_OperacionesVueloSeguimiento_Estado",
                table: "OperacionesVueloSeguimiento",
                column: "Estado");

            migrationBuilder.CreateIndex(
                name: "IX_OperacionesVueloSeguimiento_IdOperacionVuelo",
                table: "OperacionesVueloSeguimiento",
                column: "IdOperacionVuelo");

            migrationBuilder.CreateIndex(
                name: "IX_OperacionesVueloSeguimiento_IdUsuario",
                table: "OperacionesVueloSeguimiento",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Pasajero_IdCargue",
                table: "Pasajero",
                column: "IdCargue");

            migrationBuilder.CreateIndex(
                name: "IX_Pasajero_IdOperacionVuelo",
                table: "Pasajero",
                column: "IdOperacionVuelo");

            migrationBuilder.CreateIndex(
                name: "IX_PasajeroTransito_IdCargue",
                table: "PasajeroTransito",
                column: "IdCargue");

            migrationBuilder.CreateIndex(
                name: "IX_PasajeroTransito_IdOperacionVuelo",
                table: "PasajeroTransito",
                column: "IdOperacionVuelo");

            migrationBuilder.CreateIndex(
                name: "IX_RespuestaTicket_IdTicket",
                table: "RespuestaTicket",
                column: "IdTicket");

            migrationBuilder.CreateIndex(
                name: "IX_RespuestaTicket_IdUsuario",
                table: "RespuestaTicket",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_RolesUsuarios_IdRol",
                table: "RolesUsuarios",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "IX_RutaArchivos_IdOperacionVuelo",
                table: "RutaArchivos",
                column: "IdOperacionVuelo");

            migrationBuilder.CreateIndex(
                name: "IX_RutaArchivos_IdUsuario",
                table: "RutaArchivos",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_IdAerolinea",
                table: "Ticket",
                column: "IdAerolinea");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_IdUsuario",
                table: "Ticket",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_TipoConsulta",
                table: "Ticket",
                column: "TipoConsulta");

            migrationBuilder.CreateIndex(
                name: "IX_Tripulantes_codigoAreolinea",
                table: "Tripulantes",
                column: "codigoAreolinea");

            migrationBuilder.CreateIndex(
                name: "IX_U_Item_IdCatalogo",
                table: "U_Item",
                column: "IdCatalogo");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosAerolineas_IdAerolinea",
                table: "UsuariosAerolineas",
                column: "IdAerolinea");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosAerolineas_IdUsuario",
                table: "UsuariosAerolineas",
                column: "IdUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aeropuertos");

            migrationBuilder.DropTable(
                name: "CantidadPasajerosOperacionVuelo");

            migrationBuilder.DropTable(
                name: "Causales");

            migrationBuilder.DropTable(
                name: "Ciudades");

            migrationBuilder.DropTable(
                name: "OperacionesVueloErrores");

            migrationBuilder.DropTable(
                name: "OperacionesVueloSeguimiento");

            migrationBuilder.DropTable(
                name: "Pasajero");

            migrationBuilder.DropTable(
                name: "PasajeroTransito");

            migrationBuilder.DropTable(
                name: "PoliticasDeTratamientoDeDatos");

            migrationBuilder.DropTable(
                name: "RespuestaTicket");

            migrationBuilder.DropTable(
                name: "RolesUsuarios");

            migrationBuilder.DropTable(
                name: "TasaAeroportuaria");

            migrationBuilder.DropTable(
                name: "Tripulantes");

            migrationBuilder.DropTable(
                name: "UsuariosAerolineas");

            migrationBuilder.DropTable(
                name: "CategoriaPasajeros");

            migrationBuilder.DropTable(
                name: "Pais");

            migrationBuilder.DropTable(
                name: "RutaArchivos");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "OperacionesVuelo");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Aerolineas");

            migrationBuilder.DropTable(
                name: "U_Item");

            migrationBuilder.DropTable(
                name: "U_Catalogo");
        }
    }
}
