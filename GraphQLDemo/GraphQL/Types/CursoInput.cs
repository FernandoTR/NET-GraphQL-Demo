using System.ComponentModel.DataAnnotations;

namespace GraphQLDemo.GraphQL.Types
{
    public class CursoInput
    {
        [StringLength(100)]
        public string? NombreCurso { get; set; }

        [StringLength(255)]
        public string? Descripcion { get; set; }
    }
}
