using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProyectoIker.Backend.Modelo;

[Table("servicios_tecnicos")]
[Index("ClienteId", Name = "Cliente_ID")]
[Index("EmpleadoId", Name = "Empleado_ID")]
[Index("EquipoId", Name = "Equipo_ID")]
public partial class ServiciosTecnico
{
    [Key]
    [Column("Codigo_Servicio")]
    public int CodigoServicio { get; set; }

    [Column("Fecha_Registro", TypeName = "datetime")]
    public DateTime? FechaRegistro { get; set; }

    [StringLength(50)]
    public string? Estado { get; set; }

    [Column(TypeName = "text")]
    public string? Diagnostico { get; set; }

    [Column("Costos_Asociados")]
    public float? CostosAsociados { get; set; }

    [Column("Costo_Mano_Obra")]
    public float? CostoManoObra { get; set; }

    [Column("Precio_Por_Hora")]
    public float? PrecioPorHora { get; set; }

    public float? Total { get; set; }

    [Column("Fecha_Entrega", TypeName = "datetime")]
    public DateTime? FechaEntrega { get; set; }

    [Column("Equipo_ID")]
    public int? EquipoId { get; set; }

    [Column("Cliente_ID")]
    public int? ClienteId { get; set; }

    [Column("Empleado_ID")]
    public int? EmpleadoId { get; set; }

    [ForeignKey("ClienteId")]
    [InverseProperty("ServiciosTecnicos")]
    public virtual Cliente? Cliente { get; set; }

    [ForeignKey("EmpleadoId")]
    [InverseProperty("ServiciosTecnicos")]
    public virtual Empleado? Empleado { get; set; }

    [ForeignKey("EquipoId")]
    [InverseProperty("ServiciosTecnicos")]
    public virtual Equipo? Equipo { get; set; }

    [InverseProperty("ServicioTecnico")]
    public virtual ICollection<Reparacione> Reparaciones { get; set; } = new List<Reparacione>();
}
