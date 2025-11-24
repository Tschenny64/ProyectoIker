using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProyectoIker.Backend.Modelo;

[Table("permisos")]
public partial class Permiso
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column(TypeName = "text")]
    public string? Descripcion { get; set; }

    [ForeignKey("PermisoId")]
    [InverseProperty("Permisos")]
    public virtual ICollection<Role> Rols { get; set; } = new List<Role>();
}
