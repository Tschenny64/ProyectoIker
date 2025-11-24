using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProyectoIker.Backend.Modelo;

[Table("equipos")]
[Index("MarcaId", Name = "Marca_ID")]
[Index("TipoId", Name = "Tipo_ID")]
public partial class Equipo
{
    [Key]
    [Column("Codigo_Unico")]
    public int CodigoUnico { get; set; }

    [StringLength(255)]
    public string? Modelo { get; set; }

    [Column("Marca_ID")]
    public int? MarcaId { get; set; }

    [Column("Numero_Serie")]
    [StringLength(100)]
    public string? NumeroSerie { get; set; }

    [Column("Tipo_ID")]
    public int? TipoId { get; set; }

    [ForeignKey("MarcaId")]
    [InverseProperty("Equipos")]
    public virtual Marca? Marca { get; set; }

    [InverseProperty("Equipo")]
    public virtual ICollection<ServiciosTecnico> ServiciosTecnicos { get; set; } = new List<ServiciosTecnico>();

    [ForeignKey("TipoId")]
    [InverseProperty("Equipos")]
    public virtual TiposEquipo? Tipo { get; set; }
}
