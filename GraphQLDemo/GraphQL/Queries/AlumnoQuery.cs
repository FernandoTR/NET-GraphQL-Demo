using GraphQLDemo.Data.Entities;
using GraphQLDemo.Data.Interfaces;
using HotChocolate.Authorization;

namespace GraphQLDemo.GraphQL.Queries
{
    [ExtendObjectType("Query")]
    public class AlumnoQuery
    {
        [Authorize]
        [UseFiltering]
        [UseSorting]
        public async Task<IQueryable<Alumno>> GetAllStudents([Service] IAlumnoRepository repository)
        {
            return await repository.GetAllAsync();
        }

        [Authorize]
        public async Task<Alumno> GetStudentById([Service] IAlumnoRepository repository, int id)
        {
            return await repository.GetByIdAsync(id);
        }
    }
}
