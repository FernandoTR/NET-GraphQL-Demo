namespace GraphQLDemo.GraphQL.Types
{
    public class InscripcioneInput
    {
        public int? AlumnoId { get; set; }
        public int? CursoId { get; set; }
        public DateOnly? FechaInscripcion { get; set; }
    }
}
