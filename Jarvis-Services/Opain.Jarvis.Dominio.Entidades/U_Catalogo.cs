﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Opain.Jarvis.Dominio.Entidades
{
    [Table("U_Catalogo")]
    public class U_Catalogo
    {
        [Key]
        [Required]
        [MaxLength(11)]
        public int Id { get; set; }
        [MaxLength(255)]
        public string Nombre { get; set; }
        [MaxLength(255)]
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
        [MaxLength(50)]
        public string Usuario  { get; set; }
    }
}
