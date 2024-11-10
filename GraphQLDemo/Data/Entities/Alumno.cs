using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDemo.Data.Entities;

public partial class Alumno
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string? Nombre { get; set; }

    [StringLength(100)]
    public string? Apellido { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    [StringLength(255)]
    public string? Direccion { get; set; }

    [StringLength(15)]
    public string? Telefono { get; set; }

    [StringLength(100)]
    public string? Email { get; set; }

    [InverseProperty("Alumno")]
    public virtual ICollection<Inscripcione> Inscripciones { get; set; } = new List<Inscripcione>();
}
