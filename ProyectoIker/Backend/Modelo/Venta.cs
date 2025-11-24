using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProyectoIker.Backend.Modelo;

[Table("ventas")]
[Index("ClienteId", Name = "Cliente_ID")]
[Index("EmpleadoId", Name = "Empleado_ID")]
public partial class Venta
{
    [Key]
    [Column("Codigo_Venta")]
    public int CodigoVenta { get; set; }

    [Column("Cliente_ID")]
    public int? ClienteId { get; set; }

    [Column("Empleado_ID")]
    public int? EmpleadoId { get; set; }

    [Column("Fecha_Hora", TypeName = "datetime")]
    public DateTime? FechaHora { get; set; }

    [Column("Metodo_Pago")]
    [StringLength(50)]
    public string? MetodoPago { get; set; }

    [Column("Total_Venta")]
    public float? TotalVenta { get; set; }

    [Column("IVA")]
    public float? Iva { get; set; }

    [Column("Importe_Total")]
    public float? ImporteTotal { get; set; }

    [Column("Fecha_Factura", TypeName = "datetime")]
    public DateTime? FechaFactura { get; set; }

    [ForeignKey("ClienteId")]
    [InverseProperty("Venta")]
    public virtual Cliente? Cliente { get; set; }

    [ForeignKey("EmpleadoId")]
    [InverseProperty("Venta")]
    public virtual Empleado? Empleado { get; set; }

    [InverseProperty("Venta")]
    public virtual ICollection<ProductosVendido> ProductosVendidos { get; set; } = new List<ProductosVendido>();
}
