using System.ComponentModel.DataAnnotations;

namespace GraphQLDemo.GraphQL.Types
{
    public class ProfesoreInput
    {
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Email { get; set; }
        public string? Telefono { get; set; }
    }
}
