using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models;

public partial class DbpruebaContext : DbContext
{
    public DbpruebaContext()
    {
    }

    public DbpruebaContext(DbContextOptions<DbpruebaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }
    public virtual DbSet<CTUSER> CTUSER { get; set; }
    public virtual DbSet<TablaGeneral> TablaGeneral { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProductos).HasName("PK__Producto__718C7D07D0E62172");

            entity.ToTable("Producto");

            entity.Property(e => e.Marca)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsusarios).HasName("PK__Usuario__BC6DFF31A320E559");

            entity.ToTable("Usuario");

            entity.Property(e => e.Clave)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CTUSER>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("id");

            entity.ToTable("CTUSER");

            entity.Property(e => e.Name).HasMaxLength(50).IsUnicode(false);

            entity.Property(e => e.Lname).HasMaxLength(50).IsUnicode(false);

            entity.Property(e => e.Doctype).HasMaxLength(50).IsUnicode(false);

            entity.Property(e => e.Docnum).HasMaxLength(50).IsUnicode(false);

            entity.Property(e => e.Nationality).HasMaxLength(50).IsUnicode(false);

            entity.Property(e => e.Address).HasMaxLength(50).IsUnicode(false);

            entity.Property(e => e.Borndate).HasMaxLength(50).IsUnicode(false);

            entity.Property(e => e.Gender).HasMaxLength(50).IsUnicode(false);
        });

        modelBuilder.Entity<TablaGeneral>(entity =>
        {
            entity.HasKey(e => e.IdGeneral).HasName("id");

            entity.ToTable("TablaGeneral");

            entity.Property(e => e.Valor).HasMaxLength(10).IsUnicode(false);

            entity.Property(e => e.Grupo).HasMaxLength(10).IsUnicode(false);

            entity.Property(e => e.Descripcion).HasMaxLength(100).IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
