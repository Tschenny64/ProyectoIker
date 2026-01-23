using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProyectoIker.Backend.Modelo;

[Table("empleados")]
[Index("RolId", Name = "Rol_ID")]
public partial class Empleado
{
    [Key]
    [Column("Codigo_Unico")]
    public int CodigoUnico { get; set; }

    [StringLength(255)]
    [Required(ErrorMessage = "El nombre es obligatorio")]
    public string? Nombre { get; set; }

    [StringLength(255)]

    public string? Apellido1 { get; set; }

    [StringLength(255)]
    public string? Apellido2 { get; set; }

    [Column("DNI")]
    [StringLength(20)]
    [Required(ErrorMessage = "El DNI es obligatorio")]
    public string? Dni { get; set; }

    [StringLength(20)]
    [Required(ErrorMessage = "El telefono es obligatorio")]
    public string? Telefono { get; set; }

    [StringLength(50)]
    [Required(ErrorMessage = "El usuario es obligatorio")]
    public string? Usuario { get; set; }

    [StringLength(255)]
    [Required(ErrorMessage = "La contraseña es obligatoria")]
    public string? Password { get; set; }

    [Column("Rol_ID")]
    public int? RolId { get; set; }

    [ForeignKey("RolId")]
    [InverseProperty("Empleados")]
    public virtual Role? Rol { get; set; }

    [InverseProperty("Empleado")]
    public virtual ICollection<ServiciosTecnico> ServiciosTecnicos { get; set; } = new List<ServiciosTecnico>();

    [InverseProperty("Empleado")]
    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();

    override
    public string ToString()
    {
        return Nombre + " " + Apellido1 + " " + Apellido2;
    }
}
