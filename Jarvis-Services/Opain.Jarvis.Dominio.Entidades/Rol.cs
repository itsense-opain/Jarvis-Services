using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace Opain.Jarvis.Dominio.Entidades
{
    [Table("Rol")]
    public class Rol : IdentityRole
    {
        public Rol() : base() { }
        public Rol(string roleName)
            : base(roleName)
        {
            base.Name = roleName;
        }
        public virtual ICollection<RolesUsuarios> RolesUsuarios { get; set; }
        //public virtual ICollection<ClaimRol> ClaimRol { get; set; }
    }

}
