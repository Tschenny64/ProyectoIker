using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProyectoIker.Backend.Modelo;

[Table("reparaciones")]
[Index("ServicioTecnicoId", Name = "Servicio_Tecnico_ID")]
public partial class Reparacione
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("Servicio_Tecnico_ID")]
    public int ServicioTecnicoId { get; set; }

    [Column(TypeName = "text")]
    public string? Descripcion { get; set; }

    [Column(TypeName = "text")]
    public string? Observaciones { get; set; }

    public float? Tiempo { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Fecha { get; set; }

    [ForeignKey("ServicioTecnicoId")]
    [InverseProperty("Reparaciones")]
    public virtual ServiciosTecnico ServicioTecnico { get; set; } = null!;
}
