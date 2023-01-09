using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AprendiendoASPnet.Models;

public partial class EstudiandoAspnetContext : DbContext
{
    public EstudiandoAspnetContext()
    {
    }

    public EstudiandoAspnetContext(DbContextOptions<EstudiandoAspnetContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Pertenencia> Pertenencias { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pertenencia>(entity =>
        {
            entity.HasKey(e => e.IdPertenencia);

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Pertenencia)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK_Pertenencias_Usuario");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario);

            entity.ToTable("Usuario");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
