using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProyectoIker.Backend.Modelo;

[PrimaryKey("PromocionId", "ClienteId")]
[Table("promociones_clientes")]
[Index("ClienteId", Name = "Cliente_ID")]
public partial class PromocionesCliente
{
    [Key]
    [Column("Promocion_ID")]
    public int PromocionId { get; set; }

    [Key]
    [Column("Cliente_ID")]
    public int ClienteId { get; set; }

    public bool? Estado { get; set; }

    [ForeignKey("ClienteId")]
    [InverseProperty("PromocionesClientes")]
    public virtual Cliente Cliente { get; set; } = null!;

    [ForeignKey("PromocionId")]
    [InverseProperty("PromocionesClientes")]
    public virtual Promocione Promocion { get; set; } = null!;
}
