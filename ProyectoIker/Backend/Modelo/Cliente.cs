using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProyectoIker.Backend.Modelo;

[Table("clientes")]
public partial class Cliente
{
    [Key]
    [Column("Codigo_Unico")]
    public int CodigoUnico { get; set; }

    [StringLength(255)]
    public string? Nombre { get; set; }

    [StringLength(255)]
    public string? Apellido1 { get; set; }

    [StringLength(255)]
    public string? Apellido2 { get; set; }

    [Column(TypeName = "text")]
    public string? Direccion { get; set; }

    [StringLength(20)]
    public string? Telefono { get; set; }

    [Column("Correo_Electronico")]
    [StringLength(255)]
    public string? CorreoElectronico { get; set; }

    [InverseProperty("Cliente")]
    public virtual ICollection<PromocionesCliente> PromocionesClientes { get; set; } = new List<PromocionesCliente>();

    [InverseProperty("Cliente")]
    public virtual ICollection<ServiciosTecnico> ServiciosTecnicos { get; set; } = new List<ServiciosTecnico>();

    [InverseProperty("Cliente")]
    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();

    [ForeignKey("ClienteId")]
    [InverseProperty("Clientes")]
    public virtual ICollection<Role> Rols { get; set; } = new List<Role>();
}
