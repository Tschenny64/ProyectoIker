using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProyectoIker.Backend.Modelo;

public partial class ProyectoContext : DbContext
{
    public ProyectoContext()
    {
    }

    public ProyectoContext(DbContextOptions<ProyectoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Equipo> Equipos { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<Permiso> Permisos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<ProductosVendido> ProductosVendidos { get; set; }

    public virtual DbSet<Promocione> Promociones { get; set; }

    public virtual DbSet<PromocionesCliente> PromocionesClientes { get; set; }

    public virtual DbSet<Reparacione> Reparaciones { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<ServiciosTecnico> ServiciosTecnicos { get; set; }

    public virtual DbSet<TiposEquipo> TiposEquipos { get; set; }

    public virtual DbSet<Venta> Ventas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseLazyLoadingProxies().UseMySQL("server=127.0.0.1;port=3306;database=proyecto;user=root;password=mysql");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.CodigoUnico).HasName("PRIMARY");

            entity.HasMany(d => d.Rols).WithMany(p => p.Clientes)
                .UsingEntity<Dictionary<string, object>>(
                    "ClientesRole",
                    r => r.HasOne<Role>().WithMany()
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("clientes_roles_ibfk_2"),
                    l => l.HasOne<Cliente>().WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("clientes_roles_ibfk_1"),
                    j =>
                    {
                        j.HasKey("ClienteId", "RolId").HasName("PRIMARY");
                        j.ToTable("clientes_roles");
                        j.HasIndex(new[] { "RolId" }, "Rol_ID");
                        j.IndexerProperty<int>("ClienteId").HasColumnName("Cliente_ID");
                        j.IndexerProperty<int>("RolId").HasColumnName("Rol_ID");
                    });
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.CodigoUnico).HasName("PRIMARY");

            entity.HasOne(d => d.Rol).WithMany(p => p.Empleados).HasConstraintName("empleados_ibfk_1");
        });

        modelBuilder.Entity<Equipo>(entity =>
        {
            entity.HasKey(e => e.CodigoUnico).HasName("PRIMARY");

            entity.HasOne(d => d.Marca).WithMany(p => p.Equipos).HasConstraintName("equipos_ibfk_1");

            entity.HasOne(d => d.Tipo).WithMany(p => p.Equipos).HasConstraintName("equipos_ibfk_2");
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.CodigoUnico).HasName("PRIMARY");

            entity.HasOne(d => d.Categoria).WithMany(p => p.Productos).HasConstraintName("productos_ibfk_1");
        });

        modelBuilder.Entity<ProductosVendido>(entity =>
        {
            entity.HasKey(e => new { e.VentaId, e.ProductoId }).HasName("PRIMARY");

            entity.HasOne(d => d.Producto).WithMany(p => p.ProductosVendidos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("productos_vendidos_ibfk_2");

            entity.HasOne(d => d.Venta).WithMany(p => p.ProductosVendidos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("productos_vendidos_ibfk_1");
        });

        modelBuilder.Entity<Promocione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<PromocionesCliente>(entity =>
        {
            entity.HasKey(e => new { e.PromocionId, e.ClienteId }).HasName("PRIMARY");

            entity.HasOne(d => d.Cliente).WithMany(p => p.PromocionesClientes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("promociones_clientes_ibfk_2");

            entity.HasOne(d => d.Promocion).WithMany(p => p.PromocionesClientes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("promociones_clientes_ibfk_1");
        });

        modelBuilder.Entity<Reparacione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasOne(d => d.ServicioTecnico).WithMany(p => p.Reparaciones)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("reparaciones_ibfk_1");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasMany(d => d.Permisos).WithMany(p => p.Rols)
                .UsingEntity<Dictionary<string, object>>(
                    "RolesPermiso",
                    r => r.HasOne<Permiso>().WithMany()
                        .HasForeignKey("PermisoId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("roles_permisos_ibfk_2"),
                    l => l.HasOne<Role>().WithMany()
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("roles_permisos_ibfk_1"),
                    j =>
                    {
                        j.HasKey("RolId", "PermisoId").HasName("PRIMARY");
                        j.ToTable("roles_permisos");
                        j.HasIndex(new[] { "PermisoId" }, "Permiso_ID");
                        j.IndexerProperty<int>("RolId").HasColumnName("Rol_ID");
                        j.IndexerProperty<int>("PermisoId").HasColumnName("Permiso_ID");
                    });
        });

        modelBuilder.Entity<ServiciosTecnico>(entity =>
        {
            entity.HasKey(e => e.CodigoServicio).HasName("PRIMARY");

            entity.HasOne(d => d.Cliente).WithMany(p => p.ServiciosTecnicos).HasConstraintName("servicios_tecnicos_ibfk_2");

            entity.HasOne(d => d.Empleado).WithMany(p => p.ServiciosTecnicos).HasConstraintName("servicios_tecnicos_ibfk_3");

            entity.HasOne(d => d.Equipo).WithMany(p => p.ServiciosTecnicos).HasConstraintName("servicios_tecnicos_ibfk_1");
        });

        modelBuilder.Entity<TiposEquipo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.CodigoVenta).HasName("PRIMARY");

            entity.Property(e => e.Iva).HasDefaultValueSql("'21'");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Venta).HasConstraintName("ventas_ibfk_1");

            entity.HasOne(d => d.Empleado).WithMany(p => p.Venta).HasConstraintName("ventas_ibfk_2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
