using System;
using System.Collections.Generic;
using GraphQLDemo.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDemo.Data;

public partial class EscuelaDbContext : DbContext
{
    public EscuelaDbContext()
    {
    }

    public EscuelaDbContext(DbContextOptions<EscuelaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alumno> Alumnos { get; set; }

    public virtual DbSet<Curso> Cursos { get; set; }

    public virtual DbSet<Inscripcione> Inscripciones { get; set; }

    public virtual DbSet<Profesore> Profesores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alumno>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Alumnos__90A6AA339077FE47");
        });

        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cursos__3214EC0744AC255A");
        });

        modelBuilder.Entity<Inscripcione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Inscripc__3214EC0749B3D627");

            entity.Property(e => e.FechaInscripcion).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Alumno).WithMany(p => p.Inscripciones).HasConstraintName("FK__Inscripci__Alumn__5CD6CB2B");

            entity.HasOne(d => d.Curso).WithMany(p => p.Inscripciones).HasConstraintName("FK__Inscripci__Curso__5DCAEF64");
        });

        modelBuilder.Entity<Profesore>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Profesor__3214EC074FE4A4E0");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
