using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProyectoIker.Backend.Modelo;

[PrimaryKey("VentaId", "ProductoId")]
[Table("productos_vendidos")]
[Index("ProductoId", Name = "Producto_ID")]
public partial class ProductosVendido
{
    [Key]
    [Column("Venta_ID")]
    public int VentaId { get; set; }

    [Key]
    [Column("Producto_ID")]
    public int ProductoId { get; set; }

    public int? Cantidad { get; set; }

    public float? Importe { get; set; }

    [ForeignKey("ProductoId")]
    [InverseProperty("ProductosVendidos")]
    public virtual Producto Producto { get; set; } = null!;

    [ForeignKey("VentaId")]
    [InverseProperty("ProductosVendidos")]
    public virtual Venta Venta { get; set; } = null!;
}
