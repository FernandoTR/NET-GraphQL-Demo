using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDemo.Data.Entities;

public partial class Curso
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string? NombreCurso { get; set; }

    [StringLength(255)]
    public string? Descripcion { get; set; }

    [InverseProperty("Curso")]
    public virtual ICollection<Inscripcione> Inscripciones { get; set; } = new List<Inscripcione>();
}
