
namespace GraphQLDemo.GraphQL.Types
{
    public class AlumnoInput
    {       
        public string? Nombre { get; set; }       
        public string? Apellido { get; set; }
        public DateOnly? FechaNacimiento { get; set; }        
        public string? Direccion { get; set; }        
        public string? Telefono { get; set; }        
        public string? Email { get; set; }
    }
}
