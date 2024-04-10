using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Opain.Jarvis.Dominio.Entidades
{
    public class Usuario //: IdentityUser
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
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        [MaxLength(50)]
        public string Cargo { get; set; }
        [MaxLength(50)]
        public string Telefono { get; set; }
        [MaxLength(5)]
        public string TipoDocumento { get; set; }
        [MaxLength(20)]
        public string NumeroDocumento { get; set; }
        public bool Activo { get; set; }
        //public virtual ICollection<ClaimUsuario> ClaimUsuario { get; set; }
        //public virtual ICollection<LoginUsuario> LoginUsuario { get; set; }
        //public virtual ICollection<TokenUsuario> TokenUsuario { get; set; }
        public virtual ICollection<RolesUsuarios> RolesUsuarios { get; set; }
        public virtual ICollection<UsuariosAerolineas> UsuariosAerolineas { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual ICollection<RespuestaTicket> RespuestasTickets { get; set; }
    }
}
