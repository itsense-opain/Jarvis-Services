﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Opain.Jarvis.Infraestructura.Datos;

namespace Opain.Jarvis.Infraestructura.Datos.Migrations
{
    [DbContext(typeof(ContextoOpain))]
    [Migration("20190620224206_Migracion001")]
    partial class Migracion001
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity("Opain.Jarvis.Dominio.Entidades.Aerolinea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("IdEstado");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<int>("PDFPasajeros");

                    b.HasKey("Id");

                    b.ToTable("Aerolineas");
                });

            modelBuilder.Entity("Opain.Jarvis.Dominio.Entidades.Archivo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("IdOperacionVuelo");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("Tipo");

                    b.HasKey("Id");

                    b.HasIndex("IdOperacionVuelo");

                    b.ToTable("Archivos");
                });

            modelBuilder.Entity("Opain.Jarvis.Dominio.Entidades.Ciudad", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(3);

                    b.Property<int>("IdEstado");

                    b.Property<string>("IdPais")
                        .IsRequired();

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.HasIndex("IdPais");

                    b.ToTable("Ciudades");
                });

            modelBuilder.Entity("Opain.Jarvis.Dominio.Entidades.ClaimRol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(150);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("ClaimsRoles");
                });

            modelBuilder.Entity("Opain.Jarvis.Dominio.Entidades.ClaimUsuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(150);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ClaimsUsuario");
                });

            modelBuilder.Entity("Opain.Jarvis.Dominio.Entidades.HorarioAerolinea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Fecha");

                    b.Property<string>("HoraFin")
                        .HasMaxLength(5);

                    b.Property<string>("HoraInicio")
                        .HasMaxLength(5);

                    b.Property<int>("IdAerolinea");

                    b.HasKey("Id");

                    b.HasIndex("IdAerolinea");

                    b.ToTable("HorariosAerolineas");
                });

            modelBuilder.Entity("Opain.Jarvis.Dominio.Entidades.LoginUsuario", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(150);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(150);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("LoginsUsuario");
                });

            modelBuilder.Entity("Opain.Jarvis.Dominio.Entidades.OperacionesVuelo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CanfirmacionManifiesto");

                    b.Property<int>("ConfirmacionGenDec");

                    b.Property<int>("ConfirmacionOperacion");

                    b.Property<int>("ConfirmacionPasajeros");

                    b.Property<int>("ConfirmacionTransitos");

                    b.Property<int>("EX");

                    b.Property<DateTime>("FechaVuelo");

                    b.Property<string>("HoraVuelo")
                        .IsRequired()
                        .HasMaxLength(5);

                    b.Property<int>("INF");

                    b.Property<int>("IdVuelo");

                    b.Property<string>("MatriculaVuelo")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<int>("PAX");

                    b.Property<int>("PagoCOP");

                    b.Property<int>("PagoUSD");

                    b.Property<int>("TRIP");

                    b.Property<int>("TTC");

                    b.Property<int>("TTL");

                    b.Property<int>("TotalEmbarcados");

                    b.HasKey("Id");

                    b.HasIndex("IdVuelo");

                    b.ToTable("OperacionesVuelos");
                });

            modelBuilder.Entity("Opain.Jarvis.Dominio.Entidades.OperacionesVueloMaster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("FechaVuelo");

                    b.Property<string>("HoraVuelo")
                        .IsRequired()
                        .HasMaxLength(5);

                    b.Property<int>("IdVuelo");

                    b.Property<string>("MatriculaVuelo")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.HasIndex("IdVuelo");

                    b.ToTable("OperacionesVuelosMaster");
                });

            modelBuilder.Entity("Opain.Jarvis.Dominio.Entidades.Pais", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(2);

                    b.Property<bool>("IdEstado");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Paises");
                });

            modelBuilder.Entity("Opain.Jarvis.Dominio.Entidades.Pasajero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("IdCategoriaPasajero")
                        .IsRequired();

                    b.Property<int>("IdOperacionVuelo");

                    b.Property<string>("NombrePasajero")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.HasIndex("IdOperacionVuelo");

                    b.ToTable("Pasajeros");
                });

            modelBuilder.Entity("Opain.Jarvis.Dominio.Entidades.PasajeroTransito", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasMaxLength(5);

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasMaxLength(1);

                    b.Property<string>("IdDestino")
                        .IsRequired();

                    b.Property<int>("IdOperacionVuelo");

                    b.Property<string>("IdOrigen")
                        .IsRequired();

                    b.Property<string>("IdTipoMoneda")
                        .IsRequired();

                    b.Property<int>("IdVueloLlegada");

                    b.Property<int>("IdVueloSalida");

                    b.Property<string>("Identificacion")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Nacionalidad")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("NombrePasajero")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.HasIndex("IdDestino");

                    b.HasIndex("IdOperacionVuelo");

                    b.HasIndex("IdOrigen");

                    b.HasIndex("IdVueloLlegada");

                    b.HasIndex("IdVueloSalida");

                    b.ToTable("PasajerosTransito");
                });

            modelBuilder.Entity("Opain.Jarvis.Dominio.Entidades.Rol", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(150);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Opain.Jarvis.Dominio.Entidades.RolesUsuarios", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(150);

                    b.Property<string>("RoleId")
                        .HasMaxLength(150);

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("RolesUsuarios");
                });

            modelBuilder.Entity("Opain.Jarvis.Dominio.Entidades.TokenUsuario", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(150);

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(150);

                    b.Property<string>("Name")
                        .HasMaxLength(150);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("TokensUsuario");
                });

            modelBuilder.Entity("Opain.Jarvis.Dominio.Entidades.Usuario", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(150);

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Apellido");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<int>("EmailConfirmed")
                        .HasColumnType("int");

                    b.Property<int>("LockoutEnabled")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Nombre");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<int>("PhoneNumberConfirmed")
                        .HasColumnType("int");

                    b.Property<string>("SecurityStamp");

                    b.Property<int>("TwoFactorEnabled")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Opain.Jarvis.Dominio.Entidades.UsuariosAerolineas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("IdAerolinea");

                    b.Property<string>("IdUsuario");

                    b.HasKey("Id");

                    b.HasIndex("IdAerolinea");

                    b.HasIndex("IdUsuario");

                    b.ToTable("UsuariosAerolineas");
                });

            modelBuilder.Entity("Opain.Jarvis.Dominio.Entidades.Vuelo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("IdAerolinea");

                    b.Property<string>("IdDestino")
                        .IsRequired();

                    b.Property<int>("IdEstado");

                    b.Property<string>("IdOrigen")
                        .IsRequired();

                    b.Property<string>("NumeroVuelo")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("TipoVuelo")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("IdAerolinea");

                    b.HasIndex("IdDestino");

                    b.HasIndex("IdOrigen");

                    b.ToTable("Vuelos");
                });

            modelBuilder.Entity("Opain.Jarvis.Dominio.Entidades.Archivo", b =>
                {
                    b.HasOne("Opain.Jarvis.Dominio.Entidades.OperacionesVuelo", "OperacionesVuelo")
                        .WithMany("Archivos")
                        .HasForeignKey("IdOperacionVuelo")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Opain.Jarvis.Dominio.Entidades.Ciudad", b =>
                {
                    b.HasOne("Opain.Jarvis.Dominio.Entidades.Pais", "Pais")
                        .WithMany("Ciudades")
                        .HasForeignKey("IdPais")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Opain.Jarvis.Dominio.Entidades.ClaimRol", b =>
                {
                    b.HasOne("Opain.Jarvis.Dominio.Entidades.Rol", "Rol")
                        .WithMany("ClaimRol")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Opain.Jarvis.Dominio.Entidades.ClaimUsuario", b =>
                {
                    b.HasOne("Opain.Jarvis.Dominio.Entidades.Usuario", "Usuario")
                        .WithMany("ClaimUsuario")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Opain.Jarvis.Dominio.Entidades.HorarioAerolinea", b =>
                {
                    b.HasOne("Opain.Jarvis.Dominio.Entidades.Aerolinea", "Aerolinea")
                        .WithMany()
                        .HasForeignKey("IdAerolinea")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Opain.Jarvis.Dominio.Entidades.LoginUsuario", b =>
                {
                    b.HasOne("Opain.Jarvis.Dominio.Entidades.Usuario", "Usuario")
                        .WithMany("LoginUsuario")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Opain.Jarvis.Dominio.Entidades.OperacionesVuelo", b =>
                {
                    b.HasOne("Opain.Jarvis.Dominio.Entidades.Vuelo", "Vuelo")
                        .WithMany("OperacionesVuelos")
                        .HasForeignKey("IdVuelo")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Opain.Jarvis.Dominio.Entidades.OperacionesVueloMaster", b =>
                {
                    b.HasOne("Opain.Jarvis.Dominio.Entidades.Vuelo", "Vuelo")
                        .WithMany()
                        .HasForeignKey("IdVuelo")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Opain.Jarvis.Dominio.Entidades.Pasajero", b =>
                {
                    b.HasOne("Opain.Jarvis.Dominio.Entidades.OperacionesVuelo", "OperacionesVuelo")
                        .WithMany("Pasajeros")
                        .HasForeignKey("IdOperacionVuelo")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Opain.Jarvis.Dominio.Entidades.PasajeroTransito", b =>
                {
                    b.HasOne("Opain.Jarvis.Dominio.Entidades.Ciudad", "DestinoPasajero")
                        .WithMany("DestinosPasajeros")
                        .HasForeignKey("IdDestino")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Opain.Jarvis.Dominio.Entidades.OperacionesVuelo", "OperacionesVuelo")
                        .WithMany("PasajerosTransitos")
                        .HasForeignKey("IdOperacionVuelo")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Opain.Jarvis.Dominio.Entidades.Ciudad", "OrigenPasajero")
                        .WithMany("OrigenesPasajero")
                        .HasForeignKey("IdOrigen")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Opain.Jarvis.Dominio.Entidades.Vuelo", "VueloLlegada")
                        .WithMany("VuelosLlegada")
                        .HasForeignKey("IdVueloLlegada")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Opain.Jarvis.Dominio.Entidades.Vuelo", "VueloSalida")
                        .WithMany("VuelosSalida")
                        .HasForeignKey("IdVueloSalida")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Opain.Jarvis.Dominio.Entidades.RolesUsuarios", b =>
                {
                    b.HasOne("Opain.Jarvis.Dominio.Entidades.Rol", "Rol")
                        .WithMany("RolesUsuarios")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Opain.Jarvis.Dominio.Entidades.Usuario", "Usuario")
                        .WithMany("RolesUsuarios")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Opain.Jarvis.Dominio.Entidades.TokenUsuario", b =>
                {
                    b.HasOne("Opain.Jarvis.Dominio.Entidades.Usuario", "Usuario")
                        .WithMany("TokenUsuario")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Opain.Jarvis.Dominio.Entidades.UsuariosAerolineas", b =>
                {
                    b.HasOne("Opain.Jarvis.Dominio.Entidades.Aerolinea", "Aerolinea")
                        .WithMany("UsuariosAerolineas")
                        .HasForeignKey("IdAerolinea")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Opain.Jarvis.Dominio.Entidades.Usuario", "Usuario")
                        .WithMany("UsuariosAerolineas")
                        .HasForeignKey("IdUsuario");
                });

            modelBuilder.Entity("Opain.Jarvis.Dominio.Entidades.Vuelo", b =>
                {
                    b.HasOne("Opain.Jarvis.Dominio.Entidades.Aerolinea", "Aerolinea")
                        .WithMany("Vuelos")
                        .HasForeignKey("IdAerolinea")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Opain.Jarvis.Dominio.Entidades.Ciudad", "Destino")
                        .WithMany("Destinos")
                        .HasForeignKey("IdDestino")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Opain.Jarvis.Dominio.Entidades.Ciudad", "Origen")
                        .WithMany("Origenes")
                        .HasForeignKey("IdOrigen")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
