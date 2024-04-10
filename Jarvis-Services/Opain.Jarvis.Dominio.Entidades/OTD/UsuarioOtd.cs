using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Opain.Jarvis.Dominio.Entidades
{
    public class UsuarioOtd
    {
        [Key]
        public string Id { get; set; }
        [MaxLength(256)]
        public string UserName { get; set; }
        [MaxLength(256)]
        public string NormalizedUserName { get; set; }
        [MaxLength(256)]
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "No cumple caracteristicas de correo electronico.")]
        public string Email { get; set; }
        [MaxLength(256)]
        public string NormalizedEmail { get; set; }
        [Required]
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTime LockoutEnd { get; set; }
        [Required]
        public bool LockoutEnabled { get; set; }
        [Required]
        public bool AccessFailedCount { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }
        [Required]
        [Display(Name = "Cargo")]
        public string Cargo { get; set; }
        [Required]
        [Display(Name = "Telefono")]
        [Phone]
        public string Telefono { get; set; }
        [Required]
        [Display(Name = "Tipo de Documento")]
        public string TipoDocumento { get; set; }
        [Display(Name = "Documento de Identidad")]
        [Required]
        public string NumeroDocumento { get; set; }
        [Required]
        [Display(Name = "Perfil")]
        public string Perfil { get; set; }
        public string Aerolinea { get; set; }
        public bool Activo { get; set; }
        public string Clave { get; set; }

        public IList<UsuariosAerolineasOtd> UsuarioAerolinea { get; set; }
        public IList<RolesUsuariosOtd> RolesUsuario { get; set; }
    }

    public class Registros
    {
        
        public string IdAerolinea { get; set; }
        public string Id { get; set; }
        public string Tipo { get; set; }
        public string NumeroVuelo { get; set; }
        public string FechaVuelo { get; set; }
        public string HoraVuelo { get; set; }
        public string NumeroMatricula { get; set; }
        public string TasasReportadas { get; set; }
        public string TasasCobradas { get; set; }
        public string DiferenciaDeTasas { get; set; }
        public string EnvioNotificacion { get; set; }
    }
}
