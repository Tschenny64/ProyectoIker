using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProyectoIker.Backend.Modelo;

[Table("roles")]
public partial class Role
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(255)]
    public string? Nombre { get; set; }

    [Column(TypeName = "text")]
    public string? Descripcion { get; set; }

    [InverseProperty("Rol")]
    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();

    [ForeignKey("RolId")]
    [InverseProperty("Rols")]
    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    [ForeignKey("RolId")]
    [InverseProperty("Rols")]
    public virtual ICollection<Permiso> Permisos { get; set; } = new List<Permiso>();
}
