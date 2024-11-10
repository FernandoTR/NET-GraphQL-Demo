using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDemo.Data.Entities;

public partial class Inscripcione
{
    [Key]
    public int Id { get; set; }

    [Column("AlumnoID")]
    public int? AlumnoId { get; set; }

    [Column("CursoID")]
    public int? CursoId { get; set; }

    public DateOnly? FechaInscripcion { get; set; }

    [ForeignKey("AlumnoId")]
    [InverseProperty("Inscripciones")]
    public virtual Alumno? Alumno { get; set; }

    [ForeignKey("CursoId")]
    [InverseProperty("Inscripciones")]
    public virtual Curso? Curso { get; set; }
}
