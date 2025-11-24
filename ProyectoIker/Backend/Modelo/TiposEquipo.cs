using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProyectoIker.Backend.Modelo;

[Table("tipos_equipo")]
public partial class TiposEquipo
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(255)]
    public string Nombre { get; set; } = null!;

    [InverseProperty("Tipo")]
    public virtual ICollection<Equipo> Equipos { get; set; } = new List<Equipo>();
}
