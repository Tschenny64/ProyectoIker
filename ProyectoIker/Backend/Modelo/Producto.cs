using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using ProyectoIker.MVM.Base;

namespace ProyectoIker.Backend.Modelo;

[Table("productos")]
[Index("CategoriaId", Name = "Categoria_ID")]
public partial class Producto : ValidatableViewModel
{
    [Key]
    [Column("Codigo_Unico")]
    public int CodigoUnico { get; set; }

    [StringLength(255)]
    public string? Nombre { get; set; }

    [Column("Descripcion_Tecnica", TypeName = "text")]
    public string? DescripcionTecnica { get; set; }

    [Column("Precio_Unitario")]
    public float? PrecioUnitario { get; set; }

    [Column("Cantidad_Inventario")]
    public int? CantidadInventario { get; set; }

    [Column("Categoria_ID")]
    public int? CategoriaId { get; set; }

    [ForeignKey("CategoriaId")]
    [InverseProperty("Productos")]
    public virtual Categoria? Categoria { get; set; }

    [InverseProperty("Producto")]
    public virtual ICollection<ProductosVendido> ProductosVendidos { get; set; } = new List<ProductosVendido>();
}
