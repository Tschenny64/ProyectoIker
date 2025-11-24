using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProyectoIker.Backend.Modelo;

[Table("promociones")]
public partial class Promocione
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(255)]
    public string? Nombre { get; set; }

    [Column(TypeName = "text")]
    public string? Descripcion { get; set; }

    [Column("Fecha_Envio", TypeName = "date")]
    public DateTime? FechaEnvio { get; set; }

    public float? Descuento { get; set; }

    [InverseProperty("Promocion")]
    public virtual ICollection<PromocionesCliente> PromocionesClientes { get; set; } = new List<PromocionesCliente>();
}
